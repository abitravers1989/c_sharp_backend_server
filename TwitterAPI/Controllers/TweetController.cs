using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TwitterAPI.Database;

namespace TwitterAPI.Controllers
{
    [Route("api/tweet")]
    public class TweetController : Controller
    {
        private readonly IDatabase _database; 

        public TweetController(IDatabase database)
        { 
            _database = database; 
        }


        //Get api/value
        [HttpGet]
        public IEnumerable<string> Get(){
            var databaseResults = _database.GetAllTweets();
            return databaseResults;
        }
       
    }
}
