using Core.Models;
using Core.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
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
    public IQueryable<Post> GetAllPostsWithDetails(PostRequestParameters p)
    {
      return _context.Posts
        .FilteredByCategoryId(p.CategoryId)
        .FilteredBySearchTerm(p.SearchTerm)
        .Include(p => p.Category)
        .Include(p => p.User)
        .ToPaginate(p.PageNumber, p.PageSize);
    }

    public Post? GetOnePost(int id, bool trackChanges)
    {
      return _context
        .Posts
        .Include(p => p.Comments)
          .ThenInclude(c => c.User)
        .Include(p => p.Likes)
        .FirstOrDefault(p => p.Id.Equals(id));
    }
  }
}