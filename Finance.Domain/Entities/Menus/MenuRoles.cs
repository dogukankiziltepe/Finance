using Finance.Domain.Entities.Auth;
using Finance.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Entities.Menus
{
    public class MenuRoles:BaseEntity
    {
        public Menu Menu { get; set; }
        public Role Role { get; set; }
    }
}
