namespace Core.Models
{
  public class Category : BaseEntity
  {
    // Properties
    public string? Name { get; set; } = string.Empty;

    // Navigation Properties
    public ICollection<Post>? Posts { get; set; } = new List<Post>();
  }
}