using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TwitterAPI.Database;
using TwitterAPI.Models;
using TwitterAPI.Helpers;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TwitterAPI.Controllers
{
    //[Route("api/[controller]")]

    // if this was MVC we would be returning views razors .. point where front and back end meet.

    [Route("posts")]
    public class BlogController : Controller
    {

        private readonly IRepository _database;


        public BlogController(IRepository database)
        {
            _database = database;
        }

        //Attempting to try to return a JSON object instead of an aray
        [HttpGet]
        public Task<IEnumerable<Post>> Get()
        {
            return _database.GetAllPosts();
        }



        //grab path from url 
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var foundPost = await _database.GetPostByTitle(name);
                if (foundPost == null)
                {
                    return NotFound("not found");
                }
                return Ok(foundPost);
            }
            catch (Exception ex)
            {
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



        [HttpPut("{name}")]
        public async Task<IActionResult> UpdateTitle([FromBody]Post blogPost)
        {
            try
            {
                blogPost.TimeUpdated = DateTime.UtcNow;
                var result = await _database.UpdateBlogTitle(blogPost);
                if (result)
                {
                    return Ok($"blog post updated and found at /posts/{blogPost.Title}");
                }

                return BadRequest("Please enter a valid post");
            }

                catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
    }





}

//which DB to use 
