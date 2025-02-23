using AccountManager.Domain.Entities;
using AccountManager.Infrastructure.ModelConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.Infrastructure.Context
{
    public class AccountManagerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public AccountManagerContext(DbContextOptions<AccountManagerContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ResourceConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
        }
    }
}