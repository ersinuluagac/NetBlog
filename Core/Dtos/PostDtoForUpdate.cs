namespace Core.Dtos
{
  public record PostDtoForUpdate : PostDto
  {
    public int Id { get; init; }
    public string? UserId { get; init; }
  }
}