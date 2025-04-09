using Repository.Interfaces;

namespace Repository.UnitOfWork
{
  public interface IRepositoryManager
  {
    // Yönetilecek sınıflar.
    IPostRepository Post {get;}

    /// <summary>
    /// Veri tabanına kayıt için metot.
    /// </summary>
    void Save();
  }
}