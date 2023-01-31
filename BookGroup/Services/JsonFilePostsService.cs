using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BookGroup.Models;
using Microsoft.AspNetCore.Hosting;

namespace BookGroup.Services
{
    public class JsonFilePostsService
    {
        public JsonFilePostsService (IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }

        public string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "posts.json"); }
        }
        public IEnumerable<Post> GetPosts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
            return JsonSerializer.Deserialize<Post[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
        }
        public void AddPost(int userId, string quote)
        {
            IEnumerable<Post> posts = GetPosts();
            //Post newPost = new Post(userId, quote);
            //posts.Add(newPost);
        }
        public int GetNewId()
        {
            IEnumerable<Post> posts = GetPosts();
            int maxId = 0;
            foreach (Post post in posts)
            {
                if (post.Id > maxId)
                {
                    maxId = post.Id;
                }
            }
            return maxId + 1;
        }
    }
}
