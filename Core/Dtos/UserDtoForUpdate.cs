namespace Core.Dtos
{
  public record UserDtoForUpdate : UserDto
  {
    public List<string> UserRoles { get; set; } = new();
  }
}