using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaceGram.Database.EF;
using FaceGram.Models;
using FaceGram.Service;

namespace FaceGram.Controllers
{
    public class MyProfileController : BaseUserController
    {
        private IProfileService profileService;


        public MyProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        // GET: MyProfile
        public ActionResult Index(string id)
        {
            string loginedUserId = getUserIdInSession();
            ProfileModel profileModel = profileService.getProfileModel(id, loginedUserId);


            return View(profileModel);
        }
    }
}