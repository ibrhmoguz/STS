using STS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Domain.Abstract
{
    public interface IKullaniciRepo
    {
        IEnumerable<Kullanici> Kullanicilar { get; }
        void KullaniciKaydet(Kullanici k);
        string KullaniciSil(int Id);
    }
}
