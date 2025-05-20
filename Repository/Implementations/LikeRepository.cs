using System.Linq.Expressions;
using Core.Dtos;
using Core.Models;
using Repository.Interfaces;

namespace Repository.Implementations
{
  public class LikeRepository : BaseRepository<Like>, ILikeRepository
  {
    // Constructor
    public LikeRepository(RepositoryContext context) : base(context)
    {
      // 'context' BaseRepository'de çözülecek
    }

    // Methods
    public int GetLikesCountByPostId(int postId)
    {
      return _context.Likes.Count(l => l.PostId.Equals(postId));
    }
  }
}