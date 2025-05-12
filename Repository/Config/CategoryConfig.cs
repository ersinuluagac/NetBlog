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
        .OnDelete(DeleteBehavior.Restrict);;

      builder.HasData(
          new Category() { Id = 1, Name = "Yazılım" },
          new Category() { Id = 2, Name = "Yapay Zeka" },
          new Category() { Id = 3, Name = "Teknoloji" },
          new Category() { Id = 4, Name = "Finans" },
          new Category() { Id = 5, Name = "Eğitim" },
          new Category() { Id = 6, Name = "Kişisel Gelişim" },
          new Category() { Id = 7, Name = "Tarih" },
          new Category() { Id = 8, Name = "Sanat" },
          new Category() { Id = 9, Name = "Edebiyat" },
          new Category() { Id = 10, Name = "Oyun" },
          new Category() { Id = 11, Name = "Spor" },
          new Category() { Id = 12, Name = "Sağlık" }
      );

    }
  }
}