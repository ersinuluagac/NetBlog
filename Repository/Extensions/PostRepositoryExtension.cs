using Core.Models;

namespace Repository.Extensions
{
  public static class PostRepositoryExtension
  {
    public static IQueryable<Post> FilteredByCategoryId(this IQueryable<Post> posts, int? categoryId)
    {
      if (categoryId is null)
        return posts;
      else
        return posts.Where(post => post.CategoryId.Equals(categoryId));
    }

    public static IQueryable<Post> FilteredBySearchTerm(this IQueryable<Post> posts, string searchTerm)
    {
      if (string.IsNullOrWhiteSpace(searchTerm))
        return posts;
      else
        return posts.Where(post => post.Title.ToLower()
          .Contains(searchTerm.ToLower()));
    }

    public static IQueryable<Post> ToPaginate(this IQueryable<Post> posts, int pageNumber, int pageSize)
    {
      return posts
        .Skip((pageNumber-1)*pageSize)
        .Take(pageSize);
    }
  }
}