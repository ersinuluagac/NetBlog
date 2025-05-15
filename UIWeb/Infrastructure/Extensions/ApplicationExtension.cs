using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace UIWeb.Infrastructure.Extensions
{
  public static class ApplicationExtension
  {
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

    public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
    {
      const string adminUser = "Admin";
      const string adminPass = "admin123";

      // UserManager
      UserManager<IdentityUser> userManager = app
        .ApplicationServices
        .CreateScope()
        .ServiceProvider
        .GetRequiredService<UserManager<IdentityUser>>();
      // RoleManager
      RoleManager<IdentityRole> roleManager = app
        .ApplicationServices
        .CreateScope()
        .ServiceProvider
        .GetRequiredService<RoleManager<IdentityRole>>();

      // Daha önce "Admin" adlı bir kullanıcı oluşturulmuş mu kontrol edilir.
      IdentityUser user = await userManager.FindByNameAsync(adminUser);
      if (user is null) // Kullanıcı yoksa yeni kullanıcı oluşturulur.
      {
        user = new IdentityUser()
        {
          Email = "ersinuluagac@gmail.com",
          EmailConfirmed = true,
          UserName = adminUser,
        };
        // Belirtilen şifreyle kullanıcı oluşturulur.
        var result = await userManager.CreateAsync(user, adminPass);
        // Kullanıcı oluşturulamadıysa hata fırlatılır.
        if (!result.Succeeded)
          throw new Exception("Admin kullanıcısı oluşturulamadı!");
        // Mevcut tüm roller kullanıcıya atanır
        var roleResult = await userManager.AddToRolesAsync(user,
          roleManager
            .Roles
            .Select(r => r.Name)
            .ToList()
        );
        // Roller atanamadıysa hata fırlatılır  
        if (!roleResult.Succeeded)
          throw new Exception("Rol taımlaması yapılamadı.");
      }
    }
  }
}