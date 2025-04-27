using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
  public record PostDto // record çünkü değiştirilemez, sadece veri taşır.
  {
    // set yerine init çünkü nesne oluştuktan sonra değiştirilemez, record mantığına uygun.
    public int Id { get; init; }
    [Required(ErrorMessage = "Gönderi başlığı zorunludur.")]
    public string? Title { get; init; }
    [Required(ErrorMessage = "Gönderi içeriği zorunludur.")]
    public string? Content { get; init; }
    public string? Summary { get; init; }
    public string? ImageUrl { get; set; } // atama işlemi daha sonra yapılacağı için "set".
    public int? CategoryId { get; init; }

  }
}