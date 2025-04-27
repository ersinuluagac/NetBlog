using Core.Dtos;
using Core.Models;

namespace Service.Interfaces
{
  public interface IPostService
  {
    IEnumerable<Post> GetAllPosts(bool trackChanges);
    Post? GetOnePost(int id, bool trackChanges);
    PostDto GetOnePostForUpdate(int id, bool trackChanges);
    void CreateOnePost(PostDto postDto);
    void UpdateOnePost(PostDto postDto);
    void DeleteOnePost(int id);
  }
}