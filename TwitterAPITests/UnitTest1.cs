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
            var tweetController = new TweetController();
            var expectedResult = new string[] { "sheep", "pencilcase" };
            var myMongoDB = new MongoDatabase();

            //Act 
            var result = tweetController.Get(myMongoDB);

            // Assert 
            Assert.Equal(expectedResult, result);
        }
    }
}
