using Finance.Domain.Entities.Menus;
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
    public class MenuRoleRepository : Repository<MenuRoles>, IMenuRoleRepository
    {
        public MenuRoleRepository(FinanceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
