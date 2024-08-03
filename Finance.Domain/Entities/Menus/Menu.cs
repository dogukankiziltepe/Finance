using Finance.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Entities.Menus
{
    public class Menu:BaseEntity
    {
        public string Name { get; set; }
        public string Endpoint { get; set; }
    }
}
