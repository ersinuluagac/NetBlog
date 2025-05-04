using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Implementations;
using Repository.Interfaces;
using Repository.UnitOfWork;
using Service.Implementations;
using Service.Interfaces;
using Service.UnitOfWork;

var builder = WebApplication.CreateBuilder(args); // Web uygulaması oluşturuluyor.

builder.Services.AddControllersWithViews(); // Controller ve view servisleri ekleniyor.
builder.Services.AddRazorPages(); // Razor sayfaları ekleniyor.

builder.Services.AddDbContext<RepositoryContext>(options => // Veritabanı bağlantısı yapılıyor.
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlConnection"), // appsettings.json dosyasındaki bağlantı bilgileri alınıyor.
    b => b.MigrationsAssembly("UIWeb")); // Migrations'ların nerde bulunacağını belirliyoruz.
});

// Inversion of Control Repository
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ILikeRepository, LikeRepository>();
// Inversion of Control Repository
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ILikeService, LikeService>();

builder.Services.AddAutoMapper(typeof(Program)); // AutoMapper servise ekleniyor.

var app = builder.Build(); // Web uygulaması servisler ile derleniyor.

app.UseStaticFiles(); // Statik dosyalar (wwwroot) kullanılıyor.

app.UseHttpsRedirection(); // HTTPS yönlendirmesi yapılıyor.
app.UseRouting(); // Yönlendirme ayarları yapılıyor.

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

app.Run(); // Web uygulaması çalıştırılıyor.
