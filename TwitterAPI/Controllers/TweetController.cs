using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TwitterAPI.Database;
using TwitterAPI.Models;




namespace TwitterAPI.Controllers
{
    //[Route("api/[controller]")]

    [Route("api/tweets")]
    public class TweetController : Controller
    {
        
        private readonly IDatabase _database; 


        public TweetController(IDatabase database)
        { 
            _database = database; 
        }


        [HttpGet]
        public IEnumerable<string> Get(){
            var databaseResults = _database.GetAllTweets();
            return databaseResults;
        }

        [HttpPost]
        //telling controller to look in the body of the request for the string
        //FromBody maps JSON to C sharp object.. so tweet model in this case
        public IActionResult Post([FromBody]Tweet clientTweet){
            return Ok(clientTweet.Content);
            //can access info in the head of the request

            //can build logic for if tweet.content is a certain length send error etc

            // then save it to db is it passes all tests
        }
       
    }
}
