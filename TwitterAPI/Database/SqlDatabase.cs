using System;
using System.Collections.Generic;
using TwitterAPI.Models;

namespace TwitterAPI.Database
{
    public class SqlDatabase : IDatabase
    {
        public Post GetAllTweets()
        {
            var blogPost = new Post();
            var validPost = "blog post 1 gedhsjkdgdhjkhwjksahsdjka";
            blogPost.Content = validPost;
            var validDate = new DateTime();
            blogPost.PostTime = validDate;
            var userName = "Abi";
            blogPost.UserName = userName;
            return blogPost;
        }

    }
}
