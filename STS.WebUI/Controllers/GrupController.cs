using STS.Domain.Abstract;
using STS.Domain.Entities;
using STS.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STS.WebUI.Controllers
{
    [Authorize]
    public class GrupController : Controller
    {
        IGrupRepo grupRepo;
        public int PageSize = 5;
        public GrupController(IGrupRepo sr)
        {
            grupRepo = sr;
        }

        public ViewResult Liste(int page = 1)
        {
            var pagedGruplar = grupRepo.Gruplar.OrderBy(p => p.GrupId).Skip((page - 1) * PageSize).Take(PageSize);
            var model = new GrupListViewModel()
            {
                Gruplar = pagedGruplar,
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = grupRepo.Gruplar.Count()
                }
            };
            return View(model);
        }

        public ViewResult Ekle()
        {
            return View("Guncelle", new Grup());
        }

        [HttpPost]
        public ViewResult GuncelleView(int grupId)
        {
            Grup Grup = grupRepo.Gruplar.FirstOrDefault(x => x.GrupId == grupId);
            return View("Guncelle", Grup);
        }

        [HttpPost]
        public ActionResult Guncelle(Grup s)
        {
            if (ModelState.IsValid)
            {
                grupRepo.GrupKaydet(s);
                TempData["message"] = string.Format("Kullanıcı {0}  kayıt edildi.", s.GrupId);
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
            var grupId = grupRepo.GrupSil(Id);
            if (!string.IsNullOrEmpty(grupId))
            {
                TempData["message"] = string.Format("{0} silindi.", grupId);
            }
            else
            {
                TempData["message"] = string.Format("{0} silinemedi!", grupId);
            }

            return RedirectToAction("Liste");
        }
    }
}