using System;
using Xunit;
using TwitterAPI.Controllers;
using TwitterAPI.Database;

namespace TwitterAPITests
{
    public class TweetControllerTests
    {
        [Fact]
        public void GetAllTweets()
        {
            //Arrange

            var expectedResult = new string[] { "sheep", "pencilcase" };
            var myMongoDB = new SqlDatabase();
            var tweetController = new TweetController(myMongoDB);

            //Act 
            var result = tweetController.Get();

            // Assert 
            Assert.Equal(expectedResult, result);
        }
    }
}
