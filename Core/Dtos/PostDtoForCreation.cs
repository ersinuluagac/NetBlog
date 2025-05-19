namespace Core.Dtos
{
  public record PostDtoForCreation : PostDto
  {
    public string? UserId { get; set; }
  }
}