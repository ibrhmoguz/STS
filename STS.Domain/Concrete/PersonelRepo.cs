using STS.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STS.Domain.Entities;

namespace STS.Domain.Concrete
{
    public class PersonelRepo : IPersonelRepo
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Pers> PersonelListesi
        {
            get
            {
                return context.PersListesi.ToList();
            }
        }

        public void PersonelKaydet(Pers p)
        {
            p.PersKayitTarihi = DateTime.Now;

            if (p.Persid == 0)
            {
                context.PersListesi.Add(p);
            }
            else
            {
                Pers pp = context.PersListesi.Find(p.Persid);
                if (pp != null)
                {
                    pp.PersAd= p.PersAd;
                    pp.PersBirlikAdi = p.PersBirlikAdi;
                    if (p.FotoData != null)
                    {
                        pp.FotoData = p.FotoData;
                        pp.FotoMimeType = p.FotoMimeType;
                    }
                    pp.PersKartId = p.PersKartId;
                    pp.PersKartSeriNo = p.PersKartSeriNo;
                    pp.PersKayitTarihi = p.PersKayitTarihi;
                    pp.PersSoyad = p.PersSoyad;
                    pp.PersTcNo = p.PersTcNo;
                }
            }
            context.SaveChanges();
        }

        public string PersonelSil(int Id)
        {
            Pers p = context.PersListesi.Find(Id);
            if (p != null)
            {
                context.PersListesi.Remove(p);
                context.SaveChanges();
                return p.PersAd;
            }

            return string.Empty;
        }
    }
}
