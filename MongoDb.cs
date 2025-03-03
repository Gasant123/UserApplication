using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static UserApplication.Models.MongoDbModel;

namespace UserApplication
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext()
        {
            var connectionString = System.Configuration.ConfigurationManager.AppSettings["MongoDbConnectionString"];
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(System.Configuration.ConfigurationManager.AppSettings["MongoDbDatabase"]);
        }

        // Get a collection for the "Users" collection
        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
    }
}