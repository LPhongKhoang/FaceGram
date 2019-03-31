using FaceGram.Common;
using FaceGram.Models;
using FaceGram.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaceGram.Controllers
{
    public class HomeController : BaseUserController
    {
        INewFeedService newFeedService;
        IPostInteractService postInteractService;

        public HomeController(INewFeedService newFeedService, IPostInteractService postInteractService)
        {
            this.newFeedService = newFeedService;
            this.postInteractService = postInteractService;
        }

        public ActionResult Index()
        {
            LoginedUser loginedUser = getUserInSession();

            UserAvatarModel userAvatarModel = new UserAvatarModel() { Id=loginedUser.Id, Avatar=loginedUser.Avatar, Username=loginedUser.UserName};

            NewFeedModel model = newFeedService.getNewFeedModel(loginedUser.Id);
            model.UserAvatar = userAvatarModel;


            return View(model);
        }

        public ActionResult Post(string id)
        {
            String loginedUserId = getUserIdInSession();
            PostModel model = postInteractService.getPostModel(id, loginedUserId);

            return View(model);
        }

       
    }
}