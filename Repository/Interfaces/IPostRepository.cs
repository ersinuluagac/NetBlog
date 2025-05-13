using Core.Models;
using Core.RequestParameters;

namespace Repository.Interfaces
{
  public interface IPostRepository : IBaseRepository<Post>
  {
    /// <summary>
    /// Tüm gönderileri (postları) veri tabanından getirir.
    /// </summary>
    /// <param name="trackChanges">Değişiklik takibi yapılsın mı?</</param>
    /// <returns>Sorgulanabilir (IQueryable) tüm gönderiler.</returns>
    IQueryable<Post> GetAllPosts(bool trackChanges);

    /// <summary>
    /// Verilen kategori ID'sine göre, ilişkili tüm gönderileri (postları) getirir.
    /// </summary>
    /// <param name="p">Gönderileri filtrelemek ve detaylandırmak için kullanılacak istek parametreleri.</param>
    /// <returns>Kategori ID'sine göre filtrelenmiş tüm postları döndürür.</returns>
    IQueryable<Post> GetAllPostsWithDetails(PostRequestParameters p);

    /// <summary>
    /// Belirtilen kimliğe (ID) sahip gönderiyi veri tabanından getirir.
    /// </summary>
    /// <param name="id">Getirilecek gönderinin kimliği (ID).</param>
    /// <param name="trackChanges">Değişiklik takibi yapılsın mı?</param>
    /// <returns>İstenilen gönderi (Post) veya bulunamazsa null döner.</returns>
    Post? GetOnePost(int id, bool trackChanges);

    /// <summary>
    /// Yeni bir gönderiyi (Post) veri tabanına ekler.
    /// </summary>
    /// <param name="post">Eklenmek istenen gönderi nesnesi.</param>
    void CreateOnePost(Post post);

    /// <summary>
    /// Var olan bir gönderiyi (Post) güncellemek için işaretler.
    /// </summary>
    /// <param name="entity">Güncellenecek gönderi nesnesi</param>
    void UpdateOnePost(Post entity);

    /// <summary>
    /// Veritabanındaki belirtilen nesneyi (entity) siler.
    /// </summary>
    /// <param name="id">Silinecek gönderi nesnesi</param>
    void DeleteOnePost(Post post);
  }
}