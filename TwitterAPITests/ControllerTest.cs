using System;
using Xunit;
using TwitterAPI.Controllers;
using TwitterAPI.Database;
using System.Net;

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
        public void PostATweet_WhenPosted_ShouldReturnSameString()
        {
            //Arrange
            var expectedResult = "tweet2";
            var mySqlDatabase = new SqlDatabase();
            var tweetController = new TweetController(mySqlDatabase);

            //Act
            var result = tweetController.Post(expectedResult);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
