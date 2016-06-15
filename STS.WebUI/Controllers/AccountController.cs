using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STS.WebUI.Infrastructure.Abstract;
using STS.WebUI.Models;

namespace STS.WebUI.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Default"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect  username  or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOut()
        {
            authProvider.SignOut();
            return RedirectToAction("Login", "Account", null);
        }
    }
}
