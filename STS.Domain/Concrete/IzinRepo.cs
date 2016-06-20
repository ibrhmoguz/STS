using STS.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STS.Domain.Entities;

namespace STS.Domain.Concrete
{
    public class IzinRepo : IIzinRepo
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Izin> Izinler
        {
            get
            {
                return context.Izinler.ToList();
            }
        }
    }
}
