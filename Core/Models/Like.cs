namespace Core.Models
{
  public class Like : BaseEntity
  {
    // Properties
    public string? UserId { get; set; }
    public int PostId { get; set; }

    // Navigation Properties
    public ApplicationUser? User { get; set; }
    public Post? Post { get; set; }
  }
}