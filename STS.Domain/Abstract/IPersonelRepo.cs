using STS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Domain.Abstract
{
    public interface IPersonelRepo
    {
        IEnumerable<Pers> PersonelListesi { get; }
        void PersonelKaydet(Pers p);
        string PersonelSil(int Id);
    }
}
