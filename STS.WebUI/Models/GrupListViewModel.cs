using STS.Domain.Entities;
using System.Collections.Generic;

namespace STS.WebUI.Models
{
    public class GrupListViewModel
    {
        public IEnumerable<Grup> Gruplar { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}