using System.Linq.Expressions;

namespace Repository.Interfaces
{
  public interface IBaseRepository<T>
  {
    /// <summary>
    /// Belirtilen türde veri tabanındaki tüm kayıtları sorgulanabilir şekilde döner.
    /// </summary>
    /// <param name="trackChanges">Değişiklik takibi yapılsın mı?</param>
    /// <returns>IQueryable üzerinden tüm kayıtlar.</returns>
    IQueryable<T> FindAll(bool trackChanges);

    /// <summary>
    /// Belirtilen filtre koşuluna göre veri tabanından bir kayıt döner.
    /// </summary>
    /// <param name="expression">Filtrelemek için koşul ifadesi (Expression).</param>
    /// <param name="trackChanges">Değişiklik takibi yapılsın mı?</param>
    /// <returns>Koşulu sağlayan bir kayıt veya null.</returns>
    T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

    /// <summary>
    /// Yeni bir kayıt oluşturur ve veri tabanına ekler.
    /// </summary>
    /// <param name="entity">Eklenecek nesne.</param>
    void Create(T entity);

    /// <summary>
    /// Veri tabanında mevcut olan bir kaydı günceller.
    /// </summary>
    /// <param name="entity">Güncellenecek nesne.</param>
    void Update(T entity);

    /// <summary>
    /// Mevcut bir kaydı veri tabanından siler.
    /// </summary>
    /// <param name="entity">Silinecek nesne.</param>
    void Delete(T entity);
  }
}