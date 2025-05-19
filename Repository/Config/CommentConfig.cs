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

      builder.Property(c => c.Title)
      .IsRequired()
      .HasColumnType("nvarchar(50)");
      builder.Property(c => c.Content)
      .IsRequired()
      .HasColumnType("nvarchar(1000)");

      builder.HasOne(c => c.User)
        .WithMany(u => u.Comments)
        .HasForeignKey(c => c.UserId)
        .OnDelete(DeleteBehavior.Restrict);
      builder.HasOne(c => c.Post)
        .WithMany(p => p.Comments)
        .HasForeignKey(c => c.PostId)
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}