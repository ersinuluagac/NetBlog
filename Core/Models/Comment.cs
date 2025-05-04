namespace Core.Models
{
  public class Comment : BaseEntity
  {
    // Properties
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }

    // Navigation Properties
    public User? User { get; set; }
    public Post? Post { get; set; }
  }
}