using Core.Models;
using Repository.Interfaces;

namespace Repository.Implementations
{
  public class PostRepository : BaseRepository<Post>, IPostRepository
  {
    // Constructors
    public PostRepository(RepositoryContext context) : base(context)
    {
      // 'context' BaseRepository'de çözülecek
    }

    // Methods
    public IQueryable<Post> GetAllPosts(bool trackChanges) => FindAll(trackChanges);

    public Post? GetOnePost(int id, bool trackChanges)
    {
      return FindByCondition(p => p.Id.Equals(id), trackChanges);
    }

    public void CreateOnePost(Post post) => Create(post);

    public void UpdateOnePost(Post entity) => Update(entity);

    public void DeleteOnePost(Post post) => Delete(post);
  }
}