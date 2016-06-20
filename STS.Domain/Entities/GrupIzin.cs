using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Domain.Entities
{
    [Table("GrupIzin")]
    public class GrupIzin
    {
        [Key]
        public int GrupIzinId { get; set; }

        public int GrupId { get; set; }

        public int IzinId { get; set; }
    }
}
