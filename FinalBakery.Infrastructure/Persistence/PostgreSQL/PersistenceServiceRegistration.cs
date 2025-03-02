﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL
{
    public static class PersistenceServiceRegistration
    {
        private static string GetConnectionString(IConfiguration configuration)
        {
            var postgresHost = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? configuration["Postgres:Host"];
            var postgresPort = Environment.GetEnvironmentVariable("POSTGRES_PORT") ?? configuration["Postgres:Port"];
            var postgresUser = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? configuration["Postgres:Username"];
            var postgresPassword = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? configuration["Postgres:Password"];
            var postgresDb = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? configuration["Postgres:Database"];

            return $"Host={postgresHost};Port={postgresPort};Username={postgresUser};Password={postgresPassword};Database={postgresDb}";
        }

        public static void AddDbContextPostgreSql(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = GetConnectionString(configuration);
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
                options.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
            });
        }

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContextPostgreSql(services, configuration);
            return services;
        }
    }
}
