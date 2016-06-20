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
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Grup> Gruplar
        {
            get
            {
                return context.Gruplar.ToList();
            }
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
                context.Gruplar.Remove(g);
                context.SaveChanges();
                return g.GrupId.ToString();
            }

            return string.Empty;
        }
    }
}
