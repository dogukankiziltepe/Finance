using Finance.Domain.Entities.Companies;
using Finance.Persistence.Abstract.Repositories;
using Finance.Persistence.Concrete.Generic;
using Finance.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Persistence.Concrete.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(FinanceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
