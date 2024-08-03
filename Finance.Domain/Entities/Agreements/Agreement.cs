using Finance.Domain.Entities.Common;
using Finance.Domain.Entities.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Entities.Agreements
{
    public class Agreement:BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Company Company { get; set; }
        public decimal RiskValue { get; set; }
    }
}
