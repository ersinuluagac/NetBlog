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
      if(post is null)
        throw new Exception("Gönderi bulunamadı!");
      return post;
    }
    
    public void CreatePost(Post post)
    {
      _manager.Post.CreatePost(post);
      _manager.Save();
    }
  }
}