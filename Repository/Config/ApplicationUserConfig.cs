using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
  public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
  {
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
      builder.HasMany(u => u.Posts)
        .WithOne(p => p.User)
        .HasForeignKey(p => p.UserId)
        .OnDelete(DeleteBehavior.Restrict);
      builder.HasMany(u => u.Comments)
        .WithOne(c => c.User)
        .HasForeignKey(c => c.UserId)
        .OnDelete(DeleteBehavior.Restrict);
      builder.HasMany(u => u.Likes)
        .WithOne(l => l.User)
        .HasForeignKey(l => l.UserId)
        .OnDelete(DeleteBehavior.Restrict);
    }
  }
}