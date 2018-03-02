using System;
using System.Collections.Generic;

namespace TwitterAPI.Database
{
    public class MongoDatabase : IDatabase
    {
        public IEnumerable<string> GetAllTweets(){
            return new string[] { "sheep", "pencilcase" };
        }

       
    }
}
