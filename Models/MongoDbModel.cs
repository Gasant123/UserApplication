using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserApplication.Models
{
    public class MongoDbModel
    {
        public class User
        {
            [BsonId]
            public ObjectId Id { get; set; } // MongoDB ID (auto-generated)
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string ProfilePictureUrl { get; set; } // Store the URL of the profile picture
        }

    }
}