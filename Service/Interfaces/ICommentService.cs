using Core.Dtos;

namespace Service.Interfaces
{
  public interface ICommentService
  {
    void CreateComment(CommentDto commentDto);
  }
}