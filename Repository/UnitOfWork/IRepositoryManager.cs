using Repository.Interfaces;

namespace Repository.UnitOfWork
{
  public interface IRepositoryManager
  {
    // Yönetilecek sınıflar.
    IPostRepository Post { get; }
    ICategoryRepository Category { get; }
    ICommentRepository Comment { get; }
    ILikeRepository Like { get; }

    /// <summary>
    /// Veri tabanına kayıt için metot.
    /// </summary>
    void Save();
  }
}