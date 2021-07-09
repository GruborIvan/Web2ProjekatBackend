using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web2ProjekatBackend.Models
{
    [Table("Ekipe")]
    public class Ekipa
    {
        public int Id { get; set; }

        [Required]
        public string NazivEkipe { get; set; }

        public Ekipa() { }
        public Ekipa(int id, string naziv)
        {
            this.Id = id;
            this.NazivEkipe = naziv;
        }

    }
}
