namespace Core.Models
{
  public class Notifiction
  {
    // Properties
    public int Id { get; set; }
    public string? Message { get; set; }
    public string? Url { get; set; }
    // public bool IsRead { get; set; }
    // public DateTime CreatedAt { get; set; }

    // Foreign Keys
    // public string UserId { get; set; }

    // Navigation Properties
    // public AppUser User { get; set; }
  }
}