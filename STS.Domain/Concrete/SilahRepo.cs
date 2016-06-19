using STS.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STS.Domain.Entities;

namespace STS.Domain.Concrete
{
    public class SilahRepo : ISilahRepo
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Silah> Silahlar
        {
            get
            {
                return context.Silahlar.ToList();
            }
        }

        public void SilahKaydet(Silah s)
        {
            s.KayitTarihi = DateTime.Now;

            if (s.SilahId == 0)
            {
                context.Silahlar.Add(s);
            }
            else
            {
                Silah sh = context.Silahlar.Find(s.SilahId);
                if (sh != null)
                {
                    sh.Aciklama = s.Aciklama;
                    sh.BakimZamani = s.BakimZamani;
                    sh.Durumu = s.Durumu;
                    sh.KayitTarihi = s.KayitTarihi;
                    sh.SilahNo = s.SilahNo;
                }
            }
            context.SaveChanges();
        }

        public string SilahSil(int Id)
        {
            Silah s = context.Silahlar.Find(Id);
            if (s != null)
            {
                context.Silahlar.Remove(s);
                context.SaveChanges();
                return s.SilahId.ToString();
            }

            return string.Empty;
        }
    }
}
