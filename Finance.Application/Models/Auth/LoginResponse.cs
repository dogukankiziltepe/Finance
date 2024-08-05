using Finance.Application.Models.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Models.Auth
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
