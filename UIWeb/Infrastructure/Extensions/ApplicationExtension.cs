using Microsoft.EntityFrameworkCore;
using Repository;

namespace UIWeb.Infrastructure.Extensions
{
  public static class ApplicationExtension
  {
    /// <summary>
    /// Uygulama başlatıldığında, eğer varsa bekleyen migration'ları veritabanına uygular. Böylece manuel olarak 'Update-Database' komutu çalıştırmaya gerek kalmaz.
    /// </summary>
    /// <param name="app">SP.NET Core uygulaması için middleware yapılandırma arabirimi.</param>
    public static void CheckMigration(this IApplicationBuilder app)
    {
      // Uygulama servislerinden RepositoryContext (DbContext) alınır.
      RepositoryContext context = app
        .ApplicationServices // Tüm registered servisleri alır
        .CreateScope() // Yeni bir scope oluşturur (özellikle scoped servisler için)
        .ServiceProvider // O scope içerisindeki servis sağlayıcısı
        .GetRequiredService<RepositoryContext>(); // RepositoryContext çekilir (DbContext)

      // Bekleyen migration varsa veritabanını günceller.
      if (context.Database.GetPendingMigrations().Any())
        context.Database.Migrate(); // Uygulanmamış migration'lar sırayla veritabanına uygulanır
    }
  }
}