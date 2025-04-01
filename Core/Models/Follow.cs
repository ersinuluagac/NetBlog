using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Follow : BaseEntity
    {
        // Properties

        // Navigation Properties
        public string FollowerId { get; set; }
        public virtual ApplicationUser Follower { get; set; }
        public string FollowingId { get; set; }
        public virtual ApplicationUser Following { get; set; }
    }
}
