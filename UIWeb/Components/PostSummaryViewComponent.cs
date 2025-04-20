using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;

namespace UIWeb.Components
{
  public class PostSummaryViewComponent : ViewComponent
  {
    // DI
    private readonly IServiceManager _manager;

    // Constructor
    public PostSummaryViewComponent(IServiceManager manager)
    {
      _manager = manager;
    }

    // ViewComponent
    public string Invoke() // Gönderi sayısı döner.
    {
      return _manager.PostService.GetAllPosts(false).Count().ToString();
    }
  }
}