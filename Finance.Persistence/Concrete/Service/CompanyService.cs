using Finance.Application.Abstract.Service;
using Finance.Application.Models.Agreement;
using Finance.Application.Models.Company;
using Finance.Application.Models.Search;
using Finance.Domain.Entities.Agreements;
using Finance.Persistence.Abstract.Repositories;
using Finance.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Finance.Persistence.Concrete.Service
{
    public class CompanyService(ICompanyRepository companyRepository,FinanceDbContext financeDbContext) : ICompanyService
    {
        ICompanyRepository _companyRepository = companyRepository;
        private readonly FinanceDbContext _financeDbContext = financeDbContext;

        public async Task<List<CompanyResponseModel>> GetCompanies(CompanyGetListModel model)
        {
            try
            {
                var query = _financeDbContext.Companies.AsQueryable();
                foreach (var filterProperty in typeof(AgreementFilter).GetProperties())
                {
                    var filterValue = filterProperty.GetValue(model.Filter);
                    if (filterValue != null)
                    {
                        var column = typeof(Agreement).GetProperty(filterProperty.Name);
                        if (column == null)
                        {
                            throw new ArgumentException($"Property {filterProperty.Name} not found");
                        }

                        if (column.PropertyType == typeof(string))
                        {
                            query = query.Where(x => EF.Property<string>(x, column.Name).Contains(filterValue.ToString()));
                        }
                        else
                        {
                            query = query.Where(x => EF.Property<object>(x, column.Name).Equals(filterValue));
                        }
                    }
                }
                return query.ToList().Select(x => new CompanyResponseModel
                {
                    Name = x.Name,
                    Sector = x.Sector,
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<CompanyResponseModel> GetCompany(string companyId)
        {
            var company = _companyRepository.GetById(companyId);
            return Task.FromResult(new CompanyResponseModel
            {
                Name= company.Name,
                Sector= company.Sector,
            });
        }
    }
}
