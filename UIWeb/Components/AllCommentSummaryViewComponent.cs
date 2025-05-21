using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;

namespace UIWeb.Components
{
  public class AllCommentSummaryViewComponent : ViewComponent
  {
    // DI
    private readonly IServiceManager _manager;

    // Constructor
    public AllCommentSummaryViewComponent(IServiceManager manager)
    {
      _manager = manager;
    }

    // ViewComponent
    public async Task<string> InvokeAsync(int postId)
    {
      return _manager.CommentService.GetAllComments();
    }

  }
}