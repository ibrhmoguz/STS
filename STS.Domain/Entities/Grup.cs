using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Domain.Entities
{
    [Table("Grup")]
    public class Grup
    {
        [Key]
        public int GrupId { get; set; }

        [Display(Name = "Kullanıcı Grup Adı")]
        [Required(ErrorMessage = "Kullanıcı Grubu giriniz!")]
        public string GrupAdi { get; set; }
    }
}
