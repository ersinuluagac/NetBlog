namespace Core.RequestParameters
{
  public class PostRequestParameters : RequestParameters
  {
    public int? CategoryId { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public PostRequestParameters() : this(1, 6)
    {

    }

    public PostRequestParameters(int pageNumber, int pageSize)
    {
      PageNumber = pageNumber;
      PageSize = pageSize;
    }
  }
}