using Core.Dtos;
using Core.Models;

namespace Service.Interfaces
{
  public interface ICommentService
  {
    void CreateComment(CommentDto commentDto);
    Comment GetComment(int id);
    string GetAllComments();
    void RemoveComment(int id);
  }
}