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
    public class KullaniciController : Controller
    {
        IKullaniciRepo kullaniciRepo;
        public int PageSize = 5;
        public KullaniciController(IKullaniciRepo kr)
        {
            kullaniciRepo = kr;
        }

        public ViewResult Liste(int page = 1)
        {
            var pagedKullanicilar = kullaniciRepo.Kullanicilar.OrderBy(p => p.KullaniciId).Skip((page - 1) * PageSize).Take(PageSize);
            var model = new KullaniciListViewModel()
            {
                Kullanicilar = pagedKullanicilar,
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = kullaniciRepo.Kullanicilar.Count()
                }
            };
            return View(model);
        }

        public FileContentResult GetFoto(int Id)
        {
            Kullanici k = kullaniciRepo.Kullanicilar.FirstOrDefault(x => x.KullaniciId.Equals(Id));
            if (k != null)
            {
                return File(k.FotoData, k.FotoMimeType);
            }
            return null;
        }

        public ViewResult Ekle()
        {
            return View("Guncelle", new Kullanici());
        }

        [HttpPost]
        public ActionResult Guncelle(Kullanici k, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    k.FotoMimeType = image.ContentType;
                    k.FotoData = new byte[image.ContentLength];
                    image.InputStream.Read(k.FotoData, 0, image.ContentLength);
                }
                kullaniciRepo.KullaniciKaydet(k);
                TempData["message"] = string.Format("Kullanıcı {0}  kayıt edildi.", k.KullaniciAdi);
                return RedirectToAction("Liste");
            }
            else
            {
                return View(k);
            }
        }

        [HttpPost]
        public ActionResult Sil(int Id)
        {
            var kullaniciAdi = kullaniciRepo.KullaniciSil(Id);
            if (!string.IsNullOrEmpty(kullaniciAdi))
            {
                TempData["message"] = string.Format("{0} silindi.", kullaniciAdi);
            }
            else
            {
                TempData["message"] = string.Format("{0} silinemedi!", kullaniciAdi);
            }

            return RedirectToAction("Liste");
        }
    }
}