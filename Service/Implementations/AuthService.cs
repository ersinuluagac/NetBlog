using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Service.Interfaces;

namespace Service.Implementations
{
  public class AuthService : IAuthService
  {
    // DI
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IMapper _mapper;

    // CTOR
    public AuthService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IMapper mapper)
    {
      _roleManager = roleManager;
      _userManager = userManager;
      _mapper = mapper;
    }

    public IEnumerable<IdentityRole> Roles =>
      _roleManager.Roles;

    public async Task<IdentityUser> GetOneUser(string email)
    {
      return await _userManager.FindByEmailAsync(email);
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
  }
}