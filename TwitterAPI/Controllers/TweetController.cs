using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TwitterAPI.Database;
using TwitterAPI.Models;




namespace TwitterAPI.Controllers
{
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
        public IActionResult Post([FromBody]Tweet clientTweet){
            return Ok();
        }
       
    }
}
