using System;
using System.Collections.Generic;
using TwitterAPI.Models;

namespace TwitterAPI.Database
{
    public interface IDatabase
    {
        Post GetAllTweets();
        Post GetPostByName(string name);

    }
}
