using System;
using Xunit;
using TwitterAPI.Helpers;
using TwitterAPI.Models;

namespace TwitterAPITests
{
    public class ValidationHelperTests
    {
        [Fact]
        public void IsValidPost_WhenPassedValidPost_ReturnsTrue()
        {
            //Arrange 
            var validationHelper = new ValidationHelper();
            var blogPost = new Post();
            var validPost = "blog post 1 gedhsjkdgdhjkhwjksahsdjka";
            blogPost.Content = validPost;
            var validDate = new DateTime();
            blogPost.PostTime = validDate;
            var userName = "Abi";
            blogPost.UserName = userName;


            //Act
            var result = validationHelper.IsValidPost(blogPost);

            //Assert 
            Assert.True(result);
        }

        [Fact]
       public void IsValidPost_WhenPassedInvalidPost_ThrowsError()
        {
            //Arrange 
            var validationHelper = new ValidationHelper();
            var blogPost = new Post();
            var userName = "Tom";
            blogPost.UserName = userName;

            //Act
            var result = validationHelper.IsValidPost(blogPost);

            //Assert 
            Assert.False(result);
        }
    }
}
