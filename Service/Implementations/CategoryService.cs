using Core.Models;
using Repository.UnitOfWork;
using Service.Interfaces;

namespace Service.Implementations
{
  public class CategoryService : ICategoryService
  {
    // DI
    private readonly IRepositoryManager _manager;

    // Constructor
    public CategoryService(IRepositoryManager manager)
    {
      _manager = manager; // DI
    }

    // Methods
    public IEnumerable<Category> GetAllCategories(bool trackChanges)
    {
      return _manager.Category.FindAll(trackChanges);
    }

    public void AddCategory(Category category)
    {
      _manager.Category.Create(category);
      _manager.Save();
    }
  }
}