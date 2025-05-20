using AutoMapper;
using Core.Dtos;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.UnitOfWork;
using Service.Interfaces;

namespace Service.Implementations
{
  public class LikeService : ILikeService
  {
    // DI
    private readonly IRepositoryManager _manager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    // Constructor
    public LikeService(IRepositoryManager manager, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
      _manager = manager; // DI
      _userManager = userManager;
      _mapper = mapper;
    }

    // Methods
    public void ToggleLike(int postId, string userId)
    {
      var post = _manager.Post.GetOnePost(postId, false);
      if (post is null)
        throw new Exception($"Post with Id {postId} not found.");
      var user = _userManager.Users.FirstOrDefault(u => u.Id.Equals(userId));
      if (user is null)
        throw new Exception($"User with Id {userId} not found.");

      var like = _manager.Like
        .FindAll(false)
        .FirstOrDefault(l => l.PostId.Equals(postId) && l.UserId.Equals(userId));
      if (like is not null)
        _manager.Like.Delete(like);
      else
      {
        var likeDto = new LikeDto()
        {
          PostId = post.Id,
          UserId = user.Id
        };
        _manager.Like.Create(_mapper.Map<Like>(likeDto));
      }
      _manager.Save();
    }

    public int GetLikesCount(int postId)
    {
      return _manager.Like.GetLikesCountByPostId(postId);
    }
  }
}