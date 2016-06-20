using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Domain.Entities
{
    [Table("Izin")]
    public class Izin
    {
        [Key]
        public int IzinId { get; set; }

        [Display(Name = "İzin Adı")]
        [Required(ErrorMessage = "İzin giriniz!")]
        public string IzinAdi { get; set; }
    }
}
