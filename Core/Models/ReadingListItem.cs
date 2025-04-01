using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ReadingListItem : BaseEntity
    {
        // Properties

        // Navigation Properties
        public int ReadingListId { get; set; }
        public virtual ReadingList ReadingList { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
