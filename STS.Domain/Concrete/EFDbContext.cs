using STS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
        public DbSet<Silah> Silahlar { get; set; }
        public DbSet<Pers> PersListesi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Kullanici>().HasKey(q => q.KullaniciId);
            modelBuilder.Entity<Silah>().HasKey(q => q.SilahId);
            modelBuilder.Entity<Pers>().HasKey(q => q.Persid);
        }
    }
}
