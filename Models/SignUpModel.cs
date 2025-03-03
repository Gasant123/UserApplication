using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserApplication.Models
{
    public class SignUpModel
    {
        [BsonId] // This attribute tells MongoDB this is the _id field.
        public ObjectId Id { get; set; } // The type should be ObjectId, or you can use string if you want custom IDs
        [Required]
        [StringLength(100)]
        public string First_Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Last_Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public HttpPostedFileBase ProfilePicture { get; set; }

        public string ProfilePictureUrl { get; set; } // Add this property to store the URL
    }
}