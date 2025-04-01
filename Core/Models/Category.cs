using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Category : BaseEntity
    {
        // Properties
        public string Name { get; set; }

        // Navigation Properties
        public virtual ICollection<Post> Posts { get; set; }
    }
}
