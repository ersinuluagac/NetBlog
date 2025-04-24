using Core.Models;

namespace Repository.Interfaces
{
  public interface IPostRepository : IBaseRepository<Post>
  {
    /// <summary>
    /// Bütün "post"ları getiren metot.
    /// </summary>
    /// <param name="trackChanges">Takip</param>
    /// <returns>Bulunan bütün "post"lar.</returns>
    IQueryable<Post> GetAllPosts(bool trackChanges);
    /// <summary>
    /// ID'ye göre tek bir "post" getiren metot
    /// </summary>
    /// <param name="id">Gönderi ID'si</param>
    /// <param name="trackChanges">Takip</param>
    /// <returns>ID'ye göre "post"</returns>
    Post? GetOnePost(int id, bool trackChanges);
    /// <summary>
    /// "Post" yaratmak ve veritabanına eklemek için metot.
    /// </summary>
    /// <param name="post">Oluşturulacak "post"</param>
    void CreatePost(Post post);
  }
}