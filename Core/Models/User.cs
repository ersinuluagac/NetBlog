namespace Core.Models
{
  public class User
  {
    public int Id { get; set; }
    public string? UserName { get; set; }
    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<Like> Likes { get; set; } = new List<Like>();
  }
}