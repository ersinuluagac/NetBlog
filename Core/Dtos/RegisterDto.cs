using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
  public record RegisterDto
  {
    [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
    public string? Username { get; init; }
    [Required(ErrorMessage = "E-posta adresi gereklidir.")]
    public string? Email { get; init; }
    [Required(ErrorMessage = "Parola gereklidir.")]
    public string? Password { get; init; }
  }
}