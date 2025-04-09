using Core.Models;
using Repository.Interfaces;

namespace Repository.Implementations
{
  // Constructors
  public class PostRepository : BaseRepository<Post>, IPostRepository
  {
    public PostRepository(RepositoryContext context) : base(context)
    {
      // 'context' BaseRepository'de çözülecek
    }

    // Methods
    public IQueryable<Post> GetAllPosts(bool trackChanges) => FindAll(trackChanges);
  }
}