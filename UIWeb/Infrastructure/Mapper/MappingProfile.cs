using AutoMapper;
using Core.Dtos;
using Core.Models;
using Microsoft.AspNetCore.Identity;

namespace UIWeb.Infrastructure.Mapper
{
  public class MappingProfile : Profile
  {
    // Constructor
    public MappingProfile()
    {
      CreateMap<PostDtoForCreation, Post>().ReverseMap();
      CreateMap<PostDtoForUpdate, Post>().ReverseMap();
      CreateMap<Post, PostDtoWithDetails>().ReverseMap();
      CreateMap<UserDto, ApplicationUser>().ReverseMap();
      CreateMap<CommentDto, Comment>().ReverseMap();
      CreateMap<LikeDto, Like>().ReverseMap();
    }
  }
}