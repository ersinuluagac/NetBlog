namespace Core.Models
{
  public class Comment : BaseEntity
  {
    // Properties
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? UserId { get; set; }
    public int PostId { get; set; }

    // Navigation Properties
    public ApplicationUser? User { get; set; }
    public Post? Post { get; set; }
  }
}