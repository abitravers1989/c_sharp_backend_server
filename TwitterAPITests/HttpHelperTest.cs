using System;
using Xunit;
using TwitterAPI;

namespace TwitterAPITests
{
    public class HttpHelperTest
    {
        [Fact]
        public void MakeHttpRequest()
        {
            //Arrange
            var httphelper = new HttpHelper();
            var returnResult = "MoneySuperMarket - Helping You Msdfsde The Most Of Your Money";

            //Act
            var result = httphelper.MakeHttpRequest("https://jsonplaceholder.typicode.com/posts/1");

            //Assert
            Assert.Equal(returnResult, result);
         }


        [Fact]
        public void MakeHttpRequest_WhenApiCallFails_ThrowsError()
        {
            //Arrange
            var httphelper = new HttpHelper();
            var errorMessage = "Api did not respond";

            //Act
            var result = httphelper.MakeHttpRequest("https://jsonplaceholder.typicode.com/posts/foo");

            //Assert
            Assert.Equal(errorMessage, result);
        }


        [Fact]
        public void MakeHttpRequest_WhenMakesValidAPIRequest_ReturnsString()
        {
            //Arrange
            var httphelper = new HttpHelper();
            var errorMessage = "Api did not respond";

            //Act
            var result = httphelper.MakeHttpRequest("https://jsonplaceholder.typicode.com/posts/foo");

            //Assert
            Assert.Equal(errorMessage, result);
        }
    }

}
