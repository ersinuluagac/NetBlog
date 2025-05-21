using Core.Models;

namespace UIWeb.Areas.Admin.Models
{
  public class CategoryCreateViewModel
  {
    public IEnumerable<Category> Categories { get; set; } = Enumerable.Empty<Category>();
    public Category NewCategory { get; set; } = new();
  }

}