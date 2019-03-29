using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaceGram.Models;
using FaceGram.Service;

namespace FaceGram.Controllers
{
    public class AdminController : BaseController
    {
        private IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult User()
        {
            string linkClick = "user";
            AdminModel adminModel = adminService.getProfileModel("1522135699326", linkClick);

            return View(adminModel);
        }


        public ActionResult Post()
        {
            return View();
        }

        public ActionResult Comment()
        {
            return View();
        }

        public ActionResult Relationship()
        {
            return View();
        }

        public ActionResult Favorite()
        {
            return View();
        }
    }
}