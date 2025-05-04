using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
  public class LikeConfig : IEntityTypeConfiguration<Like>
  {
    public void Configure(EntityTypeBuilder<Like> builder)
    {
      builder.HasKey(l => l.Id);

      builder.HasData(
        new Like() { Id = 1, UserId = 1, PostId = 2 },
        new Like() { Id = 2, UserId = 2, PostId = 2 },
        new Like() { Id = 3, UserId = 1, PostId = 1 },
        new Like() { Id = 4, UserId = 2, PostId = 3 },
        new Like() { Id = 5, UserId = 2, PostId = 4 }
      );
    }
  }
}