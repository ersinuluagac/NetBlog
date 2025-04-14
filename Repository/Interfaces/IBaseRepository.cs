using System.Linq.Expressions;

namespace Repository.Interfaces
{
  public interface IBaseRepository<T>
  {
    /// <summary>
    /// T tipinde bütün ögeleri bulmak için metot.
    /// </summary>
    /// <param name="trackChanges">Takip</param>
    /// <returns>T tipinde bulunan ögeler.</returns>
    IQueryable<T> FindAll(bool trackChanges);
    /// <summary>
    /// T tipinde koşula bağlı öge bulmak için metot.
    /// </summary>
    /// <param name="expression">LINQ sorgusu</param>
    /// <param name="trackChanges">Takip</param>
    /// <returns>T tipinde koşula bağlı öge.</returns>
    T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
  }
}