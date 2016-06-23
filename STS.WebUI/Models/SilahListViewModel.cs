using STS.Domain.Entities;
using System.Collections.Generic;

namespace STS.WebUI.Models
{
    public class SilahListViewModel
    {
        public IEnumerable<Silah> Silahlar { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public KullaniciYetkileri kullaniciYetkileri { get; set; }
    }
}