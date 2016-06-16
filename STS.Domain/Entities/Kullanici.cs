﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Domain.Entities
{
    [Table("Kullanici")]
    public class Kullanici
    {
        public int KullaniciId { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı giriniz!")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Şifre giriniz!")]
        public string Sifre { get; set; }

        public byte[] FotoData { get; set; }
        public string FotoMimeType { get; set; }
    }
}
