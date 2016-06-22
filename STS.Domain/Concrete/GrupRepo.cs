using STS.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STS.Domain.Entities;

namespace STS.Domain.Concrete
{
    public class GrupRepo : IGrupRepo
    {
        IKullaniciRepo kullaniciRepo;
        IIzinRepo izinRepo;
        IGrupKullaniciRepo gkRepo;
        IGrupIzinRepo giRepo;
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Grup> Gruplar
        {
            get
            {
                return context.Gruplar.ToList();
            }
        }

        public GrupRepo(IKullaniciRepo krepo, IIzinRepo irepo, IGrupKullaniciRepo gkr, IGrupIzinRepo gir)
        {
            this.kullaniciRepo = krepo;
            this.izinRepo = irepo;
            this.gkRepo = gkr;
            this.giRepo = gir;
        }

        public void GrupKaydet(Grup g)
        {
            if (g.GrupId == 0)
            {
                context.Gruplar.Add(g);
            }
            else
            {
                Grup gp = context.Gruplar.Find(g.GrupId);
                if (gp != null)
                {
                    gp.GrupAdi = g.GrupAdi;
                }
            }
            context.SaveChanges();
        }

        public string GrupSil(int Id)
        {
            Grup g = context.Gruplar.Find(Id);
            if (g != null)
            {
                var izinler = context.GrupIzinler.Where(p => p.GrupId.Equals(Id));
                foreach (var izin in izinler)
                {
                    context.GrupIzinler.Remove(izin);
                }

                var kullanicilar = context.GrupKullanicilar.Where(p => p.GrupId.Equals(Id));
                foreach (var kullanici in kullanicilar)
                {
                    context.GrupKullanicilar.Remove(kullanici);
                }

                context.Gruplar.Remove(g);
                context.SaveChanges();
                return g.GrupId.ToString();
            }

            return string.Empty;
        }

        public IEnumerable<Kullanici> GrupKullanicilariniGetir(int grupId)
        {
            return (from g in this.Gruplar
                    join gk in gkRepo.GrupKullanicilar on g.GrupId equals gk.GrupId
                    join k in kullaniciRepo.Kullanicilar on gk.KullaniciId equals k.KullaniciId
                    where g.GrupId.Equals(grupId)
                    select k).ToList();
        }

        public IEnumerable<Izin> GrupIzinleriniGetir(int grupId)
        {
            return (from g in this.Gruplar
                    join gi in giRepo.GrupIzinler on g.GrupId equals gi.GrupId
                    join i in izinRepo.Izinler on gi.IzinId equals i.IzinId
                    where g.GrupId.Equals(grupId)
                    select i).ToList();
        }

        public IEnumerable<string> KullaniciYetkileri(int kullaniciId)
        {
            return (from k in kullaniciRepo.Kullanicilar
                    join gk in gkRepo.GrupKullanicilar on k.KullaniciId equals gk.KullaniciId
                    join gi in giRepo.GrupIzinler on gk.GrupId equals gi.GrupId
                    join i in izinRepo.Izinler on gi.IzinId equals i.IzinId
                    where k.KullaniciId.Equals(kullaniciId)
                    select i.IzinAdi).ToList();
        }
    }
}
