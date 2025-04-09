using Repository.Implementations;
using Repository.Interfaces;

namespace Repository.UnitOfWork
{
  public class RepositoryManager : IRepositoryManager
  {
    // DIs
    private readonly RepositoryContext _context;
    private readonly IPostRepository _postRepository;

    // Constructor
    public RepositoryManager(RepositoryContext context, IPostRepository postRepository)
    {
      // IoC'de çözülecekler.
      _context = context;
      _postRepository = postRepository;
    }

    // Yönetilecek sınıflar
    public IPostRepository Post => _postRepository;

    // Metotlar
    public void Save() => _context.SaveChanges();
  }
}