using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaceGram.Service;

namespace FaceGram.Controllers
{
    public class LogoutController : Controller
    {
        private ILogoutService logoutService;

        public LogoutController(ILogoutService logoutService)
        {
            this.logoutService = logoutService;
        }

        // GET: Logout
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            if(Session[Common.CommonConstant.USER_SESSION] != null)
            {
                Session.Remove(Common.CommonConstant.USER_SESSION);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}