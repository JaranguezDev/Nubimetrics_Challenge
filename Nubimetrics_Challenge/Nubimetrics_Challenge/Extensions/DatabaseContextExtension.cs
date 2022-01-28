using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nubimetrics_Challenge.EntityFrameworkCore;

namespace Nubimetrics_Challenge.WebApi.Extensions
{
    public static class DatabaseContextExtension
    {
        public static IServiceCollection ConfigureDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            var conn = configuration.GetConnectionString("Default");

            services.AddDbContextPool<NubimetricsContext>(options =>
            {
                options.UseSqlServer(conn, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly("Nubimetrics_Challenge.EntityFrameworkCore");
                });
            });

            return services;
        }
    }
}
