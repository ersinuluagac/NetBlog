namespace Core.Dtos
{
  public record PostDtoForUpdate : PostDto
  {
    public int Id { get; init; }
  }
}