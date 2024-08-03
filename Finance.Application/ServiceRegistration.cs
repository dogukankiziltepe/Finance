using Finance.Domain.Entities.Agreements;
using Finance.Domain.Entities.Companies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Finance.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistenceLayer(configuration);
            return services;
        }
    }
}
