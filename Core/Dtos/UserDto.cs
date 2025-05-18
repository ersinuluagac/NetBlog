using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
  public record UserDto
  {
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
    public string? UserName { get; init; }
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "E-posta adresi gereklidir.")]
    public string? Email { get; init; }
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Parola gereklidir.")]
    public string? Password { get; init; }
    public string? Role { get; init; }
  }
}