using System;
using MongoDB.Bson;


namespace TwitterAPI.Models
{
    public class Post
    {
        public ObjectId Id { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public DateTime? PostTime { get; set; }
        public string Title { get; set; }
        public DateTime? TimeUpdated { get; set; }
    }
}
