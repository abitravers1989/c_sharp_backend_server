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
        public IActionResult Post([FromBody]Post clientTweet){

            var validationHelper = new ValidationHelper();

            if (validationHelper.IsValidPost(clientTweet)){
                return Ok(clientTweet.Content);
            }

            //client error, 400, client error. invalid info from the client.
            return BadRequest();
           

            //here do validation .. here is where people inject stuff into your db.

            // instead of sending real post they send js and that would execute js on browsers.



 
            //can access info in the head of the request

            //can build logic for if tweet.content is a certain length send error etc

            // then save it to db is it passes all tests
        }
       
    }
}
