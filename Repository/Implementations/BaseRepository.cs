using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Implementations
{
  // 'abstract' çünkü bu class türetilmeyecek, yani bitmememiş bir class.
  public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, new()
  {
    // 'protected' çünkü kalıtım alan sınıflarda da kullanılacak.
    protected readonly RepositoryContext _context;

    // Constructors
    protected BaseRepository(RepositoryContext context)
    {
      _context = context; // Dependency Injection, IoC'de çözülecek.
    }

    // Methods
    public IQueryable<T> FindAll(bool trackChanges)
    {
      return trackChanges
        ? _context.Set<T>()
        : _context.Set<T>().AsNoTracking();
    }
  }
}