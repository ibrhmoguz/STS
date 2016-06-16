using STS.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.AppTester
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EFDbContext())
            {
                var list = context.Kullanicilar.ToList();
                foreach (var k in list)
                {
                    Console.WriteLine(k.KullaniciId + "-" + k.KullaniciAdi + "-" + k.Sifre);
                }
            }
        }
    }
}
