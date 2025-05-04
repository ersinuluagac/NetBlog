using Repository.UnitOfWork;
using Service.Interfaces;

namespace Service.Implementations
{
  public class CommentService : ICommentService
  {
    // DI
    private IRepositoryManager _manager;

    // Constructor
    public CommentService(IRepositoryManager manager)
    {
      _manager = manager; // DI
    }

    // Methods
  }
}