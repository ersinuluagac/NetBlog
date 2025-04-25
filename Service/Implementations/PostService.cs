using Core.Models;
using Repository.UnitOfWork;
using Service.Interfaces;

namespace Service.Implementations
{
  public class PostService : IPostService
  {
    // DI
    private readonly IRepositoryManager _manager;

    // Constructor
    public PostService(IRepositoryManager manager)
    {
      _manager = manager; // DI
    }

    // Methods
    public IEnumerable<Post> GetAllPosts(bool trackChanges)
    {
      return _manager.Post.GetAllPosts(trackChanges);
    }

    public Post? GetOnePost(int id, bool trackChanges)
    {
      var post = _manager.Post.GetOnePost(id, trackChanges);
      if (post is null)
        throw new Exception("Gönderi bulunamadı!");
      return post;
    }

    public void CreateOnePost(Post post)
    {
      _manager.Post.CreateOnePost(post);
      _manager.Save();
    }

    public void UpdateOnePost(Post post)
    {
      var entity = _manager.Post.GetOnePost(post.Id, true);
      entity.Title = post.Title;
      entity.Content = post.Content;
      _manager.Save();
    }

    public void DeleteOnePost(int id)
    {
      Post post = GetOnePost(id, false);
      if (post is not null)
      {
        _manager.Post.DeleteOnePost(post);
        _manager.Save();
      }
    }
  }
}