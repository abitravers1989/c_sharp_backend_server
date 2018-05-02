using System;
using System.Collections.Generic;
using TwitterAPI.Models;

namespace TwitterAPI.Database
{

    //remanme as repository and irepository
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
            List<Post> blogPosts = new List<Post>{
                CreatePosts("This is the first blog post's content. At the min it only contains string", "Post Number 1", "Abi"),
                CreatePosts("This is another blog post. NUMBER 2. Still just a string, boooo.", "Post Number 2", "Abi"),
                CreatePosts(" NUMBER 3. Nothing fun here.", "Post Number 3", "Abi")
            };

            return blogPosts;
        }
        
        public IEnumerable<Post> GetAllPosts(){
             return CreateListOfPosts();
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

        //in frontend write a ajax request in front end which will send stuff to this api 
        //this will take json and turn it into an object.. deserialise json into object 

        public bool SavePost(Post blogPostToSave){
            //this is where db code will go
            //open db connection 
            //then save object 
            //if suceeds return true.
            Console.WriteLine(blogPostToSave.Content);
            return true; 
        }

       
    }
}
