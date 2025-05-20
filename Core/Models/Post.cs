using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Core.Models
{
    public class Post : BaseEntity
    {
        // Properties
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Summary { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Foreign Keys
        public string? UserId { get; set; }
        public int CategoryId { get; set; }

        // Navigation Properties
        public ApplicationUser? User { get; set; }
        public Category? Category { get; set; }
        public ICollection<Comment>? Comments { get; set; } = new List<Comment>();
        public ICollection<Like>? Likes { get; set; } = new List<Like>();
    }
}
