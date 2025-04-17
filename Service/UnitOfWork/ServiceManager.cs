using Service.Interfaces;

namespace Service.UnitOfWork
{
  public class ServiceManager : IServiceManager
  {
    // DIs
    private readonly IPostService _postService;
    private readonly ICategoryService _categoryService;

    // Constructor
    public ServiceManager(IPostService postService, ICategoryService categoryService)
    {
      _postService = postService;
      _categoryService = categoryService;
    }

    // Yönetilecek sınıflar
    public IPostService PostService => _postService;

    public ICategoryService CategoryService => _categoryService;
  }
}