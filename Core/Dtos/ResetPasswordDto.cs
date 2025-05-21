using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
  public record ResetPasswordDto
  {
    public string? UserName { get; set; }
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Eski parola gereklidi")]
    public string? OldPassword { get; set; }
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Parola gereklidir.")]
    [MinLength(6, ErrorMessage = "Parola en az 6 karakter içermeli.")]
    public string? Password { get; init; }
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Parola onayı gereklidir.")]
    [Compare("Password", ErrorMessage = "Parola ve Parola onayı eşleşmelidir.")]
    public string? ConfirmPassword { get; init; }
  }
}