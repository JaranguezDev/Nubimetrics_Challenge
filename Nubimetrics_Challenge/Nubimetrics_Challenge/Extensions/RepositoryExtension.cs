using Microsoft.Extensions.DependencyInjection;
using Nubimetrics_Challenge.EntityFrameworkCore.Repositories.User;

namespace Nubimetrics_Challenge.WebApi.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
