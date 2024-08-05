using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Models.Agreement
{
    public class AgreementResponseModel
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RiskValue { get; set; }
    }
}
