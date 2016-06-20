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
            throw new NotImplementedException();
        }

        public string GrupIzinSilGrupIdIle(int grupId)
        {
            throw new NotImplementedException();
        }

        public string GrupIzinSilIzinIdIle(int izinId)
        {
            throw new NotImplementedException();
        }
    }
}
