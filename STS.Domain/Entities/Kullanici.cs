using System;
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
        [Key]
        public int KullaniciId { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı giriniz!")]
        public string KullaniciAdi { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre giriniz!")]
        public string Sifre { get; set; }

        public byte[] FotoData { get; set; }
        public string FotoMimeType { get; set; }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Adı giriniz!")]
        public string Adi { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyadı giriniz!")]
        public string Soyadi { get; set; }

        public DateTime KayitTarihi { get; set; }
    }
}
