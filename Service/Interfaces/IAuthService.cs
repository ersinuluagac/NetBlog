using Core.Dtos;
using Core.Models;
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
    /// Bir kullanıcı getirir.
    /// </summary>
    /// <param name="userName">Getirilecek kullanıcının kullanıcı adı.</param>
    /// <returns>Bir kulalnıcı döner.</returns>
    Task<ApplicationUser> GetOneUser(string userName);

    Task<UserDtoForUpdate> GetOneUserForUpdate(string userName);

    /// <summary>
    /// Kullanıcı oluşturmak için metot
    /// </summary>
    /// <param name="userDto">Oluşturulacak kullanıcı.</param>
    /// <returns>IdentityResult döner.</returns>
    Task<IdentityResult> CreateUser(UserDtoForCreation userDto);

    Task Update(UserDtoForUpdate userDto);

    Task<IdentityResult> ResetPassword(ResetPasswordDto model);
  }
}