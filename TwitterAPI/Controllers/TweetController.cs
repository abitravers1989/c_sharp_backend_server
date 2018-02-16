using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TwitterAPI.Database;

namespace TwitterAPI.Controllers
{
    [Route("api/tweet")]
    public class TweetController : Controller
    {
        //Get api/value
        [HttpGet]
        public IEnumerable<string> Get(IDatabase database){
            var databaseResults = database.GetAllTweets();
            return databaseResults;
        }
       
    }
}
