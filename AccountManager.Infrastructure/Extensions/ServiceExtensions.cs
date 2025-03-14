using AccountManager.Application.Context;
using AccountManager.Application.Repositories;
using AccountManager.Infrastructure.Context;
using AccountManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace AccountManager.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            string dbPath = Path.Combine
            (
                DirectoryContext.Instance.AppDataPath, 
                "accountmanager.db"
            );

            services.AddDbContext<AccountManagerDbContext>(options =>
            {
                options.UseSqlite($"Data Source={dbPath}");
            });

            services.AddTransient<IResourceRepository, ResourceRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserAccountBookmarkRepository, UserAccountBookmarkRepository>();
        }
    }
}