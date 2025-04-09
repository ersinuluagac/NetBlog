using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args); // Web uygulaması oluşturuluyor.

builder.Services.AddControllersWithViews(); // Controller ve view servisleri ekleniyor.
builder.Services.AddDbContext<RepositoryContext>(options => // Veritabanı bağlantısı yapılıyor.
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlConnection"), // appsettings.json dosyasındaki bağlantı bilgileri alınıyor.
    b => b.MigrationsAssembly("UIWeb")); // Migrations'ların nerde bulunacağını belirliyoruz.
});

var app = builder.Build(); // Web uygulaması servisler ile derleniyor.

app.UseStaticFiles(); // Statik dosyalar (wwwroot) kullanılıyor.
app.UseHttpsRedirection(); // HTTPS yönlendirmesi yapılıyor.
app.UseRouting(); // Yönlendirme ayarları yapılıyor.
app.MapControllerRoute( // Varsayılan controller ve action belirleniyor.
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run(); // Web uygulaması çalıştırılıyor.
