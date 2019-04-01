using FaceGram.Models;
using FaceGram.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaceGram.Controllers
{
    public class ExploreController : BaseUserController
    {
        private IRelationshipService relationshipService;
        private IUserService userService;

        public ExploreController(IRelationshipService relationshipService, IUserService userService)
        {
            this.relationshipService = relationshipService;
            this.userService = userService;
        }

        // GET: Explore
        public ActionResult People()
        {
            string loginedUserId = getUserIdInSession();
            List<UserAvatarModel> allUserAvatars = userService.getAllUserExcept(loginedUserId);

            return View(allUserAvatars);
        }

        [HttpPost]
        public ActionResult Search(string textSearch)
        {
            string loginedUserId = getUserIdInSession();
            List<UserAvatarModel> allUserAvatars = userService.searchUserByUserName(textSearch, loginedUserId);
            return View(allUserAvatars);
        }
    }
}