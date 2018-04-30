using System;
using System.Collections.Generic;
using TwitterAPI.Models;

namespace TwitterAPI.Database
{
    public class MongoDatabase : IDatabase
    {

        public Post CreatePosts(string blogContent, string blogTitle, string blogUserName)
        {
            var blogPost = new Post();
            blogPost.Content = blogContent;
            blogPost.PostTime = new DateTime();
            blogPost.Title = blogTitle;
            blogPost.UserName = blogUserName;
            return blogPost;
        }

        public IEnumerable<Post> CreateListOfPosts()
        {
            var blog1 = CreatePosts("This is the first blog post's content. At the min it only contains string", "Post Number 1", "Abi");
            var blog2 = CreatePosts("This is another blog post. NUMBER 2. Still just a string, boooo.", "Post Number 2", "Abi");
            var blog3 = CreatePosts(" NUMBER 3. Nothing fun here.", "Post Number 3", "Abi");
            return new Post[] { blog1, blog2, blog3 };
           
        }
        
        public IEnumerable<Post> GetAllPosts(){
            
            CreateListOfPosts();
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
