using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookGroup.Services;
using BookGroup.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookGroup.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        public JsonFilePostsService PostsService { get;  }
        public PostsController(JsonFilePostsService postsService)
        {
            this.PostsService = postsService;
        }
        public IEnumerable<Post> Get()
        {
            return PostsService.GetPosts();
        }
        //implement form submit that changes json here
        public ActionResult Get([FromQuery] int UserId, [FromQuery] string Quote)
        {
            //PostsService.AddPost(postData);
            return Ok(); //prevent 404
        }
    }
}
