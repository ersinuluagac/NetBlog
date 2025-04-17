using Core.Models;

namespace Service.Interfaces
{
  public interface IPostService
  {
    IEnumerable<Post> GetAllPosts(bool trackChanges);
    Post? GetOnePost(int id, bool trackChanges);
  }
}