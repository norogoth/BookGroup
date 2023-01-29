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
    }
}
