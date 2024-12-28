using AccountManager.Application.Repositories;
using AccountManager.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManager.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IResourceRepository, ResourceRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
        }
    }
}