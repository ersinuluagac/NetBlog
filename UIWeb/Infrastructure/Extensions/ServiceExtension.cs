using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Implementations;
using Repository.Interfaces;
using Repository.UnitOfWork;
using Service.Implementations;
using Service.Interfaces;
using Service.UnitOfWork;

namespace UIWeb.Infrastructure.Extensions
{
  public static class ServiceExtension
  {
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<RepositoryContext>(options => // Veritabanı bağlantısı yapılıyor.
      {
        options.UseSqlServer(configuration.GetConnectionString("MsSqlConnection"), // appsettings.json dosyasındaki bağlantı bilgileri alınıyor.
        b => b.MigrationsAssembly("UIWeb")); // Migrations'ların nerde bulunacağını belirliyoruz.
      });
    }

    public static void ConfigureSession(this IServiceCollection services)
    {
      services.AddDistributedMemoryCache(); // Dağıtılmış önbellek eklendi.
      services.AddSession(options => // Oturum (session) yönetimi için.
      {
        options.Cookie.Name = "NetBlog.Session"; // Çerezleri tutmak için isim.
        options.IdleTimeout = TimeSpan.FromMinutes(10); // Eğer yeni istek yoksa 10 dakika tutar.
      });
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // HTTP isteği bilgilerine erişim için.
    }

    public static void ConfigureRepositoryRegistration(this IServiceCollection services)
    {
      services.AddScoped<IRepositoryManager, RepositoryManager>();
      services.AddScoped<IPostRepository, PostRepository>();
      services.AddScoped<ICategoryRepository, CategoryRepository>();
      services.AddScoped<ICommentRepository, CommentRepository>();
      services.AddScoped<ILikeRepository, LikeRepository>();
    }
    
    public static void ConfigureServiceRegistration(this IServiceCollection services)
    {
      services.AddScoped<IServiceManager, ServiceManager>();
      services.AddScoped<IPostService, PostService>();
      services.AddScoped<ICategoryService, CategoryService>();
      services.AddScoped<ICommentService, CommentService>();
      services.AddScoped<ILikeService, LikeService>();
    }

  }
}