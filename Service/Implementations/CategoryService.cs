using Core.Models;
using Repository.Interfaces;
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
  }
}