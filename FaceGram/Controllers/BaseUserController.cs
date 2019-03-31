using FaceGram.Common;
using FaceGram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaceGram.Controllers
{
    public class BaseUserController : BaseController
    {
        public UserAvatarModel UserAvatar;
 

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LoginedUser user = (LoginedUser)Session[CommonConstant.USER_SESSION];
            if (user == null || user.Role != CommonConstant.ROLE_USER)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(
                    new { controller = "Login", action = "Index" }));

                
            }

            this.UserAvatar = new UserAvatarModel() { Id = user.Id, Avatar = user.Avatar, Username = user.UserName };
            this.ViewBag.UserAvatar = this.UserAvatar;
            base.OnActionExecuting(filterContext);
        }
    }
}