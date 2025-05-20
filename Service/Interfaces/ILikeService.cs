using Core.Models;

namespace Service.Interfaces
{
  public interface ILikeService
  {
    /// <summary>
    /// Belirtilen gönderi ID'si ile beğeni sayısını getirir.
    /// </summary>
    /// <param name="postId">Beğeni sayısı istenen gönderi ID'si</param>
    /// <returns>Beğeni sayısını int olarak döner.</returns>
    public int GetLikesCount(int postId);

    /// <summary>
    /// Kullanıcınnı bir gönderiyi beğenmesi için metot.
    /// </summary>
    /// <param name="postId">Beğenilecek gönderinin ID'si</param>
    /// <param name="userId">Beğenen kullanıcının ID'si</param>
    public void ToggleLike(int postId, string userId);
  }
}