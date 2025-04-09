using Core.Models;

namespace Repository.Interfaces
{
  public interface IPostRepository : IBaseRepository<Post>
  {
    /// <summary>
    /// Bütün gönderileri getiren metot.
    /// </summary>
    /// <param name="trackChanges">Takip parametresi</param>
    /// <returns>Bulunan tüm gönderiler.</returns>
    IQueryable<Post> GetAllPosts(bool trackChanges);
  }
}