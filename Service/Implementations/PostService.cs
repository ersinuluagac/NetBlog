using AutoMapper;
using Core.Dtos;
using Core.Models;
using Core.RequestParameters;
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
      return _manager.Post
        .FindAll(trackChanges)
        .Include(p => p.Category)
        .Include(p => p.Likes)
        .Include(p => p.User);
    }

    public IEnumerable<PostDtoWithDetails> GetAllPostsWithDetails(PostRequestParameters p)
    {
      return _mapper.Map<IEnumerable<PostDtoWithDetails>>(_manager.Post.GetAllPostsWithDetails(p));
    }

    public PostDtoWithDetails? GetOnePost(int id, bool trackChanges)
    {
      var post = _manager.Post.GetOnePost(id, trackChanges);
      if (post is null)
        throw new Exception("Gönderi bulunamadı!");
      return _mapper.Map<PostDtoWithDetails>(post);
    }

    public PostDtoForUpdate GetOnePostForUpdate(int id, bool trackChanges)
    {
      var post = GetOnePost(id, trackChanges);
      return _mapper.Map<PostDtoForUpdate>(post);
    }

    public void CreateOnePost(PostDtoForCreation postDto)
    {
      Post post = _mapper.Map<Post>(postDto);
      _manager.Post.Create(post);
      _manager.Save();
    }

    public void UpdateOnePost(PostDtoForUpdate postDto)
    {
      var entity = _manager.Post.FindByCondition(p => p.Id.Equals(postDto.Id), true);
      _mapper.Map(postDto, entity);
      entity.UpdatedAt = DateTime.UtcNow;
      _manager.Post.Update(entity);
      _manager.Save();
    }

    public void DeleteOnePost(int id)
    {
      Post post = _manager.Post.GetOnePost(id, true);
      if (post is not null)
      {
        _manager.Post.Delete(post);
        _manager.Save();
      }
    }
  }
}