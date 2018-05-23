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
        public Task<IEnumerable<Post>>Get() {
            return _database.GetAllPosts();
        }

        [HttpPost]
        //eventually where we save it
        public IActionResult Post([FromBody]Post clientBlogPost){

            var validationHelper = new ValidationHelper();

            if (validationHelper.IsValidPost(clientBlogPost)){
                var hasSaved = _database.SavePost(clientBlogPost);
                if (hasSaved) return Ok("blogpostCreated");
            }

            return BadRequest();
        }


        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var foundPost = await _database.GetPostByTitle(name);
            if (foundPost == null){
                return NotFound("not found");
            }
            return Ok(foundPost);
        }

       
    }
}


//which DB to use 
