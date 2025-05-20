using Core.Models;

namespace Core.Dtos
{
  public record PostDtoWithDetails : PostDto
  {
    public int Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public ApplicationUser? User { get; set; }
    public Category? Category { get; set; }
    public ICollection<Comment>? Comments { get; set; } = new List<Comment>();
    public ICollection<Like>? Likes { get; set; } = new List<Like>();
  }
}