using System.ComponentModel.DataAnnotations;

namespace UIWeb.Models
{
  public class SignInModel
  {
    private string? _returnUrl;

    [Required(ErrorMessage = "Kullanıcı adı gerekli.")]
    public string? Username { get; set; }
    [Required(ErrorMessage = "Parola gerekli.")]
    public string? Password { get; set; }

    public string ReturnUrl
    {
      get
      {
        if (_returnUrl is null)
          return "/";
        else
          return _returnUrl;
      }
      set
      {
        _returnUrl = value;
      }
    }
  }
}