using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Persistence.Abstract.Repositories
{
    public interface IConnectionRepository
    {
        public Task AddConnectionAsync(string userId, string connectionId);
        public Task RemoveConnectionAsync(string userId);
        public Task<string> GetConnectionIdAsync(string userId);

    }
}
