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
        .OnDelete(DeleteBehavior.Restrict);

      builder.HasData(
          new Like() { UserId = 1, PostId = 2 },
          new Like() { UserId = 2, PostId = 2 },
          new Like() { UserId = 1, PostId = 1 },
          new Like() { UserId = 2, PostId = 3 },
          new Like() { UserId = 2, PostId = 4 },
          new Like() { UserId = 3, PostId = 1 },
          new Like() { UserId = 3, PostId = 5 },
          new Like() { UserId = 4, PostId = 6 },
          new Like() { UserId = 4, PostId = 7 },
          new Like() { UserId = 5, PostId = 8 },
          new Like() { UserId = 5, PostId = 9 },
          new Like() { UserId = 6, PostId = 10 },
          new Like() { UserId = 6, PostId = 11 },
          new Like() { UserId = 1, PostId = 12 },
          new Like() { UserId = 2, PostId = 13 },
          new Like() { UserId = 3, PostId = 14 },
          new Like() { UserId = 4, PostId = 15 },
          new Like() { UserId = 5, PostId = 16 },
          new Like() { UserId = 6, PostId = 17 },
          new Like() { UserId = 1, PostId = 18 },
          new Like() { UserId = 2, PostId = 19 },
          new Like() { UserId = 3, PostId = 20 },
          new Like() { UserId = 4, PostId = 21 },
          new Like() { UserId = 5, PostId = 22 }
      );
    }
  }
}