using Microsoft.AspNetCore.Identity;

namespace Core.Models
{
  public class ApplicationUser : IdentityUser
  {
    // Navigation Properties
    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<Like> Likes { get; set; } = new List<Like>();
  }
}