using System.Linq.Expressions;
using Core.Models;

namespace Repository.Interfaces
{
  public interface ILikeRepository : IBaseRepository<Like>
  {
    public int GetLikesCountByPostId(int postId);
    // Basedeki metotlar yeterli olacak (şimdilik)
  }
}