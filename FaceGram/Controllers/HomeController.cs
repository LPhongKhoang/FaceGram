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
        ITestService testService;

        public HomeController(ITestService testService)
        {
            this.testService = testService;
        }

        public ActionResult Index()
        {
            NewFeedModel model = new NewFeedModel();
            model.Message = testService.sayHello() + ": " + testService.GetHashCode();
            return View(model);
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
    }
}