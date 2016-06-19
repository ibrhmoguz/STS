using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Domain.Entities
{
    [Table("pers")]
    public class Pers
    {
        [Key]
        public int Persid { get; set; }
        [Display(Name = "Adı")]
        [Required(ErrorMessage = "Personel adı giriniz!")]
        public string PersAd { get; set; }

        [Display(Name = "Soyadı")]
        [Required(ErrorMessage = "Personel soyadı giriniz!")]
        public string PersSoyad { get; set; }

        [Display(Name = "T.C. Kimlik No")]
        [Required(ErrorMessage = "Kimlik numarası giriniz!")]
        public string PersTcNo { get; set; }

        [Display(Name = "Kart Seri numarası")]
        [Required(ErrorMessage = "Kart seri no giriniz!")]
        public string PersKartSeriNo { get; set; }

        [Display(Name = "Birlik Adı")]
        [Required(ErrorMessage = "Birlik Adı giriniz!")]
        public string PersBirlikAdi { get; set; }

        [Display(Name = "Kart Id")]
        [Required(ErrorMessage = "Kart Id giriniz!")]
        public string PersKartId { get; set; }

        public DateTime PersKayitTarihi { get; set; }
        public byte[] FotoData { get; set; }
        public string FotoMimeType { get; set; }
        
       
    }
}
