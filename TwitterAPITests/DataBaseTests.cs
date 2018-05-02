using System;
using Xunit;
using TwitterAPI.Controllers;
using TwitterAPI.Database;
using TwitterAPI.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace TwitterAPITests
{

    //rename to repository 
    public class DatabaseTests
    {
        [Fact]
        public void CreateListOfPosts()
        {
            //Arrange
            var myMongoDB = new MongoDatabase();
            var expectedResult = new Post[] { "This is the first blog post's content. At the min it only contains string", "Post Number 1", "Abi" };


            //Act 
            var result = myMongoDB.CreateListOfPosts();

            // Assert 
            Assert.Equal(expectedResult, result);
        }

        private Post GetValidPost()
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

};
