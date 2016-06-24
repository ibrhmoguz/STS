using STS.Domain.Abstract;
using STS.Domain.Entities;
using STS.WebUI.Infrastructure.Concrete;
using STS.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STS.WebUI.Controllers
{
    [Authorize]
    [SessionExpireFilter]
    public class SilahController : Controller
    {
        ISilahRepo silahRepo;
        public int PageSize = 5;
        public SilahController(ISilahRepo sr)
        {
            silahRepo = sr;
        }

        public ViewResult Liste(int page = 1)
        {
            var pagedSilahlar = silahRepo.Silahlar.OrderBy(p => p.SilahId).Skip((page - 1) * PageSize).Take(PageSize);
            var model = new SilahListViewModel()
            {
                Silahlar = pagedSilahlar,
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = silahRepo.Silahlar.Count()
                },
                kullaniciYetkileri = Session["CurrentUser_Auths"] as KullaniciYetkileri
            };
            return View(model);
        }

        public ViewResult Ekle()
        {
            return View("Guncelle", new Silah());
        }

        [HttpPost]
        public ViewResult GuncelleView(int silahId)
        {
            Silah silah = silahRepo.Silahlar.FirstOrDefault(x => x.SilahId == silahId);
            return View("Guncelle", silah);
        }

        [HttpPost]
        public ActionResult Guncelle(Silah s)
        {
            if (ModelState.IsValid)
            {
                silahRepo.SilahKaydet(s);
                TempData["message"] = string.Format("Kullanıcı {0}  kayıt edildi.", s.SilahId);
                return RedirectToAction("Liste");
            }
            else
            {
                return View(s);
            }
        }

        [HttpPost]
        public ActionResult Sil(int Id)
        {
            var silahId = silahRepo.SilahSil(Id);
            if (!string.IsNullOrEmpty(silahId))
            {
                TempData["message"] = string.Format("{0} silindi.", silahId);
            }
            else
            {
                TempData["message"] = string.Format("{0} silinemedi!", silahId);
            }

            return RedirectToAction("Liste");
        }

        public ViewResult Giris()
        {
            return View();
        }

        public ViewResult Cikis()
        {
            return View();
        }

        public ViewResult ManuelGirisCikis()
        {
            return View();
        }
    }
}