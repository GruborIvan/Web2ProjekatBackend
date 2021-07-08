using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web2ProjekatBackend.Models
{
    [Table ("Poruke")]
    public class Poruka
    {
        [Key]
        public string IdPoruke { get; set; }
        [Required]
        public string IdKorisnika { get; set; }
        [Required]
        public string Sadrzaj { get; set; }
        [Required]
        public TipPoruke Tip { get; set; }
        [Required]
        public bool Procitana { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }


        public Poruka() { }
    }
}
