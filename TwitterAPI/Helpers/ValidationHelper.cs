using System;
using TwitterAPI.Models;

namespace TwitterAPI.Helpers
{
    public class ValidationHelper
    {
       public bool IsValidPost(Post blogPost)
        {
            if (IsValidContent(blogPost) && IsValidUser(blogPost))
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
            return blogPost.UserName == "Abi";
        }
    }
}



// how to connect it to a db.
//how to test it in postman. (automated pm tests).