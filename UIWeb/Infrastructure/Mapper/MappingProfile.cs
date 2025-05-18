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
      CreateMap<PostDto, Post>().ReverseMap();
      CreateMap<CommentDto, Comment>().ReverseMap();
      CreateMap<UserDto, IdentityUser>().ReverseMap();
    }
  }
}