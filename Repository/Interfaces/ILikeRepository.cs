using System.Linq.Expressions;
using Core.Models;

namespace Repository.Interfaces
{
  public interface ILikeRepository : IBaseRepository<Like>
  {
    /// <summary>
    /// Gönderi numarasına göre veri tabanındaki beğenileri getirir.
    /// </summary>
    /// <param name="postId">Beğeni sayısı istenen gönderi ID'si</param>
    /// <returns>Beğeni sayısını int olarak döner.</returns>
    public int GetLikesCountByPostId(int postId);
  }
}