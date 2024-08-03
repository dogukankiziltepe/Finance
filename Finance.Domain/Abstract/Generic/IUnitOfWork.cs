using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Abstract.Generic
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

    }
}
