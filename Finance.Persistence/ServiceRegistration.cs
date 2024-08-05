using Finance.Application.Abstract.Service;
using Finance.Persistence.Abstract.Repositories;
using Finance.Persistence.Abstract.Service;
using Finance.Persistence.Concrete.Repositories;
using Finance.Persistence.Concrete.Service;
using Finance.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FinanceDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MSSQL")));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAgreementService, AgreementService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IAgreementRepository, AgreementRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuRoleRepository, MenuRoleRepository>();
            services.AddScoped<IConnectionRepository, ConnectionRepository>();
            return services;
        }
    }
}
