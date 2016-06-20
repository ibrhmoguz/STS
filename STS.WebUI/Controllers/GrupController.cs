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
        IKullaniciRepo kullaniciRepo;
        IIzinRepo izinRepo;
        IGrupKullaniciRepo gkRepo;
        IGrupIzinRepo giRepo;
        public int PageSize = 5;
        public GrupController(IGrupRepo sr, IKullaniciRepo krepo, IIzinRepo irepo, IGrupKullaniciRepo gkr, IGrupIzinRepo gir)
        {
            grupRepo = sr;
            kullaniciRepo = krepo;
            izinRepo = irepo;
            gkRepo = gkr;
            giRepo = gir;
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

        [HttpPost]
        public ViewResult KullaniciVeIzinler(int grupId)
        {
            Grup grup = grupRepo.Gruplar.FirstOrDefault(x => x.GrupId == grupId);

            var kullanicilar = (from g in grupRepo.Gruplar
                                join gk in gkRepo.GrupKullanicilar on g.GrupId equals gk.GrupId
                                join k in kullaniciRepo.Kullanicilar on gk.KullaniciId equals k.KullaniciId
                                where g.GrupId.Equals(grupId)
                                select k).ToList();

            var izinler = (from g in grupRepo.Gruplar
                           join gi in giRepo.GrupIzinler on g.GrupId equals gi.GrupId
                           join i in izinRepo.Izinler on gi.IzinId equals i.IzinId
                           where g.GrupId.Equals(grupId)
                           select i).ToList();

            var model = new GrupKullaniciIzinViewModel
            {
                Grup = grup,
                Kullanicilar = kullanicilar,
                Izinler = izinler
            };
            return View(model);
        }
    }
}