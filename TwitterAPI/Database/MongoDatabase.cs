using System;
using System.Collections.Generic;
using TwitterAPI.Models;

namespace TwitterAPI.Database
{
    public class MongoDatabase : IDatabase
    {
        public Post GetAllTweets(){
            var blogPost = new Post();
            var validPost = "blog post 1 gedhsjkdgdhjkhwjksahsdjka";
            blogPost.Content = validPost;
            var validDate = new DateTime();
            blogPost.PostTime = validDate;
            var userName = "Abi";
            blogPost.UserName = userName;
            return blogPost;
        }

        public Post GetPostByName(string name ){
            var newBlogPost = new Post();

            newBlogPost.Title = name;
            newBlogPost.Content = "Blog post with name set";
            return newBlogPost;

            //eventually have if name doesn't exist then return error / 404
            //if it does get it
            //is valid request ? 
        }

       
    }
}
