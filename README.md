# NetBlog

## Proje Açıklaması
"NetBlog" projesi BilgeAdam Akademi tarafından verilen **"Full Stack .NET Geliştirme"** eğitimi için bitirme projesi olarak hazırlanmıştır.  

Kullanıcılar için:  
- Üye olma  
- Gönderileri yorumlayabilme  
- Beğenebilme  

Editör kullanıcıları için:  
- Panel üzerinden gönderileri inceleyebilme  

Admin kullanıcıları için:  
- Panel üzerinden kullanıcıları ve gönderileri inceleyebilme  

## Kullanılan Teknolojiler

- **Programlama Dili:** C#, Razor Pages, JavaScript (bazı özellikler için)  
- **Framework / Kütüphane:**  
  - ASP.NET MVC  
  - Entity Framework Core  
  - AutoMapper  
  - Identity  
- **Veri Tabanı:** SQL Server  


## Proje Yapısı
```
/NetBlog
  /Core
    /Dtos
    /Models
    /RequestParameters
  /Repository
    /Config
    /Contexts
    /Extensions
    /Implementations
    /Interfaces
    /UnitOfWork
  /Service
    /Implementations
    /Interfaces
    /UnitOfWork
  /UIWeb
    /Areas
      /Admin
    /Components
    /Controllers
    /Infrastructure
    /Migrations
    /Models
    /Pages
    /Views
```

## Kurulum & Çalıştırma

1. Repoyu klonlayın.
2. Gerekli bağımlılıkları yükleyin (NuGet üzerinden otomatik)
3. `appsettings.json` içinden connection stringi güncelleyin.
4. Bekleyen migrationlar proje çalıştığı zaman otomatik uygulanır.
