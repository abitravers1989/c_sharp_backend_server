using System;
using System.Collections.Generic;
using TwitterAPI.Models;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace TwitterAPI.Database
{

    //remanme as repository and irepository
    public class Repository : IRepository
    {
        private readonly MongoDatabase _mongoDatabse;
        public Repository(IOptions<Settings> settings){
            _mongoDatabse = new MongoDatabase(settings);
        }


        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            //return _mongoDatabse.Posts.Count(x => true).ToList();
            return await _mongoDatabse.posts.Find(x => true).ToListAsync();
        }

        public async Task<Post> GetPostByTitle(string title ){
          
            var returnedThing = await _mongoDatabse.posts.Find(x => x.Title == title).FirstOrDefaultAsync();
            return returnedThing;
        }

        public async Task AddPostToDatabase(Post blogPost){
           await _mongoDatabse.posts.InsertOneAsync(blogPost);

        }


        public async Task<bool> UpdateContent(Post blogPost){
            var getPostFromDB = GetPostByTitle(blogPost.Title);
            await _mongoDatabse.posts.UpdateOneAsync(post => post.Title == blogPost.Title, Builders<Post>.Update.Set(post => post.Content, blogPost.Content));
            return true;
        }
    }
}


