using Service.Interfaces;

namespace Service.UnitOfWork
{
  public class ServiceManager : IServiceManager
  {
    // DIs
    private readonly IPostService _postService;
    private readonly ICategoryService _categoryService;
    private readonly ICommentService _commentService;
    private readonly ILikeService _likeService;

    // Constructor
    public ServiceManager(IPostService postService, ICategoryService categoryService, ICommentService commentService, ILikeService likeService)
    {
      _postService = postService;
      _categoryService = categoryService;
      _commentService = commentService;
      _likeService = likeService;
    }

    // Yönetilecek sınıflar
    public IPostService PostService => _postService;

    public ICategoryService CategoryService => _categoryService;

    public ICommentService CommentService => _commentService;

    public ILikeService LikeService => _likeService;
  }
}