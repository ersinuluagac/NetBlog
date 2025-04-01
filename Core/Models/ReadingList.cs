using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ReadingList : BaseEntity
    {
        // Properties
        public string Name { get; set; }
        public bool IsVisible { get; set; } = true;

        // Navigation Properties
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<ReadingListItem> Items { get; set; }
    }
}
