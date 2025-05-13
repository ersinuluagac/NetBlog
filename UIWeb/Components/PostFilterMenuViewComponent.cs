using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Components
{
  public class PostFilterMenuViewComponent : ViewComponent
  {
    public IViewComponentResult Invoke()
    {
      return View();
    }
  }
}