using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace BookGroup.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public int CreatorUserId { get; set; }
        public string Quote { get; set; }
        public string Note { get; set; }
        public override string ToString() => JsonSerializer.Serialize<Post>(this);
    }
}
