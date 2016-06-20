using STS.Domain.Entities;
using System.Collections.Generic;

namespace STS.WebUI.Models
{
    public class GrupKullaniciIzinViewModel
    {
        public Grup Grup { get; set; }
        public IEnumerable<Kullanici> Kullanicilar { get; set; }
        public IEnumerable<Izin> Izinler { get; set; }
    }
}