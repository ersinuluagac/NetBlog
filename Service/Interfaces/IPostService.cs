using Core.Dtos;
using Core.Models;
using Core.RequestParameters;

namespace Service.Interfaces
{
  public interface IPostService
  {
    /// <summary>
    /// Tüm gönderileri (Post'lar) veri tabanından getirir.
    /// </summary>
    /// <param name="trackChanges">Değişiklik takibi yapılacak mı?</param>
    /// <returns>Gönderiler listesi.</returns>
    IEnumerable<Post> GetAllPosts(bool trackChanges);

    /// <summary>
    /// Verilen kategori ID'sine göre postları veri tabanından getirir.
    /// </summary>
    /// <param name="p">Kategori ID istek parametresi</param>
    /// <returns>Kategoriye göre tüm postlar</returns>
    IEnumerable<Post> GetAllPostsWithDetails(PostRequestParameters p);

    /// <summary>
    /// Verilen ID'ye sahip tek bir gönderiyi (Post) getirir.
    /// </summary>
    /// <param name="id">Getirilecek gönderinin benzersiz kimliği (ID).</param>
    /// <param name="trackChanges">Değişiklik takibi yapılacak mı?</param>
    /// <returns>Verilen ID'ye sahip gönderi (Post) ya da eğer bulunamazsa null döner.</returns>
    Post? GetOnePost(int id, bool trackChanges);

    /// <summary>
    /// Verilen ID'ye sahip tek bir gönderiyi (Post) güncelleme için alır.
    /// </summary>
    /// <param name="id">Güncellenmek istenen gönderinin benzersiz kimliği (ID).</param>
    /// <param name="trackChanges">Değişiklik takibi yapılacak mı?</param>
    /// <returns>Verilen ID'ye sahip gönderinin güncellenebilir versiyonunu döner (PostDto). 
    /// Eğer gönderi bulunamazsa, null döner.</returns>
    PostDto GetOnePostForUpdate(int id, bool trackChanges);

    /// <summary>
    /// Yeni bir gönderi (Post) oluşturur.
    /// </summary>
    /// <param name="postDto">Oluşturulacak gönderinin verilerini içeren DTO.</param>
    void CreateOnePost(PostDto postDto);

    /// <summary>
    /// Mevcut bir gönderiyi günceller.
    /// </summary>
    /// <param name="postDto">Güncellenmesi gereken gönderinin verilerini içeren DTO.</param>
    void UpdateOnePost(PostDto postDto);
    
    /// <summary>
    /// Belirli bir gönderiyi siler.
    /// </summary>
    /// <param name="id">Silinecek gönderinin benzersiz kimliği.</param>
    void DeleteOnePost(int id);
  }
}