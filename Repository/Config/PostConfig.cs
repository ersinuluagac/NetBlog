using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
  public class PostConfig : IEntityTypeConfiguration<Post>
  {
    public void Configure(EntityTypeBuilder<Post> builder)
    {
      builder.HasKey(p => p.Id);

      builder.HasOne(p => p.Category)
        .WithMany(c => c.Posts)
        .HasForeignKey(p => p.CategoryId)
        .OnDelete(DeleteBehavior.Restrict);
      builder.HasOne(p => p.User)
        .WithMany(u => u.Posts)
        .HasForeignKey(p => p.UserId)
        .OnDelete(DeleteBehavior.Restrict);
      builder.HasMany(p => p.Comments)
        .WithOne(c => c.Post)
        .HasForeignKey(c => c.PostId)
        .OnDelete(DeleteBehavior.Restrict);
      builder.HasMany(p => p.Likes)
        .WithOne(l => l.Post)
        .HasForeignKey(l => l.PostId)
        .OnDelete(DeleteBehavior.Restrict);


      builder.Property(p => p.Title)
        .IsRequired()
        .HasColumnType("nvarchar(24)");
      builder.Property(p => p.Summary)
        .IsRequired()
        .HasColumnType("nvarchar(150)");
      builder.Property(p => p.Content)
        .IsRequired()
        .HasColumnType("nvarchar(max)");
      builder.Property(p => p.ImageUrl)
        .IsRequired(false);
    }
  }
}