namespace Core.Models
{
  public class Like : BaseEntity
  {
    // Properties
    public int UserId { get; set; }
    public int PostId { get; set; }

    // Navigation Properties
    public User? User { get; set; }
    public Post? Post { get; set; }
  }
}