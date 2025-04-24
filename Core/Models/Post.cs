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
        [Required(ErrorMessage = "Gönderi başlığı zorunludur.")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Gönderi içeriği zorunludur.")]
        public string? Content { get; set; }
    }
}
