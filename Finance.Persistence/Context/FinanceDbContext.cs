using Finance.Domain.Entities.Agreements;
using Finance.Domain.Entities.Auth;
using Finance.Domain.Entities.Common;
using Finance.Domain.Entities.Companies;
using Finance.Domain.Entities.Menus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Persistence.Context
{
    public class FinanceDbContext:DbContext
    {
        public FinanceDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        #region Auth
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuRoles> MenuRoles { get; set; }
        #endregion

        #region Company
        public DbSet<Company> Companies { get; set; }
        #endregion

        #region Agreement
        public DbSet<Agreement> Agreements { get; set; }
        #endregion

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Added:
                        data.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        data.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
