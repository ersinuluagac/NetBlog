using Core.Models;

namespace Repository.Extensions
{
  public static class PostRepositoryExtension
  {
    public static IQueryable<Post> FilteredByCategoryId(this IQueryable<Post> posts, int? categoryId)
    {
      if(categoryId is null)
        return posts;
      else
        return posts.Where(post => post.CategoryId.Equals(categoryId));
    }
  }
}