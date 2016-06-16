using STS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Domain.Concrete
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("stsConnectionString")
        {

        }
        public DbSet<Kullanici> Kullanicilar { get; set; }
    }
}
