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
        .OnDelete(DeleteBehavior.Restrict);;
      builder.HasOne(c => c.Post)
        .WithMany(p => p.Comments)
        .HasForeignKey(c => c.PostId)
        .OnDelete(DeleteBehavior.Restrict);;

      builder.HasData(
          new Comment
          {
            Id = 1,
            Title = "Çok Bilgilendirici",
            Content = "Bu konuda daha fazla bilgiye ihtiyaç var.",
            UserId = 3,
            PostId = 8
          },
          new Comment
          {
            Id = 2,
            Title = "Emeğe Saygı",
            Content = "Kapsamlı ve detaylı olmuş.",
            UserId = 3,
            PostId = 21
          },
          new Comment
          {
            Id = 3,
            Title = "Daha İyi Olabilir",
            Content = "Bu yazı sayesinde konuyu anladım.",
            UserId = 2,
            PostId = 14
          },
          new Comment
          {
            Id = 4,
            Title = "Beğendim",
            Content = "Faydalı bir içerik, teşekkürler.",
            UserId = 1,
            PostId = 5
          },
          new Comment
          {
            Id = 5,
            Title = "Eksikler Var",
            Content = "Kaynak eksikliği dikkatimi çekti.",
            UserId = 5,
            PostId = 13
          },
          new Comment
          {
            Id = 6,
            Title = "Devamı Gelmeli",
            Content = "Serinin devamını bekliyorum.",
            UserId = 4,
            PostId = 2
          },
          new Comment
          {
            Id = 7,
            Title = "Güzel Noktalara Değinilmiş",
            Content = "Bazı yerler çok aydınlatıcı.",
            UserId = 1,
            PostId = 11
          },
          new Comment
          {
            Id = 8,
            Title = "Yetersiz",
            Content = "Beklentimi tam karşılamadı.",
            UserId = 2,
            PostId = 22
          },
          new Comment
          {
            Id = 9,
            Title = "Çok İyi",
            Content = "Her şey yerli yerinde.",
            UserId = 6,
            PostId = 19
          },
          new Comment
          {
            Id = 10,
            Title = "Karışık",
            Content = "Daha sade anlatılabilirdi.",
            UserId = 2,
            PostId = 7
          },
          new Comment
          {
            Id = 11,
            Title = "Yararlı Oldu",
            Content = "İçerik çok işime yaradı.",
            UserId = 3,
            PostId = 24
          },
          new Comment
          {
            Id = 12,
            Title = "Etkileyici",
            Content = "Anlatım tarzı hoşuma gitti.",
            UserId = 5,
            PostId = 9
          },
          new Comment
          {
            Id = 13,
            Title = "Anlaşılır",
            Content = "Basit ve anlaşılır bir dil kullanılmış.",
            UserId = 4,
            PostId = 1
          },
          new Comment
          {
            Id = 14,
            Title = "Tekrar Okuyacağım",
            Content = "Not aldım, tekrar okuyacağım.",
            UserId = 6,
            PostId = 17
          },
          new Comment
          {
            Id = 15,
            Title = "Yetersiz Kaynak",
            Content = "Daha fazla kaynak eklense iyi olurdu.",
            UserId = 1,
            PostId = 18
          },
          new Comment
          {
            Id = 16,
            Title = "Harika",
            Content = "Dolu dolu bir içerik olmuş.",
            UserId = 2,
            PostId = 10
          },
          new Comment
          {
            Id = 17,
            Title = "Konu Dışı",
            Content = "Bazı kısımlar konuyla alakasız.",
            UserId = 5,
            PostId = 6
          },
          new Comment
          {
            Id = 18,
            Title = "Dikkat Çekici",
            Content = "Başlık çok dikkatimi çekti.",
            UserId = 3,
            PostId = 12
          },
          new Comment
          {
            Id = 19,
            Title = "Çok Teknik",
            Content = "Biraz daha sadeleştirilmeli.",
            UserId = 4,
            PostId = 16
          },
          new Comment
          {
            Id = 20,
            Title = "Sorularım Var",
            Content = "Bazı konular kafamda oturmadı.",
            UserId = 6,
            PostId = 4
          },
          new Comment
          {
            Id = 21,
            Title = "Sade ve Net",
            Content = "Gayet açık bir anlatım.",
            UserId = 3,
            PostId = 3
          },
          new Comment
          {
            Id = 22,
            Title = "Devamını Bekliyorum",
            Content = "Seri haline getirilmeli.",
            UserId = 1,
            PostId = 23
          },
          new Comment
          {
            Id = 23,
            Title = "Hoş Değil",
            Content = "Dil kullanımı rahatsız edici.",
            UserId = 2,
            PostId = 15
          },
          new Comment
          {
            Id = 24,
            Title = "Yeni Şeyler Öğrendim",
            Content = "Faydalı bilgiler içeriyor.",
            UserId = 4,
            PostId = 20
          },
          new Comment
          {
            Id = 25,
            Title = "Çok Detaylı",
            Content = "Her şey ayrıntılı anlatılmış.",
            UserId = 5,
            PostId = 14
          },
          new Comment
          {
            Id = 26,
            Title = "İlgimi Çekmedi",
            Content = "Konuyla ilgilenmiyorum.",
            UserId = 6,
            PostId = 11
          },
          new Comment
          {
            Id = 27,
            Title = "Yazım Hataları Var",
            Content = "Yazım hataları dikkatimi dağıttı.",
            UserId = 1,
            PostId = 22
          },
          new Comment
          {
            Id = 28,
            Title = "Geliştirilebilir",
            Content = "Bazı eksikler var ama iyi bir başlangıç.",
            UserId = 2,
            PostId = 9
          },
          new Comment
          {
            Id = 29,
            Title = "Okunabilirlik İyi",
            Content = "Okurken zorlanmadım.",
            UserId = 3,
            PostId = 5
          },
          new Comment
          {
            Id = 30,
            Title = "Kısa ve Öz",
            Content = "Ne uzun ne kısa, tam kararında.",
            UserId = 4,
            PostId = 8
          },
          new Comment
          {
            Id = 31,
            Title = "Kopya Gibi",
            Content = "İçerik özgün mü emin değilim.",
            UserId = 5,
            PostId = 13
          },
          new Comment
          {
            Id = 32,
            Title = "Gereksiz Bilgiler",
            Content = "Bazı yerler çıkarılabilir.",
            UserId = 6,
            PostId = 21
          },
          new Comment
          {
            Id = 33,
            Title = "İyi Hazırlanmış",
            Content = "Güzel toparlanmış bir yazı.",
            UserId = 1,
            PostId = 2
          },
          new Comment
          {
            Id = 34,
            Title = "Tartışmalı",
            Content = "Bazı kısımlar farklı yorumlanabilir.",
            UserId = 2,
            PostId = 6
          },
          new Comment
          {
            Id = 35,
            Title = "Farklı Bakış",
            Content = "Alışılmışın dışında bir yaklaşım.",
            UserId = 3,
            PostId = 7
          },
          new Comment
          {
            Id = 36,
            Title = "Sıkıcı",
            Content = "Okurken sıkıldım.",
            UserId = 4,
            PostId = 12
          },
          new Comment
          {
            Id = 37,
            Title = "Yeni Öğrendim",
            Content = "Bu terimi ilk defa duydum.",
            UserId = 5,
            PostId = 16
          },
          new Comment
          {
            Id = 38,
            Title = "Başarılı",
            Content = "Emeğinize sağlık.",
            UserId = 6,
            PostId = 17
          },
          new Comment
          {
            Id = 39,
            Title = "Zayıf",
            Content = "Konuyu derinlemesine işlememiş.",
            UserId = 1,
            PostId = 10
          },
          new Comment
          {
            Id = 40,
            Title = "Anlamlı",
            Content = "Çok derin bir anlam içeriyor.",
            UserId = 2,
            PostId = 1
          },
          new Comment
          {
            Id = 41,
            Title = "İlgi Çekici",
            Content = "İlk paragraf çok güçlüydü.",
            UserId = 3,
            PostId = 3
          },
          new Comment
          {
            Id = 42,
            Title = "Daha Fazla Kaynak",
            Content = "Kaynak listesi olmalıydı.",
            UserId = 4,
            PostId = 19
          },
          new Comment
          {
            Id = 43,
            Title = "Net Bilgi",
            Content = "Şüphe bırakmamış.",
            UserId = 5,
            PostId = 24
          },
          new Comment
          {
            Id = 44,
            Title = "Giriş Güzel",
            Content = "İlk cümle çok etkileyiciydi.",
            UserId = 6,
            PostId = 18
          },
          new Comment
          {
            Id = 45,
            Title = "Konuya Hakim",
            Content = "Yazardan etkilendim.",
            UserId = 1,
            PostId = 4
          },
          new Comment
          {
            Id = 46,
            Title = "Okuması Zor",
            Content = "Cümleler çok uzun.",
            UserId = 2,
            PostId = 20
          },
          new Comment
          {
            Id = 47,
            Title = "Oldukça İyi",
            Content = "Genel olarak beğendim.",
            UserId = 3,
            PostId = 23
          },
          new Comment
          {
            Id = 48,
            Title = "Devam Et",
            Content = "Böyle içerikler çoğalsın.",
            UserId = 4,
            PostId = 15
          }
      );
    }
  }
}