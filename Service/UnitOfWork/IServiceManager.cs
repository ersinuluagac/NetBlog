using Service.Interfaces;

namespace Service.UnitOfWork
{
  public interface IServiceManager
  {
    IPostService PostService { get; }
    ICategoryService CategoryService { get; }
    ICommentService CommentService { get; }
    ILikeService LikeService { get; }
  }
}