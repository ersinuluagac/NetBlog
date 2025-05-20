namespace Core.Dtos
{
  public record LikeDto
  {
    public string? UserId { get; set; }
    public int PostId { get; set; }
  }
}