using MongoDB.Bson;
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

        public void AddUser(User user)
        {            
            _context.Users.InsertOne(user);                  
        }

        public bool CheckForDuplicateEmail(string email)
        {
            try
            {
                var duplicate = _context.Users.AsQueryable()
                                  .FirstOrDefault(p => p.Email == email);

                if (duplicate == null)              //Not in the db
                {
                    return false; 
                }
                
                return true;            
                
            }
            catch
            {
                return false;
            }
        }

        public bool CheckForDuplicateNumber(string phone_num)
        {
            try
            {
                var duplicate = _context.Users.AsQueryable()
                                  .FirstOrDefault(p => p.Phone == phone_num);

                if (duplicate == null)              //Not in the db
                {
                    return false;
                }

                return true;

            }
            catch
            {
                return false;
            }
        }
    }

}