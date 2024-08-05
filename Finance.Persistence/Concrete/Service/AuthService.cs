using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Finance.Application.Abstract.Service;
using Finance.Application.Models.Auth;
using Finance.Application.Models.Menus;
using Finance.Base.Extensions;
using Finance.Persistence.Abstract.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Finance.Persistence.Concrete.Service
{
    public class AuthService(IUserRepository userRepository,IMenuRepository menuRepository,
        IMenuRoleRepository menuRoleRepository,IRoleRepository roleRepository,
        IConfiguration configuration) : IAuthService
    {
        private IConfiguration _configuration = configuration;
        private IUserRepository _userRepository = userRepository;
        private IMenuRoleRepository _menuRoleRepository = menuRoleRepository;
        public async Task<LoginResponse> Login(string eMail, string password)
        {
            try
            {
                var user = (await _userRepository.FindWithInclude(x => x.EMail == eMail, x=> x.Role, x => x.Company)).FirstOrDefault();
                if (user != null)
                {
                    var modelPassword = HashPassword.Hash(password);
                    //Hashlenmiş password karşılaştırması
                    if(modelPassword == user.Password)
                    {
                        var token = GetToken(user.Role.Name, user.Company.Id, user.Id);
                        if (token != null)
                        {
                           
                            return new LoginResponse
                            {
                                Role = user.Role.Name,
                                Token = token
                            };
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            } 
        }


        public string GetToken(string role, string companyId, string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Token içerisine claim atama
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.NameIdentifier,userId),
            new Claim(ClaimTypes.Role,role),
            new Claim("CompanyId", companyId),
                    // Add more claims as needed
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"], // Add this line
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var s = tokenHandler.WriteToken(token);
            return s;
        }
    }
}
