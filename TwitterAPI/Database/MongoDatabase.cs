using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TwitterAPI.Models;

namespace TwitterAPI.Database
{
    public class MongoDatabase
    {
        private readonly IMongoDatabase _database;

        public MongoDatabase(IOptions<Settings> settings)
        {
            try
            {
                var client = new MongoClient(settings.Value.ConnectionString);
                if (client != null)
                    _database = client.GetDatabase(settings.Value.Database);
            }
            catch(Exception ex)
            {
                throw new Exception("Can not access to MongoDb server.", ex);
            }
        }

        public IMongoCollection<Post> Posts => _database.GetCollection<Post>("Posts");
    }
}


//this is our database 
