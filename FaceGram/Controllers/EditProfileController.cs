using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaceGram.Models;
using FaceGram.Service;

namespace FaceGram.Controllers
{
    public class EditProfileController : BaseUserController
    {
        private IEditProfileService editProfileService;


        public EditProfileController(IEditProfileService editProfileService)
        {
            this.editProfileService = editProfileService;
        }

        // GET: EditProfile
        public ActionResult Index()
        {
            string userID = getUserInSession().Id;

            UserProfileModel userProfileModel = editProfileService.getUser(userID);

            return View(userProfileModel);
        }

        public ActionResult EditProfile(UserProfileModel model)
        {
            if(ModelState.IsValid)
            {
                editProfileService.editUserProfile(model, getUserInSession().Id);
                return RedirectToAction("Index", "MyProfile");
            }
            return View("Index");
            
        }
    }
}