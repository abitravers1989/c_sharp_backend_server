using System;
using System.Collections.Generic;

namespace TwitterAPI.Database
{
    public interface IDatabase
    {
        IEnumerable<string> GetAllTweets();


    }
}
