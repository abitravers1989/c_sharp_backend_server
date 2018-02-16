using System;
using System.Collections.Generic;

namespace TwitterAPI.Database
{
    public class SqlDatabase : IDatabase
    {
        public IEnumerable<string> GetAllTweets()
        {
            return new string[] { "Tweet1", "Tweet2", "Tweet3" };
        }
    }
}
