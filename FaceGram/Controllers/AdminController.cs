using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaceGram.Models;
using FaceGram.Service;

namespace FaceGram.Controllers
{
    public class AdminController : BaseAdminController
    {
        private IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }


        // GET: Admin
        public ActionResult Index()
        {
            
            string clickButton = Request.QueryString["clickButton"];
            string linkClick = Request.QueryString["linkClick"];
            AdminModel adminModel;

            if (clickButton != null)
            {
                string id = Request.QueryString["getID"];

                if (clickButton == "deleteComment")
                {
                    adminService.deleteComment(id);
                }
                else if (clickButton == "deleteRelationship")
                {
                    adminService.deleteRelationship(id);
                }
                else if (clickButton == "deleteFavorite")
                {
                    adminService.deleteFavorite(id);
                }
            }
            adminModel = adminService.getAdminModel(linkClick);

            return View(adminModel);
        }

    }
}