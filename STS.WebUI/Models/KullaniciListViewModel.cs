using STS.Domain.Entities;
using System.Collections.Generic;

namespace STS.WebUI.Models
{
    public class KullaniciListViewModel
    {
        public IEnumerable<Kullanici> Kullanicilar { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}