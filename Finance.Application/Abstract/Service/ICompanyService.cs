using Finance.Application.Models.Company;
using Finance.Application.Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Abstract.Service
{
    public interface ICompanyService
    {
        /// <summary>
        /// İş ortakları getirme
        /// </summary>
        /// <param name="model">İş ortakları getirme filtreleme modeli</param>
        /// <returns></returns>
        public Task<List<CompanyResponseModel>> GetCompanies(CompanyGetListModel model);
        /// <summary>
        /// İş ortağı id'sine göre iş ortağı getirme
        /// </summary>
        /// <param name="companyId">İş ortağı Id</param>
        /// <returns></returns>
        public Task<CompanyResponseModel> GetCompany(string companyId);
    }
}
