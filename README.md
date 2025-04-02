# NetBlog
## 0 Prensipler
- **Dependency Injection**
- **Inversion of Control**
## 1 Projenin Oluşturulması & Çalıştırılması
- "ASP.NET Core Empty" projesi başlatıldı.
- "MVC Pattern" uygulandı.
- Veri tabanı (MSSQLServer) işlemleri yapıldı.
- Gerekli paketler "NuGet Package Manager" aracılığıyla projeye eklendi.
- Projeyi çalıştırmak geçici "DbContext" ve "DbSet" ayarları yapıldı.
- "ConnectionString" belirlendi.
- İlk "Migration" alındı.
## 2 Layout Hazırlıkları
- Temel "_Layout" görünümü hazırlandı.
- "_ViewStart"a _Layout görünümü eklendi.
- "_ViewImports" ile görünümlerde kullanılacak dosya yolları eklendi.
- "TagHelpers" kullanarak "_Navbar" "Partial View"ı oluşturuldu.
- "Model" kullanılarak "_PostCard" "Partial View"ı oluşturuldu.
- "wwwroot" klasörü oluşturuldu ve "Program.cs"e kaydı yapıldı.
- "libman" aracılığı ile Bootstrap, FontAwesome ve JQuery projeye klasörüne eklendi.
- "_Layout"a Bootstrap, JQuery ve FontAwesome kayıtları yapıldı.