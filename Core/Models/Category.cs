namespace Core.Models
{
  public class Category : BaseEntity
  {
    // Properties
    public string? Name { get; set; }

    // Navigation Properties
    public ICollection<Post>? Posts { get; set; } = new List<Post>();
  }
}