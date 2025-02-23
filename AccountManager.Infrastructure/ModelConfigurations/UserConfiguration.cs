using AccountManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManager.Infrastructure.ModelConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Login)
                .HasMaxLength(32)
                .IsRequired();

            builder.HasIndex(u => u.Login)
                .IsUnique();

            builder.Property(u => u.Password)
                .HasMaxLength(64)
                .IsRequired();

            builder.HasMany(u => u.Accounts)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Resources)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}