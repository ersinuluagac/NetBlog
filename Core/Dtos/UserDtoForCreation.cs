using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
  public record UserDtoForCreation : UserDto
  {
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Parola gereklidir.")]
    [MinLength(6, ErrorMessage = "Parola en az 6 karakter içermeli.")]
    public string? Password { get; init; }
  }
}