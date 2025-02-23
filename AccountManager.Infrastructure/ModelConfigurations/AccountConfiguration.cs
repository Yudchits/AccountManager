using AccountManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManager.Infrastructure.ModelConfigurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Name)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(a => a.Login)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(a => a.Password)
                .HasMaxLength(32)
                .IsRequired();

            builder.HasOne(a => a.Resource)
                .WithMany(r => r.Accounts)
                .HasForeignKey(a => a.ResourceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.User)
                .WithMany(u => u.Accounts)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}