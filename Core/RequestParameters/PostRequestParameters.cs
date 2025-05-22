namespace Core.RequestParameters
{
  public class PostRequestParameters : RequestParameters
  {
    // PROP
    public int? CategoryId { get; set; } //Kategori filtrelemek için
    public int PageNumber { get; set; } //Pagination için sayfa numarası
    public int PageSize { get; set; } //Pagination için sayfa büyüklüğü

    // CTORs
    public PostRequestParameters() : this(1, 6)
    {
      // Varsayılan olarak pageNumber 1 ve pageSize 6 verilir.
    }

    public PostRequestParameters(int pageNumber, int pageSize)
    {
      PageNumber = pageNumber;
      PageSize = pageSize;
    }
  }
}