using System;
using System.Collections.Generic;
using TwitterAPI.Models;

namespace TwitterAPI.Database
{
    public interface IRepository
    {
        IEnumerable<Post> GetAllPosts();
        //IEnumerable<String> GetAllPosts();
        Post GetPostByName(string name);
        bool SavePost(Post blogPost);

    }
}
