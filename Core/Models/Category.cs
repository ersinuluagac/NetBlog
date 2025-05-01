namespace Core.Models
{
  public class Category
  {
    // Properties
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;

    // Navigation Properties
    public ICollection<Post>? Posts { get; set; }
  }
}