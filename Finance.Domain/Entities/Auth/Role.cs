using Finance.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Entities.Auth
{
    public class Role:BaseEntity
    {
        public string Name { get; set; }
    }
}
