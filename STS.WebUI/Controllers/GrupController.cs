using STS.Domain.Abstract;
using STS.Domain.Entities;
using STS.WebUI.Infrastructure.Concrete;
using STS.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace STS.WebUI.Controllers
{
    [Authorize]
    [SessionExpireFilter]
    public class GrupController : Controller
    {
        IKullaniciRepo kullaniciRepo;
        IIzinRepo izinRepo;
        IGrupKullaniciRepo gkRepo;
        IGrupIzinRepo giRepo;
        IGrupRepo grupRepo;
        public int PageSize = 5;
        public GrupController(IGrupRepo sr, IKullaniciRepo krepo, IIzinRepo irepo, IGrupKullaniciRepo gkr, IGrupIzinRepo gir)
        {
            this.grupRepo = sr;
            this.kullaniciRepo = krepo;
            this.izinRepo = irepo;
            this.gkRepo = gkr;
            this.giRepo = gir;
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
            GrupKullaniciIzinViewModel model = GrupKullaniciVeIzinleriGetir(grupId);
            return View(model);
        }

        private GrupKullaniciIzinViewModel GrupKullaniciVeIzinleriGetir(int grupId)
        {
            Grup grup = grupRepo.Gruplar.FirstOrDefault(x => x.GrupId == grupId);

            var tumIzinler = izinRepo.Izinler.Select(p => new SelectListItem { Text = p.IzinAdi, Value = p.IzinId.ToString() }).ToList();
            tumIzinler.Insert(0, new SelectListItem { Text = "Izin seçiniz", Value = "0" });

            var tumKullanicilar = kullaniciRepo.Kullanicilar.Select(p => new SelectListItem { Text = p.KullaniciAdi, Value = p.KullaniciId.ToString() }).ToList();
            tumKullanicilar.Insert(0, new SelectListItem { Text = "Kullanıcı seçiniz", Value = "0" });

            var model = new GrupKullaniciIzinViewModel
            {
                Grup = grup,
                Kullanicilar = grupRepo.GrupKullanicilariniGetir(grupId),
                Izinler = grupRepo.GrupIzinleriniGetir(grupId),
                TumIzinler = tumIzinler,
                TumKullanicilar = tumKullanicilar,
                SelectedIzinId = 0,
                SelectedKullaniciId = 0
            };
            return model;
        }

        [HttpPost]
        public ActionResult KullaniciCikar(int kullaniciIdCikar, int grupId)
        {
            gkRepo.GrupKullaniciSilKullaniciIdVeGrupIdIle(kullaniciIdCikar, grupId);
            return LoadToGrupView(grupId);
        }

        [HttpPost]
        public ActionResult IzinCikar(int izinIdCikar, int grupId)
        {
            giRepo.GrupIzinSilIzinIdVeGrupIdIle(izinIdCikar, grupId);
            return LoadToGrupView(grupId);
        }

        [HttpPost]
        public ActionResult KullaniciEkle(int kullaniciIdEkle, int grupId)
        {
            GrupKullanici grupKullanici = gkRepo.GrupKullanicilar.FirstOrDefault(p => p.KullaniciId.Equals(kullaniciIdEkle));
            if (grupKullanici == null)
            {
                gkRepo.GrupKullaniciKaydet(new GrupKullanici { GrupId = grupId, KullaniciId = kullaniciIdEkle });
            }
            else
            {
                ViewBag.ActionResultMessage = "Bu kullanıcı " + grupRepo.Gruplar.FirstOrDefault(p => p.GrupId.Equals(grupKullanici.GrupId)).GrupAdi + " grubundadır, eklenemez!";
                ViewBag.ActionResultMessageType = "warning";
            }

            return LoadToGrupView(grupId);
        }

        [HttpPost]
        public ActionResult IzinEkle(int izinIdEkle, int grupId)
        {
            giRepo.GrupIzinKaydet(new GrupIzin { GrupId = grupId, IzinId = izinIdEkle });
            return LoadToGrupView(grupId);
        }

        private ActionResult LoadToGrupView(int grupId)
        {
            ModelState.Clear();
            GrupKullaniciIzinViewModel model = GrupKullaniciVeIzinleriGetir(grupId);
            return View("KullaniciVeIzinler", model);
        }
    }
}