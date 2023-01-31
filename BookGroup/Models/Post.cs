using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using BookGroup.Services;

namespace BookGroup.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public int CreatorUserId { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Please give me something longer than that UwU.")]
        public string Quote { get; set; }
        public string QuoteLocation { get; set; }
        public string Note { get; set; }
        public override string ToString() => JsonSerializer.Serialize<Post>(this);
        /*
        public Post(int userId, string quote)
        {
            //int Id = JsonFilePostsService.GetNewId();
            CreatorUserId = userId;
            //quote = quote;

        }
        */
    }

}
