using System;
using TwitterAPI.Models;

namespace TwitterAPI.Helpers
{
    public class ValidationHelper
    {
       public bool IsValidPost(Post blogPost, string password)
        {
            if (IsValidContent(blogPost) 
                && IsValidUser(blogPost) 
                && IsValidTitle(blogPost)
                && IsValidPassword(password))
            {
                return true;
            }
            return false;
        }

        public bool IsValidContent(Post blogPost)
        {
            if (String.IsNullOrEmpty(blogPost.Content))
            {
                return false;
            }
            return true;
            
        }
       
        public bool IsValidUser(Post blogPost)
        {
            //Need to make this envir variable
            return blogPost.UserName == "Abi";
        }

        public bool IsValidTitle(Post blogPost)
        {
            if (String.IsNullOrEmpty(blogPost.Title))
            {
                return false;
            }
            return true;

        }

        public bool IsValidPassword(string givenPassword)
        {
            return givenPassword == Environment.GetEnvironmentVariable("postEnviro");
        }

    }
}



// how to connect it to a db.
//how to test it in postman. (automated pm tests).