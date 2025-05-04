using Core.Models;
using Repository.UnitOfWork;
using Service.Interfaces;

namespace Service.Implementations
{
  public class LikeService : ILikeService
  {
    // DI
    private readonly IRepositoryManager _manager;

    // Constructor
    public LikeService(IRepositoryManager manager)
    {
      _manager = manager; // DI
    }

    // Methods
    public int GetLikesCount(int postId)
    {
      return _manager.Like.GetLikesCountByPostId(postId);
    }
  }
}