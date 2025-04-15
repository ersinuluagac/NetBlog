using Core.Models;
using Repository.Interfaces;

namespace Repository.Implementations
{
  public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
  {
    // Constructors
    public CategoryRepository(RepositoryContext context) : base(context)
    {
      // 'context' BaseRepository'de çözülecek
    }

    // Methods
  }
}