using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nubimetrics_Challenge.WebApi.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Nubimetrics Challenge - MercadoLibre",
                    Description = "Proceso de Selección Nubimetrics.",
                    Version = "v1"
                });
            });

            return services;
        }

        public static IApplicationBuilder ApplySwagger(this IApplicationBuilder builder, IConfiguration configuration)
        {
            builder.UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint($"{configuration["App:ServerRootAddress"]}" + "swagger/v1/swagger.json", "Nubimetrics Challenge - MercadoLibre");
                });

            return builder;
        }
    }
}
