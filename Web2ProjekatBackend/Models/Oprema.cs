using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web2ProjekatBackend.Models
{
    [Table("Oprema")]
    public class Oprema
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string Coordinates { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Incident> Incidenti { get; set; }

        public Oprema(int id,string naziv, string tip, string coordinates, string address)
        {
            Id = id;
            Naziv = naziv;
            Tip = tip;
            Coordinates = coordinates;
            Address = address;
        }
    }
}