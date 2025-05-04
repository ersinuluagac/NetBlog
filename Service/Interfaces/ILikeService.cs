using Core.Models;

namespace Service.Interfaces
{
  public interface ILikeService
  {
    public int GetLikesCount(int postId);
  }
}