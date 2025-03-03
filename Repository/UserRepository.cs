using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static UserApplication.Models.MongoDbModel;

namespace UserApplication.Repository
{
    public class UserRepository
    {
        private readonly MongoDbContext _context;
        private readonly string _connectionString = "mongodb+srv://mujahid:gasantmujahid@cluster0.ojbmp.mongodb.net/?authSource=admin&amp;appName=Cluster0";

        public UserRepository()
        {
            _context = new MongoDbContext();
        }

        //public async Task<bool> CheckMongoConnectionAsync()
        //{
        //    var client = new MongoClient(_connectionString);
        //    try
        //    {
        //        // Attempt to get a list of databases as a way to verify the connection
        //        var databases = await client.ListDatabasesAsync();
        //        await databases.ToListAsync();  // Execute the command to ensure the connection is working
        //        Console.WriteLine("Successfully connected to MongoDB Atlas!");
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exceptions and connection failure
        //        Console.WriteLine($"Error connecting to MongoDB Atlas: {ex.Message}");
        //        return false;
        //    }
        //}

        public void AddUser(User user)
        {
            //if (CheckForDuplicateEmail(user.Email))
            //{

            //}
            _context.Users.InsertOne(user); 
        }

        public bool CheckForDuplicateEmail(string email)
        {
            try
            {
                var duplicate = _context.Users.AsQueryable()
                                  .FirstOrDefault(p => p.Email == email);

                return duplicate != null;
            }
            catch
            {
                return false;
            }
        }
    }

}