using AccountManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManager.Infrastructure.ModelConfigurations
{
    public class UserAccountBookmarkConfiguration : IEntityTypeConfiguration<UserAccountBookmark>
    {
        public void Configure(EntityTypeBuilder<UserAccountBookmark> builder)
        {
            builder.ToTable("UserAccountBookmarks");

            builder.HasKey(b => new { b.UserId, b.AccountId });

            builder.HasOne(b => b.User)
                .WithMany(u => u.AccountBookmarks)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Account)
                .WithMany(a => a.Bookmarks)
                .HasForeignKey(b => b.AccountId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}