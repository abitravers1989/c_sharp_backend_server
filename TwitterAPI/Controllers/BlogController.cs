using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TwitterAPI.Database;
using TwitterAPI.Models;
using TwitterAPI.Helpers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TwitterAPI.Logging;

namespace TwitterAPI.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is the Home Page!");
        }
    }

    [Route("posts")]
    public class BlogController : Controller
    {

        private readonly IRepository _database;
        private readonly ILogger _logger;
        private readonly ValidationHelper _validationHelper; 

        public BlogController(IRepository database, ILogger<BlogController> logger)
        {
            _database = database;
            _logger = logger;
            _validationHelper = new ValidationHelper();
        }

        [HttpGet]
        public Task<IEnumerable<Post>> Get()
        {
            return _database.GetAllPosts();
        }
         
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            _logger.LogInformation(LoggingEvents.GetItem, "Getting post {name}", name);
            try
            {
                var foundPost = await _database.GetPostByTitle(name);
                if (foundPost == null)
                {
                    _logger.LogWarning(LoggingEvents.GetItemNotFound, "Get({name}) NOT FOUND", name);
                    return NotFound("not found");
                }
                return Ok(foundPost);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, ex, "Get({name}) NOT FOUND", name);
                return Json(ex.ToString());
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Post clientBlogPost)
        {
            var password = Request.Headers["clinetPassword"];
            try
            {
                if (!_validationHelper.IsValidPost(clientBlogPost, password))
                     return BadRequest("Please enter a valid post");
                
                clientBlogPost.PostTime = DateTime.UtcNow;
                await _database.AddPostToDatabase(clientBlogPost);
                return Ok($"Blog Post saved to db find this at /posts/{clientBlogPost.Title}");

            }

            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }


        [HttpPut("{name}")]
        public async Task<IActionResult> UpdateContent([FromBody]Post clientBlogPost)
        {
            var password = Request.Headers["clinetPassword"];
            //updated time
            clientBlogPost.TimeUpdated = DateTime.UtcNow;

            if (!_validationHelper.IsValidPost(clientBlogPost, password))
                return BadRequest("Please enter a valid post");
            var result = await _database.UpdateBlogContent(clientBlogPost);
            if (!result)
                return BadRequest("Please enter valid post content");
            
            return Ok($"blog post updated and found at /posts/{clientBlogPost.Title}");

        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]string blogPostTitle){

            var password = Request.Headers["clinetPassword"];
            try {
                if (string.IsNullOrWhiteSpace(blogPostTitle) && !(_validationHelper.IsValidPassword(password)))
                    return BadRequest("Post title is missing");
                await _database.RemovePost(blogPostTitle);
                return Ok("Your product has been deleted successfully");
            }
            catch (Exception ex){
                return BadRequest(ex.ToString());
            }
        }

    }

}


