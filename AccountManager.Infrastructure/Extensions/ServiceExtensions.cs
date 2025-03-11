using AccountManager.Application.Repositories;
using AccountManager.Infrastructure.Context;
using AccountManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace AccountManager.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            string specialFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string dbPath = Path.Combine(specialFolder, "AccountManager", "accountmanager.db");

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