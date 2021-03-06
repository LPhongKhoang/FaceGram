﻿using FaceGram.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaceGram.Controllers
{
    public class BaseAdminController : BaseController
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LoginedUser user = (LoginedUser)Session[CommonConstant.USER_SESSION];
            if (user == null || user.Role != CommonConstant.ROLE_ADMIN)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(
                    new { controller = "Login", action = "Index" }));

            }


            base.OnActionExecuting(filterContext);
        }


       
    }
}