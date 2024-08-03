using Finance.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Entities.Auth
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public Role Role { get; set; }
    }
}
