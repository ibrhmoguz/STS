using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STS.WebUI.Infrastructure.Abstract;
using STS.WebUI.Models;
using STS.Domain.Abstract;

namespace STS.WebUI.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        IKullaniciRepo kullaniciRepo;
        public AccountController(IAuthProvider auth, IKullaniciRepo kr)
        {
            authProvider = auth;
            kullaniciRepo = kr;
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
                var kullanici = kullaniciRepo.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi.Equals(model.KullaniciAdi) && x.Sifre.Equals(model.Sifre));
                if (kullanici != null)
                {
                    authProvider.Authenticate(model.KullaniciAdi, model.Sifre);
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
            Session.Clear();
            authProvider.SignOut();
            return RedirectToAction("Login", "Account", null);
        }
    }
}
