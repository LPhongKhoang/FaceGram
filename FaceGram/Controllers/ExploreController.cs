using FaceGram.Models;
using FaceGram.Service;
using PagedList;
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
        public ActionResult People(string textSearch, string currentSearch, int? page)
        {
            if (textSearch != null)
            {
                page = 1;
            }
            else
            {
                currentSearch = currentSearch ?? string.Empty;
                textSearch = currentSearch;
            }

            ViewBag.currentSearch = textSearch;


            string loginedUserId = getUserIdInSession();
            IPagedList<UserAvatarModel> allUserAvatars = null;
            const int pageSize = 5;
            int pageNumber = page ?? 1;

            if (textSearch != string.Empty)
            {
                allUserAvatars = userService.searchUserByUserName(textSearch, loginedUserId, pageNumber, pageSize);
            }
            else
            {
                allUserAvatars = userService.getAllUserExcept(loginedUserId, pageNumber, pageSize);
            }

            return View(allUserAvatars);
        }

        
    }
}