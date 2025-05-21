using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Service.Interfaces;

namespace Service.Implementations
{
  public class AuthService : IAuthService
  {
    // DI
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    // CTOR
    public AuthService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IMapper mapper)
    {
      _roleManager = roleManager;
      _userManager = userManager;
      _mapper = mapper;
    }

    public IEnumerable<IdentityRole> Roles =>
      _roleManager.Roles;

    public async Task<IdentityResult> CreateUser(UserDtoForCreation userDto)
    {
      var user = _mapper.Map<ApplicationUser>(userDto);
      var result = await _userManager.CreateAsync(user, userDto.Password);
      if (!result.Succeeded)
        throw new Exception("Kullanıcı oluşturulamadı.");
      var roleResult = await _userManager.AddToRoleAsync(user, "User");
      if (!roleResult.Succeeded)
        throw new Exception("Rol eklenemedi.");
      return result;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersWithRole()
    {
      var users = _userManager.Users;
      var userWithRoleList = new List<UserDto>();
      foreach (var user in users)
      {
        var roles = await _userManager.GetRolesAsync(user);
        userWithRoleList.Add(new UserDto
        {
          UserName = user.UserName,
          Email = user.Email,
          Role = roles.FirstOrDefault()
        });
      }
      return userWithRoleList;
    }

    public async Task<ApplicationUser> GetOneUser(string userName)
    {
      return await _userManager.FindByNameAsync(userName);
    }

    public async Task<UserDtoForUpdate> GetOneUserForUpdate(string userName)
    {
      var user = await GetOneUser(userName);
      if (user is not null)
      {
        var userDto = _mapper.Map<UserDtoForUpdate>(user);
        var roles = await _userManager.GetRolesAsync(user);
        userDto.Role = roles.FirstOrDefault();
        userDto.UserRoles = _roleManager.Roles.Select(r => r.Name).ToList();
        return userDto;
      }
      throw new Exception("Bir hata oluştu!");
    }

    public async Task<IdentityResult> ResetPassword(ResetPasswordDto model)
    {
      var user = await GetOneUser(model.UserName);
      if (user is not null)
      {
        var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.Password);
        if (!result.Succeeded)
        {
          var errors = string.Join(", ", result.Errors.Select(e => e.Description));
          throw new Exception("Şifre eklenemedi: " + errors);
        }
        return result;
      }
      throw new Exception("Kullanıcı bulunamadı.");
    }

    public async Task Update(UserDtoForUpdate userDto)
    {
      var user = await GetOneUser(userDto.UserName);
      if (user is null)
      {
        throw new Exception("Kullanıcı bulunamadı.");
      }
      user.Email = userDto.Email;
      if (user is not null)
      {
        var result = await _userManager.UpdateAsync(user);
        var userRole = await _userManager.GetRolesAsync(user);
        var removeRole = await _userManager.RemoveFromRolesAsync(user, userRole);
        var addRole = await _userManager.AddToRoleAsync(user, userDto.Role);
        return;
      }
      throw new Exception("Kullanıcı güncellerken bir problem oldu.");
    }
  }
}