using Finance.Application.Abstract.Service;
using Finance.Application.Models.Auth;
using Finance.Persistence.Abstract.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Finance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private IAuthService _authService = authService;

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authService.Login(request.Email,request.Password);
            if(result  == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
