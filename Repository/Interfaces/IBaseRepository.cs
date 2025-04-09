namespace Repository.Interfaces
{
  public interface IBaseRepository<T>
  {
    /// <summary>
    /// Bütün ögeleri bulmak için metot.
    /// </summary>
    /// <param name="trackChanges">Takip parametresi</param>
    /// <returns>Bulunan ögeler.</returns>
    IQueryable<T> FindAll(bool trackChanges);
  }
}