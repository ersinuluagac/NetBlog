namespace Repository.Interfaces
{
  public interface IBaseRepository<T>
  {
    /// <summary>
    /// T tipinde bütün ögeleri bulmak için metot.
    /// </summary>
    /// <param name="trackChanges">Takip parametresi</param>
    /// <returns>T tipinde bulunan ögeler.</returns>
    IQueryable<T> FindAll(bool trackChanges);
  }
}