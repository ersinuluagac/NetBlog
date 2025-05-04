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
      builder.HasOne(p => p.Category).WithMany(c => c.Posts).HasForeignKey(p => p.CategoryId);

      builder.Property(p => p.Title).IsRequired();
      builder.Property(p => p.Content).IsRequired();
      builder.Property(p => p.CategoryId).IsRequired();

      builder.HasData(
        new Post() { Id = 1, CategoryId = 1, UserId = 1, Title = "HTML", Summary = "Etiketleme", ImageUrl = "/images/html.png", Content = "HTML bir işaretleme dilidir." },
        new Post() { Id = 2, CategoryId = 1, UserId = 2, Title = "CSS", Summary = "Renklendirme", ImageUrl = "/images/css.png", Content = "CSS bir işaretleme dilidir ve HTML etiketlerine görsellik eklemek için kullanılır." },
        new Post() { Id = 3, CategoryId = 1, UserId = 1, Title = "Javascript", Summary = "Hareketlendirme", Content = "Javascript bir programlama dilidir. HTML ve CSS ile oluşturulmuş sayfalara etkileşim ve hareket katmak için kullanılır." },
        new Post() { Id = 4, CategoryId = 2, UserId = 2, Title = "İstanbul", Summary = "Megakent", Content = "Doğu Roma'nın ve Osmanlı'nın başkentidir. Önemli bir yarımadadır." },
        new Post() { Id = 5, CategoryId = 2, UserId = 1, Title = "Rusya", Summary = "Slav ülkesi", Content = "Tam olarak bilinmemekle birlikte kökenlerine dair iki farklı görüş vardır." }
      );
    }
  }
}