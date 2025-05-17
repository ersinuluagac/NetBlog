using Core.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Service.Interfaces
{
  public interface IAuthService
  {
    /// <summary>
    /// Bütün roller getirir.
    /// </summary>
    IEnumerable<IdentityRole> Roles { get; }
    
    /// <summary>
    /// Bütün kullanıcıları rolü ile birlikte getirir.
    /// </summary>
    /// <returns>Rolü ile birlikte kullanıcılar.</returns>
    Task<IEnumerable<UserWithRoleDto>> GetAllUsersWithRole();
  }
}