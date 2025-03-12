using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserApplication.Models
{
    public class SignUpNewModel
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //public IFormFile ProfilePicture { get; set; }
        public HttpPostedFileBase ProfilePicture { get; set; }
        public string ProfilePictureUrl { get; set; } // Add this property to store the URL

        // To keep track of which step is active
        public int CurrentStep = 1;
    }
}