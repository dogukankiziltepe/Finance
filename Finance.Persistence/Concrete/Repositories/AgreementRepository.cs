using Finance.Persistence.Abstract.Repositories;
using Finance.Domain.Entities.Agreements;
using Finance.Persistence.Concrete.Generic;
using Finance.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Persistence.Concrete.Repositories
{
    public class AgreementRepository : Repository<Agreement>, IAgreementRepository
    {
        public AgreementRepository(FinanceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
