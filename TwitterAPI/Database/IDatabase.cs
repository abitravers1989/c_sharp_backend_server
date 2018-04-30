using System;
using System.Collections.Generic;
using TwitterAPI.Models;

namespace TwitterAPI.Database
{
    public interface IDatabase
    {
        IEnumerable<Post> GetAllPosts();
        //IEnumerable<String> GetAllPosts();
        Post GetPostByName(string name);

    }
}
