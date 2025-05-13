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
        .HasColumnType("nvarchar(100)");
      builder.Property(p => p.Summary)
        .IsRequired()
        .HasColumnType("nvarchar(500)");
      builder.Property(p => p.Content)
        .IsRequired()
        .HasColumnType("nvarchar(max)");
      builder.Property(p => p.ImageUrl)
        .IsRequired();
      builder.Property(p => p.ShowCase)
        .HasDefaultValue(false);

      builder.HasData(
        new Post
        {
          Id = 1,
          CategoryId = 1,
          UserId = 1,
          Title = "HTML",
          Summary = "Etiketleme dili",
          Content = "HTML, web sayfalarını yapılandırmak için kullanılan temel bir işaretleme dilidir. Her içerik bir etiket ile başlar ve biter.",
          ImageUrl = "/images/image1.jpeg",
          ShowCase = true
        },
        new Post
        {
          Id = 2,
          CategoryId = 1,
          UserId = 2,
          Title = "CSS",
          Summary = "Tasarım dili",
          Content = "CSS, HTML elemanlarının görünümünü düzenlemek için kullanılır. Renkler, yazı tipleri ve yerleşim düzenleri gibi görsel öğeleri belirler.",
          ImageUrl = "/images/image2.jpeg",
          ShowCase = true
        },
        new Post
        {
          Id = 3,
          CategoryId = 1,
          UserId = 3,
          Title = "JavaScript",
          Summary = "Dinamiklik katar",
          Content = "JavaScript, web sayfalarına etkileşim ve dinamik özellikler kazandırmak için kullanılan bir programlama dilidir. Olay yönetimi, DOM manipülasyonu ve API çağrıları gibi işlemleri gerçekleştirir.",
          ImageUrl = "/images/image3.jpeg"
        },
        new Post
        {
          Id = 4,
          CategoryId = 2,
          UserId = 4,
          Title = "Makine Öğrenimi",
          Summary = "Veriden öğrenme",
          Content = "Makine öğrenimi, verilerden örüntüleri tespit ederek öğrenen algoritmaların geliştirilmesini sağlar. Supervised, unsupervised ve reinforcement learning gibi türleri vardır.",
          ImageUrl = "/images/image4.jpeg"
        },
        new Post
        {
          Id = 5,
          CategoryId = 2,
          UserId = 5,
          Title = "Yapay Sinir Ağları",
          Summary = "İnsan beyninden ilham",
          Content = "Yapay sinir ağları, biyolojik sinir ağlarından esinlenilerek geliştirilen algoritmalardır. Derin öğrenme ile birlikte popüler hale gelmiştir.",
          ImageUrl = "/images/image5.jpeg",
          ShowCase = true
        },
        new Post
        {
          Id = 6,
          CategoryId = 3,
          UserId = 6,
          Title = "Akıllı Telefonlar",
          Summary = "Mobil teknoloji",
          Content = "Akıllı telefonlar, iletişimin ötesinde çok işlevli cihazlardır. Uygulamalar, kameralar ve internet bağlantısı gibi pek çok özellik sunar.",
          ImageUrl = "/images/image6.jpeg"
        },
        new Post
        {
          Id = 7,
          CategoryId = 3,
          UserId = 1,
          Title = "Yapay Zeka ile Nesne Tanıma",
          Summary = "Görüntü işlemede devrim",
          Content = "Nesne tanıma, görüntülerdeki nesneleri tanımlamak için yapay zekayı kullanır. Derin öğrenme ve konvolüsyonel sinir ağları bu alanda önemli rol oynar.",
          ImageUrl = "/images/image7.jpeg"
        },
        new Post
        {
          Id = 8,
          CategoryId = 4,
          UserId = 2,
          Title = "Borsa Nedir?",
          Summary = "Yatırım piyasası",
          Content = "Borsa, menkul kıymetlerin alınıp satıldığı bir piyasadır. Hisse senetleri, tahviller ve yatırım fonları gibi finansal araçlar işlem görür.",
          ImageUrl = "/images/image8.jpeg",
          ShowCase = true
        },
        new Post
        {
          Id = 9,
          CategoryId = 4,
          UserId = 3,
          Title = "Kripto Paralar",
          Summary = "Dijital para birimleri",
          Content = "Kripto paralar, merkeziyetsiz, blockchain teknolojisine dayalı dijital para birimleridir. Bitcoin ve Ethereum en bilinen örneklerdendir.",
          ImageUrl = "/images/image9.jpeg"
        },
        new Post
        {
          Id = 10,
          CategoryId = 5,
          UserId = 4,
          Title = "Online Eğitim",
          Summary = "Erişilebilir öğrenim",
          Content = "Online eğitim, internet üzerinden bilgi edinmeyi mümkün kılar. Platformlar sayesinde zaman ve mekândan bağımsız öğrenim sağlanır.",
          ImageUrl = "/images/image10.jpeg"
        },
        new Post
        {
          Id = 11,
          CategoryId = 5,
          UserId = 5,
          Title = "Eğitimde Teknoloji",
          Summary = "Dijital araçlar",
          Content = "Eğitim teknolojileri, sınıflarda interaktif tahtalar, mobil uygulamalar ve online içerikler gibi araçların kullanımını kapsar.",
          ImageUrl = "/images/image11.jpeg"
        },
        new Post
        {
          Id = 12,
          CategoryId = 6,
          UserId = 6,
          Title = "Zaman Yönetimi",
          Summary = "Verimli yaşam",
          Content = "Zaman yönetimi, günlük görevleri planlayarak daha üretken olmayı sağlar. Ajanda tutmak ve önceliklendirme bu konuda etkilidir.",
          ImageUrl = "/images/image12.jpeg"
        },
        new Post
        {
          Id = 13,
          CategoryId = 6,
          UserId = 1,
          Title = "Alışkanlık Kazanmak",
          Summary = "İrade gücü",
          Content = "Pozitif alışkanlıklar kazanmak, kişisel gelişimin temelidir. 21 gün kuralı ve tekrarlama alışkanlık edinmede etkilidir.",
          ImageUrl = "/images/image13.jpeg",
          ShowCase = true
        },
        new Post
        {
          Id = 14,
          CategoryId = 7,
          UserId = 2,
          Title = "Osmanlı Tarihi",
          Summary = "600 yıllık imparatorluk",
          Content = "Osmanlı İmparatorluğu, 1299’dan 1922’ye kadar hüküm süren çok uluslu bir devletti. Avrupa, Asya ve Afrika kıtalarında topraklara sahipti.",
          ImageUrl = "/images/image14.jpeg",
          ShowCase = true
        },
        new Post
        {
          Id = 15,
          CategoryId = 7,
          UserId = 3,
          Title = "Cumhuriyetin Kuruluşu",
          Summary = "Yeni bir dönem",
          Content = "Türkiye Cumhuriyeti, 1923 yılında Mustafa Kemal Atatürk önderliğinde kuruldu. Laiklik, eğitim reformları ve sanayileşme bu dönemin temelidir.",
          ImageUrl = "/images/image15.jpeg"
        },
        new Post
        {
          Id = 16,
          CategoryId = 8,
          UserId = 4,
          Title = "Modern Sanat",
          Summary = "Yorumlara açık",
          Content = "Modern sanat, geleneksel sanat anlayışının dışına çıkarak yenilikçi ve özgür anlatımları kapsar. Dadaizm, kübizm gibi akımlar buna örnektir.",
          ImageUrl = "/images/image16.jpeg"
        },
        new Post
        {
          Id = 17,
          CategoryId = 8,
          UserId = 5,
          Title = "Rönesans Dönemi",
          Summary = "Sanatın altın çağı",
          Content = "Rönesans, Avrupa’da sanat, bilim ve düşünce alanında büyük ilerlemelerin yaşandığı bir dönemdir. Leonardo da Vinci ve Michelangelo gibi sanatçılar bu dönemde yetişmiştir.",
          ImageUrl = "/images/image17.jpeg"
        },
        new Post
        {
          Id = 18,
          CategoryId = 9,
          UserId = 6,
          Title = "Türk Edebiyatı",
          Summary = "Zengin kültürel miras",
          Content = "Türk edebiyatı, divan, halk ve modern edebiyat olmak üzere üç ana dönemde incelenir. Şiir, hikâye ve roman gibi türler öne çıkar.",
          ImageUrl = "/images/image18.jpeg",
          ShowCase = true
        },
        new Post
        {
          Id = 19,
          CategoryId = 9,
          UserId = 1,
          Title = "Roman Türü",
          Summary = "Kurgu anlatılar",
          Content = "Roman, kurmaca bir olay örgüsü etrafında gelişen edebi türdür. Karakter derinliği ve olay örgüsü romana özgü unsurlardır.",
          ImageUrl = "/images/image19.jpeg"
        },
        new Post
        {
          Id = 20,
          CategoryId = 10,
          UserId = 2,
          Title = "Video Oyunları",
          Summary = "Etkileşimli eğlence",
          Content = "Video oyunları, eğlence ve hikâye anlatımı sunan dijital medya ürünleridir. Konsollar, bilgisayarlar ve mobil cihazlar üzerinden oynanabilir.",
          ImageUrl = "/images/image20.jpeg",
          ShowCase = true
        },
        new Post
        {
          Id = 21,
          CategoryId = 10,
          UserId = 3,
          Title = "Oyun Geliştirme",
          Summary = "Yazılım ve tasarım",
          Content = "Oyun geliştirme, yazılım, grafik tasarımı ve ses gibi farklı disiplinlerin bir araya gelerek etkileşimli deneyimler oluşturduğu bir süreçtir.",
          ImageUrl = "/images/image21.jpeg"
        },
        new Post
        {
          Id = 22,
          CategoryId = 11,
          UserId = 4,
          Title = "Futbolun Tarihi",
          Summary = "Köklü geçmiş",
          Content = "Futbol, dünya genelinde en yaygın oynanan spor dallarından biridir. Modern futbolun temelleri 19. yüzyılda İngiltere'de atılmıştır.",
          ImageUrl = "/images/image22.jpeg"
        },
        new Post
        {
          Id = 23,
          CategoryId = 11,
          UserId = 5,
          Title = "Sporun Faydaları",
          Summary = "Sağlıklı yaşam",
          Content = "Düzenli spor yapmak, kalp sağlığını korur, kas gelişimini destekler ve stres seviyesini azaltır. Her yaşta yapılabilir.",
          ImageUrl = "/images/image23.jpeg",
          ShowCase = true
        },
        new Post
        {
          Id = 24,
          CategoryId = 12,
          UserId = 6,
          Title = "Beslenme Alışkanlıkları",
          Summary = "Sağlıklı yaşamın temeli",
          Content = "Dengeli ve düzenli beslenme, vücudun ihtiyaç duyduğu vitamin ve mineralleri karşılayarak sağlıklı bir yaşam sürdürülmesini sağlar.",
          ImageUrl = "/images/image24.jpeg"
        }
 );

    }
  }
}