using FaceGram.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FaceGram.Controllers
{
    public class BaseController : Controller
    {
        protected LoginedUser getUserInSession()
        {
            return (LoginedUser) Session[CommonConstant.USER_SESSION];
        }

        protected string getUserIdInSession()
        {
            return getUserInSession().Id;
        }

        protected bool removeUserInSession()
        {
            try
            {
                Session.Remove(CommonConstant.USER_SESSION);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }
    }
}