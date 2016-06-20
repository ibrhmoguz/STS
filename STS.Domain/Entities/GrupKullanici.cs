﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Domain.Entities
{
    [Table("GrupKullanici")]
    public class GrupKullanici
    {
        [Key]
        public int GrupKullaniciId { get; set; }

        public int GrupId { get; set; }

        public int KullaniciId { get; set; }
    }
}
