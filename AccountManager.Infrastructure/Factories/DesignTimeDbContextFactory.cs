using AccountManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System;

namespace AccountManager.Infrastructure.Factories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AccountManagerContext>
    {
        public AccountManagerContext CreateDbContext(string[] args)
        {
            string specialFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string dbPath = Path.Combine(specialFolder, "AccountManager", "accountmanager.db");

            var optionsBuilder = new DbContextOptionsBuilder<AccountManagerContext>();
            optionsBuilder.UseSqlite($"Data Source={dbPath}");

            return new AccountManagerContext(optionsBuilder.Options);
        }
    }
}