using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
  public record UserDtoForCreation : UserDto
  {
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Parola gereklidir.")]
    public string? Password { get; init; }
  }
}