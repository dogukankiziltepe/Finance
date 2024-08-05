using Finance.Application.Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Models.Company
{
    public class CompanyGetListModel:GetListModel
    {
        public CompanyFilter Filter { get; set; }
    }
    public class CompanyFilter
    {
        public string? Name { get; set; }
        public string? Sector { get; set; }
    }
}
