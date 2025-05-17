using Microsoft.AspNetCore.Identity;

namespace Core.Dtos
{
  public class UserWithRoleDto
  {
    public string? Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Role { get; set; }
  }
}