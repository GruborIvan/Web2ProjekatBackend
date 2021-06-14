using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web2ProjekatBackend.Models
{
    [Table("Elements")]
    public class Element
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string Longitude { get; set; } //Ovo mozda nije string ali neka stoji za sad
        [Required]
        public string Latitude { get; set; }
        [Required]
        public TipElementa ElementType { get; set; }


        public Element() { }
        public Element(TipElementa el, string id, string naziv, string adresa, string lon, string lat)
        {
            this.ElementType = el;
            this.ID = id;
            this.Naziv = naziv;
            this.Adress = adresa;
            this.Longitude = lon;
            this.Latitude = lat;
        }
    }
}
