using System;
using Xunit;
using TwitterAPI.Controllers;
using TwitterAPI.Database;
using TwitterAPI.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace TwitterAPITests
{
    public class TweetControllerTests
    {
        [Fact]
        public void GetAllTweetsMongoDB()
        {
            //Arrange

            var expectedResultMongo = new string[] { "sheep", "pencilcase" };
            var myMongoDB = new MongoDatabase();
            var tweetController = new TweetController(myMongoDB);

            //Act 
            var result = tweetController.Get();

            // Assert 
            Assert.Equal(expectedResultMongo, result);
        }

        [Fact]
        public void GetAllTweetsSqlDB()
        {
            //Arrange
            var expectedResultSQL = new string[] { "Tweet1", "Tweet2", "Tweet3" };
            var mySqlDatabase = new SqlDatabase();
            var tweetController = new TweetController(mySqlDatabase);

            //Act 
            var result = tweetController.Get();

            // Assert 
            Assert.Equal(expectedResultSQL, result);
        }

        // fact needs to return either tru or false 
     

        [Fact]
        public void PostATweet_WhenPosted_ShouldReturnOKstatusCode()
        {
            //Arrange

            var mySqlDatabase = new SqlDatabase();
            var tweetController = new TweetController(mySqlDatabase);
            var blogPost = GetValidPost();
           

            //Act
            var result = tweetController.Post(blogPost);
           
            //Assert
           Assert.IsType<OkObjectResult>(result);
          
        }

        [Fact]
        public void PostATweet_WhenPosted_ShouldReturnSameString()
        {
            //Arrange

            var mySqlDatabase = new SqlDatabase();
            var tweetController = new TweetController(mySqlDatabase);
            var blogPost = GetValidPost();
            var expectedResult = blogPost.Content;

            //Act
            var result = tweetController.Post(blogPost);
            var model = result as OkObjectResult;

            //Assert
            Assert.Equal(expectedResult, model.Value);

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
}
