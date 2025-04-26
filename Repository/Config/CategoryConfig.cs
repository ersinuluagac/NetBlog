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
        new Category() { Id = 2, Name = "Tarih" }
      );
    }
  }
}