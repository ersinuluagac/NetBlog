using Core.Models;

namespace Service.Interfaces
{
  public interface ICategoryService
  {
    /// <summary>
    /// Tüm kategorileri (Category) veri tabanından getirir.
    /// </summary>
    /// <param name="trackChanges">Değişiklik takibi yapılacak mı?</param>
    /// <returns>Kategorilerin listesi.</returns>
    IEnumerable<Category> GetAllCategories(bool trackChanges);
  }
}