using AutoMapper;
using Core.Dtos;
using Core.Models;

namespace UIWeb.Infrastructure.Mapper
{
  public class MappingProfile : Profile
  {
    // Constructor
    public MappingProfile()
    {
      CreateMap<PostDto, Post>().ReverseMap();
    }
  }
}