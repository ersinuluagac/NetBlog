using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
  public record CommentDto
  {
    [Required(ErrorMessage = "Başlık boş bırakılamaz.")]
    public string? Title { get; set; }
    [Required(ErrorMessage = "İleti boş bırakılamaz.")]
    public string? Content { get; set; }
    public string? UserId { get; set; }
    public int PostId { get; set; }
  }
}