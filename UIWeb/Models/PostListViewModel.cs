using Core.Models;

namespace UIWeb.Models
{
  public class PostListViewModel
  {
    public IEnumerable<Post> Posts { get; set; } = Enumerable.Empty<Post>();
    public Pagination Pagination { get; set; } = new();
    public int TotalCount => Posts.Count();
  }
}