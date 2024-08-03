using Finance.Domain.Abstract.Generic;
using Finance.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Persistence.Concrete.Generic
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FinanceDbContext _context;

        public UnitOfWork(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
