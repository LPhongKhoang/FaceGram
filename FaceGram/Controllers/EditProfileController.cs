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

        
        [HttpPost]
        public ActionResult EditProfile(UserProfileModel model)
        {
            if(ModelState.IsValid)
            {
                editProfileService.editUserProfile(model, getUserInSession().Id);
                return RedirectToAction("Index", "MyProfile");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Inputs invalid");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult EditProfile()
        {
            string userID = getUserInSession().Id;

            UserProfileModel userProfileModel = editProfileService.getUser(userID);

            return View(userProfileModel);
        }
    }
}