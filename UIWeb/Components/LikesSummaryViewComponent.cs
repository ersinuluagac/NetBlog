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
    public string Invoke(int postId) // Gönderi beğeni sayısını döner.
    {
      return _manager.LikeService.GetLikesCount(postId).ToString();
    }
  }
}