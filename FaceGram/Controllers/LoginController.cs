﻿using FaceGram.Common;
using FaceGram.Database.EF;
using FaceGram.Models;
using FaceGram.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaceGram.Controllers
{
    public class LoginController : Controller
    {

        private IUserService userService;

        public LoginController(IUserService userService)
        {
            this.userService = userService;
        }


        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {

                char result = userService.verifyAccount(model.Email, model.Password);
                if (result == CommonConstant.LOGIN_OK)
                {

                    User user = userService.getByEmail(model.Email);
                    LoginedUser loginedUser = new LoginedUser()
                    {
                        Id = user.id,
                        UserName = user.username,
                        UserFullName = user.fullname,
                        Avatar = user.avatar
                    };

                    Session.Add(CommonConstant.USER_SESSION, loginedUser);
                    return RedirectToAction("Index", "Home");

                }
                else if (result == CommonConstant.LOGIN_FAIL)
                {
                    ModelState.AddModelError(string.Empty, "Wrong email or password");
                }        

            }

            return View("Index");

        }

    }
}