using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartStore.Infra.Data.SQL.Context;
using System;

namespace SmartStore.Infra.Data.SQL
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<SmartStoreDbContext>(options =>
                options.UseMySql(configuration["mysqlconnection:connectionString"], providerOptions => providerOptions.EnableRetryOnFailure()));

        }
    }
}
