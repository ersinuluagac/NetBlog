using AutoMapper;
using Core.Dtos;
using Core.Models;
using Repository.UnitOfWork;
using Service.Interfaces;

namespace Service.Implementations
{
  public class CommentService : ICommentService
  {
    // DI
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    // Constructor
    public CommentService(IRepositoryManager manager, IMapper mapper)
    {
      _manager = manager; // DI
      _mapper = mapper;
    }

    // Methods
    public void CreateComment(CommentDto commentDto)
    {
      Comment comment = _mapper.Map<Comment>(commentDto);
      _manager.Comment.Create(comment);
      _manager.Save();
    }

    public string GetAllComments()
    {
      return _manager.Comment.FindAll(false).Count().ToString();
    }

    public Comment GetComment(int id)
    {
      return _manager.Comment.FindByCondition(c => c.Id == id, false);


    }


    public void RemoveComment(int id)
    {
      var comment = GetComment(id);
      if (comment is not null)
      {
        _manager.Comment.Delete(comment);
        _manager.Save();
      }
    }
  }
}