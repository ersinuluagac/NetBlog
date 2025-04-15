using Repository.Implementations;
using Repository.Interfaces;

namespace Repository.UnitOfWork
{
  public class RepositoryManager : IRepositoryManager
  {
    // DIs
    private readonly RepositoryContext _context;
    private readonly IPostRepository _postRepository;
    private readonly ICategoryRepository _categoryRepository;

    // Constructor
    public RepositoryManager(RepositoryContext context, IPostRepository postRepository, ICategoryRepository categoryRepository)
    {
      // IoC
      _context = context;
      _postRepository = postRepository;
      _categoryRepository = categoryRepository;
    }

    // Yönetilecek sınıflar
    public IPostRepository Post => _postRepository;
    public ICategoryRepository Category => _categoryRepository;

    // Metotlar
    public void Save() => _context.SaveChanges();
  }
}