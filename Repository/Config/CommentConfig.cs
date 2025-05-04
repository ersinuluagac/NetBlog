using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
  public class CommentConfig : IEntityTypeConfiguration<Comment>
  {
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
      builder.HasKey(c => c.Id);

      builder.Property(c => c.Title).HasColumnType("nvarchar(50)").IsRequired();
      builder.Property(c => c.Content).IsRequired();

      builder.HasData(
        new Comment() { Id = 1, Title = "Harika!", Content = "Çok güzel bir yazı olmuş.", UserId = 1, PostId = 3 },
        new Comment() { Id = 2, Title = "Berbat", Content = "Gönderiyi hiç beğenmedim.", UserId = 2, PostId = 3 },
        new Comment() { Id = 3, Title = "İlginç", Content = "İlginç bir fikir.", UserId = 1, PostId = 2 }
      );
    }
  }
}