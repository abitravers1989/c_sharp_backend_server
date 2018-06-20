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
    [Route("posts")]
    public class BlogController : Controller
    {

        private readonly IRepository _database;
        private readonly ILogger _logger;

        public BlogController(IRepository database, ILogger<BlogController> logger)
        {
            _database = database;
            _logger = logger;
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

        //eventually where we save it
        public async Task<IActionResult> Post([FromBody]Post clientBlogPost)
        {
            try
            {

                var validationHelper = new ValidationHelper();

                if (validationHelper.IsValidPost(clientBlogPost))
                {
                    clientBlogPost.PostTime = DateTime.UtcNow;
                    await _database.AddPostToDatabase(clientBlogPost);
                    //var hasSaved = _database.SavePost(clientBlogPost);
                    //if (hasSaved) return Ok("Blog Post Created");
                    return Ok($"Blog Post saved to db find this at /posts/{clientBlogPost.Title}");
                }

                return BadRequest("Please enter a valid post");

            }

            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }


        [HttpPut("{name}")]
        public async Task<IActionResult> UpdateContent([FromBody]Post blogPost)
        {
            //updated time
            blogPost.TimeUpdated = DateTime.UtcNow;
            var result = await _database.UpdateBlogContent(blogPost);
            if (result)
            {
                return Ok($"blog post updated and found at /posts/{blogPost.Title}");
            }
            return BadRequest("Please enter valid post content");

        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]string blogPostTitle){
            try {
                if (string.IsNullOrWhiteSpace(blogPostTitle))
                    return BadRequest("Post title is missing");
                await _database.RemovePost(blogPostTitle);
                return Ok("Your product has been deleted successfully");
            }
            catch (Exception ex){
                return BadRequest(ex.ToString());
            }
        }



        //public async Task<IActionResult> UpdateTitle([FromBody]Post blogPost)
        //{
        //    try
        //    {
        //        blogPost.TimeUpdated = DateTime.UtcNow;
        //        var result = await _database.UpdateBlogTitle(blogPost);
        //        if (result)
        //        {
        //            return Ok($"blog post updated and found at /posts/{blogPost.Title}");
        //        }

        //        return BadRequest("Please enter a valid post");
        //    }

        //        catch (Exception ex)
        //    {
        //        return BadRequest(ex.ToString());
        //    }

        //}
    }





}

//which DB to use 
