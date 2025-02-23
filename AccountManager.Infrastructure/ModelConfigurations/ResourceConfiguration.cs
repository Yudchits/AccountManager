using AccountManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManager.Infrastructure.ModelConfigurations
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("Resources");

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .ValueGeneratedOnAdd();

            builder.Property(r => r.Name)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(r => r.ImagePath)
                .HasMaxLength(512)
                .IsRequired();

            builder.HasOne(r => r.User)
                .WithMany(u => u.Resources)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Accounts)
                .WithOne(a => a.Resource)
                .HasForeignKey(a => a.ResourceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}