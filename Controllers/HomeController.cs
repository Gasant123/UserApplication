using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserApplication.Models;
using UserApplication.Repository;
using static UserApplication.Models.MongoDbModel;

namespace UserApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserRepository _userRepository;

        public HomeController()
        {
            _userRepository = new UserRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SignUp()
        {
            var successMessage = TempData["SuccessMessage"] as string;

            ViewBag.SuccessMessage = successMessage;

            var errorMessage = TempData["errorMessage"] as string;

            ViewBag.ErrorMessage = errorMessage;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SignUpModel model)
        {
            if (ModelState.IsValid)
            {

                if (model.ProfilePicture != null && model.ProfilePicture.ContentLength > 0)
                {
                    var imageUrl = CloudinaryHelper.UploadImage(model.ProfilePicture.InputStream, model.ProfilePicture.FileName);

                    model.ProfilePictureUrl = imageUrl;
                }

                var user = new User
                {
                    Name = model.First_Name,
                    Surname = model.Last_Surname,
                    Email = model.Email,
                    ProfilePictureUrl = model.ProfilePictureUrl
                };

                if (_userRepository.CheckForDuplicateEmail(model.Email))
                {
                    TempData["ErrorMessage"] = "Duplicate email , please use alternative.";
                }

                else
                {
                    _userRepository.AddUser(user);
                    TempData["SuccessMessage"] = "The record was created successfully!";
                }
                
                return RedirectToAction("SignUp");
            }

            return View();
        }

        public ActionResult SignUpUpdated()
        {
            var successMessage = TempData["SuccessMessage"] as string;

            ViewBag.SuccessMessage = successMessage;

            var errorMessage = TempData["errorMessage"] as string;

            ViewBag.ErrorMessage = errorMessage;

            SignUpNewModel test = new SignUpNewModel();

            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUpUpdated(SignUpNewModel model)
        {
            if (ModelState.IsValid)
            {

                if (model.ProfilePicture != null && model.ProfilePicture.ContentLength > 0)
                {
                    var imageUrl = CloudinaryHelper.UploadImage(model.ProfilePicture.InputStream, model.ProfilePicture.FileName);

                    model.ProfilePictureUrl = imageUrl;
                }

                var user = new User
                {
                    Name = model.First_Name,
                    Surname = model.Last_Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    ProfilePictureUrl = model.ProfilePictureUrl
                };

                if (_userRepository.CheckForDuplicateEmail(model.Email))
                {
                    TempData["ErrorMessage"] = "Duplicate email , please use alternative.";
                }

                else if (_userRepository.CheckForDuplicateNumber(model.Phone))
                {
                    TempData["ErrorMessage"] = "Duplicate phone number , please use alternative.";
                }

                else
                {
                    _userRepository.AddUser(user);
                    TempData["SuccessMessage"] = "The record was created successfully!";
                }

                return RedirectToAction("SignUpUpdated");
            }

            return View();
        }

    }
}