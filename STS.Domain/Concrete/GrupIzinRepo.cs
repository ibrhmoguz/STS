using STS.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STS.Domain.Entities;

namespace STS.Domain.Concrete
{
    public class GrupIzinRepo : IGrupIzinRepo
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<GrupIzin> GrupIzinler
        {
            get
            {
                return context.GrupIzinler.ToList();
            }
        }

        public void GrupIzinKaydet(GrupIzin g)
        {
            var grupIzin = context.GrupIzinler.Where(p => p.GrupId.Equals(g.GrupId) && p.IzinId.Equals(g.IzinId)).FirstOrDefault();
            if (grupIzin == null)
            {
                context.GrupIzinler.Add(g);
            }
            else
            {
                grupIzin.GrupId = g.GrupId;
                grupIzin.IzinId = g.IzinId;
            }

            context.SaveChanges();
        }

        public string GrupIzinSilGrupIdIle(int grupId)
        {
            throw new NotImplementedException();
        }

        public bool GrupIzinSilIzinIdVeGrupIdIle(int izinId, int grupId)
        {
            var grupIzin = context.GrupIzinler.Where(p => p.GrupId.Equals(grupId) && p.IzinId.Equals(izinId)).FirstOrDefault();
            if (grupIzin != null)
            {
                context.GrupIzinler.Remove(grupIzin);
                context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
