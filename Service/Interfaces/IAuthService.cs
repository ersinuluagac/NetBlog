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
    Task<IEnumerable<UserDto>> GetAllUsersWithRole();

    /// <summary>
    /// Kullanıcının e-posta adresi ile bir kullanıcı getirir
    /// </summary>
    /// <param name="userName">Getirilecek kullanıcının e-posta adresi</param>
    /// <returns>IdentityUser döner.</returns>
    Task<IdentityUser> GetOneUser(string email);
  }
}