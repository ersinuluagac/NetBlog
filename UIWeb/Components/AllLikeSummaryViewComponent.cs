using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;

namespace UIWeb.Components
{
  public class AllLikeSummaryViewComponent : ViewComponent
  {
    // DI
    private readonly IServiceManager _manager;

    // Constructor
    public AllLikeSummaryViewComponent(IServiceManager manager)
    {
      _manager = manager;
    }

    // ViewComponent
    public async Task<string> InvokeAsync(int postId)
    {
      return _manager.LikeService.GetAllLikesCount();
    }

  }
}