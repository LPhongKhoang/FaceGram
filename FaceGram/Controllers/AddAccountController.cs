using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaceGram.Common;
using FaceGram.Database.EF;
using FaceGram.Models;
using FaceGram.Service;

namespace FaceGram.Controllers
{
    public class AddAccountController : Controller
    {
        private IAddAccountService addAccountService;

        public AddAccountController(IAddAccountService addAccountService)
        {
            this.addAccountService = addAccountService;
        }

        // GET: AddAccount
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAccount(AccountModel model)
        {
            if (ModelState.IsValid)
            {
                if (addAccountService.emailExisted(model.Email) && addAccountService.phonelExisted(model.Phonenumber))
                {
                    Random rnd = new Random();
                    int idRandom = rnd.Next(1, 100000);

                    User user = new User()
                    {
                        id = idRandom.ToString(),
                        username = model.Username,
                        email = model.Email,
                        avatar = "https://minervastrategies.com/wp-content/uploads/2016/03/default-avatar.jpg",
                        password = model.Password,
                        phone_number = model.Phonenumber,
                    };

                    Role role = new Role()
                    {
                        uid = idRandom.ToString(),
                        role1 = "user"
                    };
                    addAccountService.insertAccount(user);
                    addAccountService.insertRole(role);

                    LoginedUser loginedUser = new LoginedUser()
                    {
                        Id = idRandom.ToString(),
                        UserName = model.Username,
                        UserFullName = user.fullname,
                        Avatar = "https://minervastrategies.com/wp-content/uploads/2016/03/default-avatar.jpg",
                        Role = "user"
                    };

                    Session.Add(CommonConstant.USER_SESSION, loginedUser);

                    return RedirectToAction("Index", "Home");
                } else
                {
                    if (!addAccountService.emailExisted(model.Email))
                    {
                        ModelState.AddModelError(string.Empty, "Email has already existed");
                    }
                    if (!addAccountService.phonelExisted(model.Phonenumber))
                    {
                        ModelState.AddModelError(string.Empty, "Phone number has already existed");
                    }
                }
                
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreateAccount()
        {
            return View();
        }
    }
}