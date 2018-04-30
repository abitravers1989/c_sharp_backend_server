using System;
using Xunit;
using TwitterAPI.Controllers;
using TwitterAPI.Database;
using TwitterAPI.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace TwitterAPITests
{
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

    }

};
