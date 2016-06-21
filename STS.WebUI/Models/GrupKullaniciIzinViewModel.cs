using STS.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace STS.WebUI.Models
{
    public class GrupKullaniciIzinViewModel
    {
        public Grup Grup { get; set; }
        public IEnumerable<Kullanici> Kullanicilar { get; set; }
        public IEnumerable<Izin> Izinler { get; set; }
        public IEnumerable<SelectListItem> TumKullanicilar { get; set; }
        public IEnumerable<SelectListItem> TumIzinler { get; set; }
        public int SelectedKullaniciId { get; set; }
        public int SelectedIzinId { get; set; }
    }
}