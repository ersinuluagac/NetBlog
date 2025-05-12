using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
  public class UserConfig : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.HasKey(u => u.Id);

      builder.HasMany(u => u.Posts)
        .WithOne(p => p.User)
        .HasForeignKey(p => p.UserId)
        .OnDelete(DeleteBehavior.Restrict);;
      builder.HasMany(u => u.Comments)
        .WithOne(c => c.User)
        .HasForeignKey(c => c.UserId)
        .OnDelete(DeleteBehavior.Restrict);;
      builder.HasMany(u => u.Likes)
        .WithOne(l => l.User)
        .HasForeignKey(l => l.UserId)
        .OnDelete(DeleteBehavior.Restrict);;

      builder.Property(u => u.UserName)
      .IsRequired()
      .HasColumnType("nvarchar(24)");

      builder.HasData(
          new User() { Id = 1, UserName = "Arbores" },
          new User() { Id = 2, UserName = "Surgens" },
          new User() { Id = 3, UserName = "Tenebris" },
          new User() { Id = 4, UserName = "Luminis" },
          new User() { Id = 5, UserName = "Ignitus" },
          new User() { Id = 6, UserName = "Gelidus" }
      );
    }
  }
}