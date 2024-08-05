using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Persistence.Abstract.Service
{
    public interface IUserService
    {
        public string GetUserCompany();
        public string GetUserId();
    }
}
