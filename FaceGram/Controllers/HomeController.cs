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
    public class HomeController : BaseController
    {
        INewFeedService newFeedService;

        public HomeController(INewFeedService newFeedService)
        {
            this.newFeedService = newFeedService;
        }

        public ActionResult Index()
        {
            LoginedUser loginedUser = getUserInSession();

            NewFeedModel model = newFeedService.getNewFeedModel(loginedUser.Id);

            return View(model);
        }

       
    }
}