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

      builder.Property(c => c.Name).IsRequired();

      builder.HasData(
        new Category() { Id = 1, Name = "Yazılım" },
        new Category() { Id = 2, Name = "Teknoloji" },
        new Category() { Id = 3, Name = "Oyun" },
        new Category() { Id = 4, Name = "Yapay Zeka" },
        new Category() { Id = 5, Name = "Sağlık" },
        new Category() { Id = 6, Name = "İş Dünyası" },
        new Category() { Id = 7, Name = "Finans Dünyası" },
        new Category() { Id = 8, Name = "Tarih" },
        new Category() { Id = 9, Name = "Sanat" },
        new Category() { Id = 10, Name = "Kişisel Gelişim" }
      );
    }
  }
}