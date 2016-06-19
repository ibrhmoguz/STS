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
    public class PersonelController : Controller
    {
        IPersonelRepo personelRepo;
        public int PageSize = 5;
        public PersonelController(IPersonelRepo pr)
        {
            personelRepo = pr;
        }

        public ViewResult Liste(int page = 1)
        {
            var pagedPersoneller = personelRepo.PersonelListesi.OrderBy(p => p.Persid).Skip((page - 1) * PageSize).Take(PageSize);
            var model = new PersonelListViewModel()
            {
                Personeller = pagedPersoneller,
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = personelRepo.PersonelListesi.Count()
                }
            };
            return View(model);
        }

        public FileContentResult GetFoto(int Id)
        {
            Pers p = personelRepo.PersonelListesi.FirstOrDefault(x => x.Persid.Equals(Id));
            if (p != null)
            {
                return File(p.FotoData, p.FotoMimeType);
            }
            return null;
        }

        public ViewResult Ekle()
        {
            return View("Guncelle", new Pers());
        }

        [HttpPost]
        public ViewResult GuncelleView(int personelId)
        {
            Pers per = personelRepo.PersonelListesi.FirstOrDefault(x => x.Persid == personelId);
            return View("Guncelle", per);
        }

        [HttpPost]
        public ActionResult Guncelle(Pers p, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    p.FotoMimeType = image.ContentType;
                    p.FotoData = new byte[image.ContentLength];
                    image.InputStream.Read(p.FotoData, 0, image.ContentLength);
                }
                personelRepo.PersonelKaydet(p);
                TempData["message"] = string.Format("Kullanıcı {0}  kayıt edildi.", p.PersAd + p.PersSoyad);
                return RedirectToAction("Liste");
            }
            else
            {
                return View(p);
            }
        }

        [HttpPost]
        public ActionResult Sil(int Id)
        {
            var personelAdi = personelRepo.PersonelSil(Id);
            if (!string.IsNullOrEmpty(personelAdi))
            {
                TempData["message"] = string.Format("{0} silindi.", personelAdi);
            }
            else
            {
                TempData["message"] = string.Format("{0} silinemedi!", personelAdi);
            }

            return RedirectToAction("Liste");
        }

        public FileContentResult FotoYukle(int Persid)
        {
            Pers p = personelRepo.PersonelListesi.FirstOrDefault(x => x.Persid.Equals(Persid));
            if (p != null && p.FotoData != null)
            {
                return File(p.FotoData, p.FotoMimeType);
            }
            else
            {
                return File(System.IO.File.ReadAllBytes(ControllerContext.HttpContext.Server.MapPath("~/Content/Image/userProfile.jpg")), "image/jpeg");
            }
        }
    }
}