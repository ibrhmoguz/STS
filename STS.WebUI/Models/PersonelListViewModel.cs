using STS.Domain.Entities;
using System.Collections.Generic;

namespace STS.WebUI.Models
{
    public class PersonelListViewModel
    {
        public IEnumerable<Pers> Personeller { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public KullaniciYetkileri kullaniciYetkileri { get; set; }
    }
}