using Microsoft.AspNetCore.Identity;

namespace Service.Interfaces
{
  public interface IAuthService
  {
    IEnumerable<IdentityRole> Roles { get; }
    IEnumerable<IdentityUser> GetAllUsers();
  }
}