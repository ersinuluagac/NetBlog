using UIWeb.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args); // Web uygulaması oluşturuluyor.

builder.Services.AddControllersWithViews(); // Controller ve view servisleri ekleniyor.
builder.Services.AddRazorPages(); // Razor sayfaları ekleniyor.

builder.Services.ConfigureDbContext(builder.Configuration); // Extension'dan gelen veri tabanı bağlantısı.
builder.Services.ConfigureIdentity();
builder.Services.ConfigureSession(); // Extension'dan gelen session yapısı.

builder.Services.ConfigureRepositoryRegistration(); // Inversion of Control Repository
builder.Services.ConfigureServiceRegistration(); // Inversion of Control Repository

builder.Services.ConfigureRouting(); // URL'de küçük harf kullanılması için.
builder.Services.ConfigureApplicationCookie();

builder.Services.AddAutoMapper(typeof(Program)); // AutoMapper servise ekleniyor.

var app = builder.Build(); // Web uygulaması servisler ile derleniyor.

app.UseStaticFiles(); // Statik dosyalar (wwwroot) kullanılıyor.

app.UseSession(); // Session kullanılıyor.

app.UseHttpsRedirection(); // HTTPS yönlendirmesi yapılıyor.
app.UseRouting(); // Yönlendirme ayarları yapılıyor.

app.UseAuthentication(); // Kimlik doğrulama
app.UseAuthorization(); // Yetkilendirme

app.UseEndpoints(endpoint => // Yönlendirme haritalaması.
{
    endpoint.MapAreaControllerRoute( // Admin için controller ve action.
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );
    endpoint.MapControllerRoute( // Varsayılan controller ve action.
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
    endpoint.MapRazorPages(); // Razor sayfaları için yönlendirme.
});

app.CheckMigration(); // Migration Add ve Database Update için.

app.ConfigureDefaultAdminUser(); // Varsayılan olarak Admin kullanıcısını ekler.

app.Run(); // Web uygulaması çalıştırılıyor.
