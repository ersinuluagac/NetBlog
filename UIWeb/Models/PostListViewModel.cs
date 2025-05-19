using Core.Dtos;
using Core.Models;

namespace UIWeb.Models
{
  public class PostListViewModel
  {
    public IEnumerable<PostDtoWithDetails> Posts { get; set; } = Enumerable.Empty<PostDtoWithDetails>();
    public Pagination Pagination { get; set; } = new();
    public int TotalCount => Posts.Count();
  }
}