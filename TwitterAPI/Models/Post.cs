using System;
namespace TwitterAPI.Models
{
    public class Post
    {
        public string Content { get; set; }
        public string UserName { get; set; }
        public DateTime? PostTime { get; set; }
    }
}
