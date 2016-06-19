using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Domain.Entities
{
    [Table("Silah")]
    public class Silah
    {
        [Key]
        public int SilahId { get; set; }

        [Display(Name = "Silah Numarası")]
        [Required(ErrorMessage = "Silah Numarası giriniz!")]
        public string SilahNo { get; set; }

        [Display(Name = "Durumu")]
        [Required(ErrorMessage = "Durumu giriniz!")]
        public string Durumu { get; set; }

        [Display(Name = "Bakım Zamanı")]
        public DateTime BakimZamani { get; set; }

        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
    }
}
