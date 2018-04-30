using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TwitterAPI.Database;
using TwitterAPI.Models;
using TwitterAPI.Helpers;




namespace TwitterAPI.Controllers
{
    //[Route("api/[controller]")]

    // if this was MVC we would be returning views razors .. point where front and back end meet.

    [Route("posts")]
    public class BlogController : Controller
    {
        
        private readonly IDatabase _database; 


        public BlogController(IDatabase database)
        { 
            _database = database; 
        }


        [HttpGet]
        public IEnumerable<Post>  Get(){
            var databaseResults = _database.GetAllPosts();
            return databaseResults;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Post clientTweet){

            var validationHelper = new ValidationHelper();

            if (validationHelper.IsValidPost(clientTweet)){
                return Ok(clientTweet.Content);
            }

            return BadRequest();
        }


        [HttpGet("{name}")]
        public Post Get(string name)
        {
            var post = _database.GetPostByName(name);
            //eventually will go to db and say get post with this name
            return post;
        }
       
    }
}


//which DB to use 
