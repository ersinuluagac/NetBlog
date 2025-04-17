using Core.Models;

namespace Service.Interfaces
{
  public interface ICategoryService
  {
    IEnumerable<Category> GetAllCategories(bool trackChanges);
  }
}