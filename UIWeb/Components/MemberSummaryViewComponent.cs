using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;

namespace UIWeb.Components
{
  public class MemberSummaryViewComponent : ViewComponent
  {
    private readonly IServiceManager _manager;
    private readonly UserManager<ApplicationUser> _userManager;

    public MemberSummaryViewComponent(IServiceManager manager, UserManager<ApplicationUser> userManager)
    {
      _manager = manager;
      _userManager = userManager;
    }

    public async Task<string> InvokeAsync(int postId)
    {
      return _userManager.Users.Count().ToString();
      // return _manager.PostService.GetAllPosts(false).Count().ToString();
    }
  }
}