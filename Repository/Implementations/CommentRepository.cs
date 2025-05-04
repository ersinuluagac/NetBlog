using Core.Models;
using Repository.Interfaces;

namespace Repository.Implementations
{
  public class CommentRepository : BaseRepository<Comment>, ICommentRepository
  {
    // Constructor
    public CommentRepository(RepositoryContext context) : base(context)
    {
      // 'context' BaseRepository'de çözülecek
    }

    // Methods
  }
}