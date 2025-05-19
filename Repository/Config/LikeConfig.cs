using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
  public class LikeConfig : IEntityTypeConfiguration<Like>
  {
    public void Configure(EntityTypeBuilder<Like> builder)
    {
      builder.HasKey(l => new { l.UserId, l.PostId });
      builder.Ignore(l => l.Id);

      builder.Property(l => l.UserId)
        .IsRequired();
      builder.Property(l => l.PostId)
        .IsRequired();

      builder.HasOne(l => l.User)
        .WithMany(u => u.Likes)
        .HasForeignKey(l => l.UserId)
        .OnDelete(DeleteBehavior.Restrict);
      builder.HasOne(l => l.Post)
        .WithMany(p => p.Likes)
        .HasForeignKey(l => l.PostId)
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}