using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace UserApplication
{
    public static class CloudinaryHelper
    {
        private static readonly Cloudinary _cloudinary;

        static CloudinaryHelper()
        {
            var account = new Account(
                ConfigurationManager.AppSettings["Cloudinary.CloudName"],
                ConfigurationManager.AppSettings["Cloudinary.ApiKey"],
                ConfigurationManager.AppSettings["Cloudinary.ApiSecret"]
            );

            _cloudinary = new Cloudinary(account);
        }

        public static string UploadImage(Stream imageStream, string fileName)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, imageStream)
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            // Return the URL of the uploaded image
            return uploadResult.SecureUri.ToString();
        }
    }
}