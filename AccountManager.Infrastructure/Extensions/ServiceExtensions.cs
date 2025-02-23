using AccountManager.Application.Repositories;
using AccountManager.Infrastructure.Context;
using AccountManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManager.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            /*services.AddDbContext<AccountManagerContext>(options =>
            {
                options.UseSqlite(@"Data Source=AccountManager.Infrastructure/App_Data/accountmanager.db");
            });*/

            services.AddTransient<IResourceRepository, ResourceRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}