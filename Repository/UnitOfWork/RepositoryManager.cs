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
    private readonly ICommentRepository _commentRepository;
    private readonly ILikeRepository _likeRepository;

    // Constructor
    public RepositoryManager(RepositoryContext context, IPostRepository postRepository, ICategoryRepository categoryRepository, ICommentRepository commentRepository, ILikeRepository likeRepository)
    {
      // IoC
      _context = context;
      _postRepository = postRepository;
      _categoryRepository = categoryRepository;
      _commentRepository = commentRepository;
      _likeRepository = likeRepository;
    }

    // Yönetilecek sınıflar
    public IPostRepository Post => _postRepository;
    public ICategoryRepository Category => _categoryRepository;
    public ICommentRepository Comment => _commentRepository;
    public ILikeRepository Like => _likeRepository;

    // Metotlar
    public void Save() => _context.SaveChanges();
  }
}