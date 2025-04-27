using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Post
    {
        // Properties
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Summary { get; set; }
        public string? ImageUrl { get; set; }
        
        // Foreign Keys
        public int? CategoryId { get; set; }

        // Navigation Properties
        public Category? Category { get; set; }
    }
}
