using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UIWeb.Migrations
{
    public partial class startPointWithData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(24)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShowCase = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.UserId, x.PostId });
                    table.ForeignKey(
                        name: "FK_Likes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, "Yazılım", null },
                    { 2, null, "Yapay Zeka", null },
                    { 3, null, "Teknoloji", null },
                    { 4, null, "Finans", null },
                    { 5, null, "Eğitim", null },
                    { 6, null, "Kişisel Gelişim", null },
                    { 7, null, "Tarih", null },
                    { 8, null, "Sanat", null },
                    { 9, null, "Edebiyat", null },
                    { 10, null, "Oyun", null },
                    { 11, null, "Spor", null },
                    { 12, null, "Sağlık", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "UserName" },
                values: new object[,]
                {
                    { 1, "Arbores" },
                    { 2, "Surgens" },
                    { 3, "Tenebris" },
                    { 4, "Luminis" },
                    { 5, "Ignitus" },
                    { 6, "Gelidus" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "DeletedAt", "ImageUrl", "ShowCase", "Summary", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "HTML, web sayfalarını yapılandırmak için kullanılan temel bir işaretleme dilidir. Her içerik bir etiket ile başlar ve biter.", null, "/images/image1.jpeg", true, "Etiketleme dili", "HTML", null, 1 },
                    { 2, 1, "CSS, HTML elemanlarının görünümünü düzenlemek için kullanılır. Renkler, yazı tipleri ve yerleşim düzenleri gibi görsel öğeleri belirler.", null, "/images/image2.jpeg", true, "Tasarım dili", "CSS", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "DeletedAt", "ImageUrl", "Summary", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 3, 1, "JavaScript, web sayfalarına etkileşim ve dinamik özellikler kazandırmak için kullanılan bir programlama dilidir. Olay yönetimi, DOM manipülasyonu ve API çağrıları gibi işlemleri gerçekleştirir.", null, "/images/image3.jpeg", "Dinamiklik katar", "JavaScript", null, 3 },
                    { 4, 2, "Makine öğrenimi, verilerden örüntüleri tespit ederek öğrenen algoritmaların geliştirilmesini sağlar. Supervised, unsupervised ve reinforcement learning gibi türleri vardır.", null, "/images/image4.jpeg", "Veriden öğrenme", "Makine Öğrenimi", null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "DeletedAt", "ImageUrl", "ShowCase", "Summary", "Title", "UpdatedAt", "UserId" },
                values: new object[] { 5, 2, "Yapay sinir ağları, biyolojik sinir ağlarından esinlenilerek geliştirilen algoritmalardır. Derin öğrenme ile birlikte popüler hale gelmiştir.", null, "/images/image5.jpeg", true, "İnsan beyninden ilham", "Yapay Sinir Ağları", null, 5 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "DeletedAt", "ImageUrl", "Summary", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 6, 3, "Akıllı telefonlar, iletişimin ötesinde çok işlevli cihazlardır. Uygulamalar, kameralar ve internet bağlantısı gibi pek çok özellik sunar.", null, "/images/image6.jpeg", "Mobil teknoloji", "Akıllı Telefonlar", null, 6 },
                    { 7, 3, "Nesne tanıma, görüntülerdeki nesneleri tanımlamak için yapay zekayı kullanır. Derin öğrenme ve konvolüsyonel sinir ağları bu alanda önemli rol oynar.", null, "/images/image7.jpeg", "Görüntü işlemede devrim", "Yapay Zeka ile Nesne Tanıma", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "DeletedAt", "ImageUrl", "ShowCase", "Summary", "Title", "UpdatedAt", "UserId" },
                values: new object[] { 8, 4, "Borsa, menkul kıymetlerin alınıp satıldığı bir piyasadır. Hisse senetleri, tahviller ve yatırım fonları gibi finansal araçlar işlem görür.", null, "/images/image8.jpeg", true, "Yatırım piyasası", "Borsa Nedir?", null, 2 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "DeletedAt", "ImageUrl", "Summary", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 9, 4, "Kripto paralar, merkeziyetsiz, blockchain teknolojisine dayalı dijital para birimleridir. Bitcoin ve Ethereum en bilinen örneklerdendir.", null, "/images/image9.jpeg", "Dijital para birimleri", "Kripto Paralar", null, 3 },
                    { 10, 5, "Online eğitim, internet üzerinden bilgi edinmeyi mümkün kılar. Platformlar sayesinde zaman ve mekândan bağımsız öğrenim sağlanır.", null, "/images/image10.jpeg", "Erişilebilir öğrenim", "Online Eğitim", null, 4 },
                    { 11, 5, "Eğitim teknolojileri, sınıflarda interaktif tahtalar, mobil uygulamalar ve online içerikler gibi araçların kullanımını kapsar.", null, "/images/image11.jpeg", "Dijital araçlar", "Eğitimde Teknoloji", null, 5 },
                    { 12, 6, "Zaman yönetimi, günlük görevleri planlayarak daha üretken olmayı sağlar. Ajanda tutmak ve önceliklendirme bu konuda etkilidir.", null, "/images/image12.jpeg", "Verimli yaşam", "Zaman Yönetimi", null, 6 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "DeletedAt", "ImageUrl", "ShowCase", "Summary", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 13, 6, "Pozitif alışkanlıklar kazanmak, kişisel gelişimin temelidir. 21 gün kuralı ve tekrarlama alışkanlık edinmede etkilidir.", null, "/images/image13.jpeg", true, "İrade gücü", "Alışkanlık Kazanmak", null, 1 },
                    { 14, 7, "Osmanlı İmparatorluğu, 1299’dan 1922’ye kadar hüküm süren çok uluslu bir devletti. Avrupa, Asya ve Afrika kıtalarında topraklara sahipti.", null, "/images/image14.jpeg", true, "600 yıllık imparatorluk", "Osmanlı Tarihi", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "DeletedAt", "ImageUrl", "Summary", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 15, 7, "Türkiye Cumhuriyeti, 1923 yılında Mustafa Kemal Atatürk önderliğinde kuruldu. Laiklik, eğitim reformları ve sanayileşme bu dönemin temelidir.", null, "/images/image15.jpeg", "Yeni bir dönem", "Cumhuriyetin Kuruluşu", null, 3 },
                    { 16, 8, "Modern sanat, geleneksel sanat anlayışının dışına çıkarak yenilikçi ve özgür anlatımları kapsar. Dadaizm, kübizm gibi akımlar buna örnektir.", null, "/images/image16.jpeg", "Yorumlara açık", "Modern Sanat", null, 4 },
                    { 17, 8, "Rönesans, Avrupa’da sanat, bilim ve düşünce alanında büyük ilerlemelerin yaşandığı bir dönemdir. Leonardo da Vinci ve Michelangelo gibi sanatçılar bu dönemde yetişmiştir.", null, "/images/image17.jpeg", "Sanatın altın çağı", "Rönesans Dönemi", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "DeletedAt", "ImageUrl", "ShowCase", "Summary", "Title", "UpdatedAt", "UserId" },
                values: new object[] { 18, 9, "Türk edebiyatı, divan, halk ve modern edebiyat olmak üzere üç ana dönemde incelenir. Şiir, hikâye ve roman gibi türler öne çıkar.", null, "/images/image18.jpeg", true, "Zengin kültürel miras", "Türk Edebiyatı", null, 6 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "DeletedAt", "ImageUrl", "Summary", "Title", "UpdatedAt", "UserId" },
                values: new object[] { 19, 9, "Roman, kurmaca bir olay örgüsü etrafında gelişen edebi türdür. Karakter derinliği ve olay örgüsü romana özgü unsurlardır.", null, "/images/image19.jpeg", "Kurgu anlatılar", "Roman Türü", null, 1 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "DeletedAt", "ImageUrl", "ShowCase", "Summary", "Title", "UpdatedAt", "UserId" },
                values: new object[] { 20, 10, "Video oyunları, eğlence ve hikâye anlatımı sunan dijital medya ürünleridir. Konsollar, bilgisayarlar ve mobil cihazlar üzerinden oynanabilir.", null, "/images/image20.jpeg", true, "Etkileşimli eğlence", "Video Oyunları", null, 2 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "DeletedAt", "ImageUrl", "Summary", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 21, 10, "Oyun geliştirme, yazılım, grafik tasarımı ve ses gibi farklı disiplinlerin bir araya gelerek etkileşimli deneyimler oluşturduğu bir süreçtir.", null, "/images/image21.jpeg", "Yazılım ve tasarım", "Oyun Geliştirme", null, 3 },
                    { 22, 11, "Futbol, dünya genelinde en yaygın oynanan spor dallarından biridir. Modern futbolun temelleri 19. yüzyılda İngiltere'de atılmıştır.", null, "/images/image22.jpeg", "Köklü geçmiş", "Futbolun Tarihi", null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "DeletedAt", "ImageUrl", "ShowCase", "Summary", "Title", "UpdatedAt", "UserId" },
                values: new object[] { 23, 11, "Düzenli spor yapmak, kalp sağlığını korur, kas gelişimini destekler ve stres seviyesini azaltır. Her yaşta yapılabilir.", null, "/images/image23.jpeg", true, "Sağlıklı yaşam", "Sporun Faydaları", null, 5 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "DeletedAt", "ImageUrl", "Summary", "Title", "UpdatedAt", "UserId" },
                values: new object[] { 24, 12, "Dengeli ve düzenli beslenme, vücudun ihtiyaç duyduğu vitamin ve mineralleri karşılayarak sağlıklı bir yaşam sürdürülmesini sağlar.", null, "/images/image24.jpeg", "Sağlıklı yaşamın temeli", "Beslenme Alışkanlıkları", null, 6 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "DeletedAt", "PostId", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, "Bu konuda daha fazla bilgiye ihtiyaç var.", null, 8, "Çok Bilgilendirici", null, 3 },
                    { 2, "Kapsamlı ve detaylı olmuş.", null, 21, "Emeğe Saygı", null, 3 },
                    { 3, "Bu yazı sayesinde konuyu anladım.", null, 14, "Daha İyi Olabilir", null, 2 },
                    { 4, "Faydalı bir içerik, teşekkürler.", null, 5, "Beğendim", null, 1 },
                    { 5, "Kaynak eksikliği dikkatimi çekti.", null, 13, "Eksikler Var", null, 5 },
                    { 6, "Serinin devamını bekliyorum.", null, 2, "Devamı Gelmeli", null, 4 },
                    { 7, "Bazı yerler çok aydınlatıcı.", null, 11, "Güzel Noktalara Değinilmiş", null, 1 },
                    { 8, "Beklentimi tam karşılamadı.", null, 22, "Yetersiz", null, 2 },
                    { 9, "Her şey yerli yerinde.", null, 19, "Çok İyi", null, 6 },
                    { 10, "Daha sade anlatılabilirdi.", null, 7, "Karışık", null, 2 },
                    { 11, "İçerik çok işime yaradı.", null, 24, "Yararlı Oldu", null, 3 },
                    { 12, "Anlatım tarzı hoşuma gitti.", null, 9, "Etkileyici", null, 5 },
                    { 13, "Basit ve anlaşılır bir dil kullanılmış.", null, 1, "Anlaşılır", null, 4 },
                    { 14, "Not aldım, tekrar okuyacağım.", null, 17, "Tekrar Okuyacağım", null, 6 },
                    { 15, "Daha fazla kaynak eklense iyi olurdu.", null, 18, "Yetersiz Kaynak", null, 1 },
                    { 16, "Dolu dolu bir içerik olmuş.", null, 10, "Harika", null, 2 },
                    { 17, "Bazı kısımlar konuyla alakasız.", null, 6, "Konu Dışı", null, 5 },
                    { 18, "Başlık çok dikkatimi çekti.", null, 12, "Dikkat Çekici", null, 3 },
                    { 19, "Biraz daha sadeleştirilmeli.", null, 16, "Çok Teknik", null, 4 },
                    { 20, "Bazı konular kafamda oturmadı.", null, 4, "Sorularım Var", null, 6 },
                    { 21, "Gayet açık bir anlatım.", null, 3, "Sade ve Net", null, 3 },
                    { 22, "Seri haline getirilmeli.", null, 23, "Devamını Bekliyorum", null, 1 },
                    { 23, "Dil kullanımı rahatsız edici.", null, 15, "Hoş Değil", null, 2 },
                    { 24, "Faydalı bilgiler içeriyor.", null, 20, "Yeni Şeyler Öğrendim", null, 4 },
                    { 25, "Her şey ayrıntılı anlatılmış.", null, 14, "Çok Detaylı", null, 5 },
                    { 26, "Konuyla ilgilenmiyorum.", null, 11, "İlgimi Çekmedi", null, 6 },
                    { 27, "Yazım hataları dikkatimi dağıttı.", null, 22, "Yazım Hataları Var", null, 1 },
                    { 28, "Bazı eksikler var ama iyi bir başlangıç.", null, 9, "Geliştirilebilir", null, 2 },
                    { 29, "Okurken zorlanmadım.", null, 5, "Okunabilirlik İyi", null, 3 },
                    { 30, "Ne uzun ne kısa, tam kararında.", null, 8, "Kısa ve Öz", null, 4 },
                    { 31, "İçerik özgün mü emin değilim.", null, 13, "Kopya Gibi", null, 5 },
                    { 32, "Bazı yerler çıkarılabilir.", null, 21, "Gereksiz Bilgiler", null, 6 },
                    { 33, "Güzel toparlanmış bir yazı.", null, 2, "İyi Hazırlanmış", null, 1 },
                    { 34, "Bazı kısımlar farklı yorumlanabilir.", null, 6, "Tartışmalı", null, 2 },
                    { 35, "Alışılmışın dışında bir yaklaşım.", null, 7, "Farklı Bakış", null, 3 },
                    { 36, "Okurken sıkıldım.", null, 12, "Sıkıcı", null, 4 },
                    { 37, "Bu terimi ilk defa duydum.", null, 16, "Yeni Öğrendim", null, 5 },
                    { 38, "Emeğinize sağlık.", null, 17, "Başarılı", null, 6 },
                    { 39, "Konuyu derinlemesine işlememiş.", null, 10, "Zayıf", null, 1 },
                    { 40, "Çok derin bir anlam içeriyor.", null, 1, "Anlamlı", null, 2 },
                    { 41, "İlk paragraf çok güçlüydü.", null, 3, "İlgi Çekici", null, 3 },
                    { 42, "Kaynak listesi olmalıydı.", null, 19, "Daha Fazla Kaynak", null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "DeletedAt", "PostId", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 43, "Şüphe bırakmamış.", null, 24, "Net Bilgi", null, 5 },
                    { 44, "İlk cümle çok etkileyiciydi.", null, 18, "Giriş Güzel", null, 6 },
                    { 45, "Yazardan etkilendim.", null, 4, "Konuya Hakim", null, 1 },
                    { 46, "Cümleler çok uzun.", null, 20, "Okuması Zor", null, 2 },
                    { 47, "Genel olarak beğendim.", null, 23, "Oldukça İyi", null, 3 },
                    { 48, "Böyle içerikler çoğalsın.", null, 15, "Devam Et", null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "PostId", "UserId", "DeletedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, null, null },
                    { 2, 1, null, null },
                    { 12, 1, null, null },
                    { 18, 1, null, null },
                    { 2, 2, null, null },
                    { 3, 2, null, null },
                    { 4, 2, null, null },
                    { 13, 2, null, null },
                    { 19, 2, null, null },
                    { 1, 3, null, null },
                    { 5, 3, null, null },
                    { 14, 3, null, null },
                    { 20, 3, null, null },
                    { 6, 4, null, null },
                    { 7, 4, null, null },
                    { 15, 4, null, null },
                    { 21, 4, null, null },
                    { 8, 5, null, null },
                    { 9, 5, null, null },
                    { 16, 5, null, null },
                    { 22, 5, null, null },
                    { 10, 6, null, null },
                    { 11, 6, null, null },
                    { 17, 6, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
