using FinalBakery.Application.Contracts.Persistence;
using FinalBakery.Application.Mappings;
using FinalBakery.Infrastructure.Persistence.PostgreSQL.Repositories;
using Microsoft.EntityFrameworkCore;
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
            services.AddAutoMapper(typeof(MappingsProfile));
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IPreparationRepository, PreparationRepository>();
            services.AddScoped<IChefRepository, ChefRepository>();
            services.AddScoped<IBreadRepository, BreadRepository>();
            services.AddScoped<IBreadIngredientRepository, BreadIngredientRepository>();
            services.AddScoped<IBreadPreparationRepository, BreadPreparationRepository>();
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<IOfficeBreadRepository, OfficeBreadRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IPrepareOrderRepository, PrepareOrdersRepository>();
            services.AddScoped<ICalculateEarningsRepository, CalculateEarningsRepository>();

            return services;
        }
    }
}
