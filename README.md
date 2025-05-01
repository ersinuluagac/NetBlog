# NetBlog
## 0 Prensipler & Teknoloyiler
- **Dependency Injection**
- **Inversion of Control**
- **Unit of Work**
---
- **Identity**
- **Entity**
- **LINQ**
- **Fluent API**
- **Tag Helper**
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
## 3 Core & Repository Katmanının Oluşturulması
- Models klasörü Core katmanına taşındı, context ise Repository katmanına taşındı.
- Temel CRUD işlemleri için BaseRepository oluşturuldu.
- Özel işlemler için PostRepository oluşturuldu.
- RepositoryManager ile UnitOfWork yapısı hazırlandı.
- Expression ile LINQ sorguları yapılabilir halde Repository classları için yeni metotlar yazıldı.
## 4 Service Katmanının Oluşturulması
- Temel modeler için Service katmanında CategoryService ve PostService oluştuldu.
- Unit of Work yapısı için ServiceManager hazırlandı.
## 5 Components (Bileşenler)
- ViewComponent kullanımı için temel bir gönderi sayısı dönen PostSummaryViewComponent oluşturuldu.
## 6 Areas (Alanlar)
- Admin area oluşturuldu ve sayfa tasarımı buna göre değiştirildi.
- Admin area ile birlikte CRUD işlemleri için gerekli metotlar oluşturuldu.
## 7 AutoMapper
- Deneme modelleri arasındaki ilişkiler belirlendi.
- ViewBag ile kategoriler, gönderi oluşturma sayfasına SelectList olarak gönderildi.
## 8 Dosya
- Görseller için dosya işlemleri yapıldı.
## 9 Razor Pages
- About ve Contact sayfaları Razor Page olarak tasarlandı.