using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;

namespace UIWeb.Components
{
  public class LikesSummaryViewComponent : ViewComponent
  {
    // DI
    private readonly IServiceManager _manager;

    // Constructor
    public LikesSummaryViewComponent(IServiceManager manager)
    {
      _manager = manager;
    }

    // ViewComponent
    public async Task<string> InvokeAsync(int postId)
    {
      var count = _manager.LikeService.GetLikesCount(postId);
      return await Task.FromResult(count.ToString());
    }

  }
}