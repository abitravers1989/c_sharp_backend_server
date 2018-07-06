using System;
using MongoDB.Bson;


namespace TwitterAPI.Models
{
    public class Post
    {
        public ObjectId Id { get; set; }
        public string Content { get; set; }
        //way to put image object
        public string UserName { get; set; }
        public DateTime? PostTime { get; set; }
        public string Title { get; set; }
        public DateTime? TimeUpdated { get; set; }
        public CategoryTag categoryTags { get; set; }
    }
}
