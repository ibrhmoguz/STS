using STS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Domain.Abstract
{
    public interface ISilahRepo
    {
        IEnumerable<Silah> Silahlar { get; }
        void SilahKaydet(Silah s);
        string SilahSil(int Id);
    }
}
