using STS.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STS.Domain.Entities;

namespace STS.Domain.Concrete
{
    public class GrupKullaniciRepo : IGrupKullaniciRepo
    {
        private EFDbContext context = new EFDbContext();
        
        public IEnumerable<GrupKullanici> GrupKullanicilar
        {
            get
            {
                return context.GrupKullanicilar.ToList();
            }
        }

        public void GrupKaydet(Entities.GrupKullanici g)
        {
            throw new NotImplementedException();
        }

        public string GrupKullaniciSilGrupIdIle(int grupId)
        {
            throw new NotImplementedException();
        }

        public string GrupKullaniciSilKullaniciIdIle(int kullaniciId)
        {
            throw new NotImplementedException();
        }
    }
}
