using AutoMapper;
using Core.Dtos;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Repository.UnitOfWork;
using Service.Interfaces;

namespace Service.Implementations
{
  public class PostService : IPostService
  {
    // DI
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    // Constructor
    public PostService(IRepositoryManager manager, IMapper mapper)
    {
      _manager = manager;
      _mapper = mapper;
    }

    // Methods
    public IEnumerable<Post> GetAllPosts(bool trackChanges)
    {
      return _manager.Post.GetAllPosts(trackChanges).Include(p => p.Category); // Kategori dahil edildi.
    }

    public Post? GetOnePost(int id, bool trackChanges)
    {
      var post = _manager.Post.GetOnePost(id, trackChanges);
      if (post is null)
        throw new Exception("Gönderi bulunamadı!");
      return post;
    }

    public PostDto GetOnePostForUpdate(int id, bool trackChanges)
    {
      var post = GetOnePost(id, trackChanges);
      return _mapper.Map<PostDto>(post);
    }

    public void CreateOnePost(PostDto postDto)
    {
      /* AutoMapper olmasaydı.
        Post post = new Post()
        {
          Title = postDto.Title,
          Content = postDto.Content,
          CategoryId = postDto.CategoryId
        };
      */
      Post post = _mapper.Map<Post>(postDto);
      _manager.Post.CreateOnePost(post);
      _manager.Save();
    }

    public void UpdateOnePost(PostDto postDto)
    {
      var entity = _mapper.Map<Post>(postDto);
      _manager.Post.UpdateOnePost(entity);
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