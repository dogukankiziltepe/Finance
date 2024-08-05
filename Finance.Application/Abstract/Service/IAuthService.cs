using Finance.Application.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Abstract.Service
{
    public interface IAuthService
    {
        /// <summary>
        /// Kullanıcı Girişi
        /// </summary>
        /// <param name="eMail">Kullanıcı E-Maili</param>
        /// <param name="password">Kullanıcı Şifresi</param>
        /// <returns></returns>
        public Task<LoginResponse> Login(string eMail, string password);
    }
}
