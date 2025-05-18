using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
  public class CategoryConfig : IEntityTypeConfiguration<Category>
  {
    public void Configure(EntityTypeBuilder<Category> builder)
    {
      builder.HasKey(c => c.Id);

      builder.Property(c => c.Name)
        .IsRequired()
        .HasColumnType("nvarchar(50)");

      builder.HasMany(c => c.Posts)
        .WithOne(p => p.Category)
        .HasForeignKey(p => p.CategoryId)
        .OnDelete(DeleteBehavior.Restrict);

      builder.HasData(
          new Category() { Id = 1, Name = "Yazılım" },
          new Category() { Id = 2, Name = "Tarih" },
          new Category() { Id = 3, Name = "Oyun" }
      );

    }
  }
}