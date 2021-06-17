using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web2ProjekatBackend.Models
{
    [Table ("Potrosaci")]
    public class Potrosac
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Id { get; set; }
        public string Lokacija { get; set; }
        public int Prioritet { get; set; }
        public string TelefonskiBroj { get; set; }
        public TipPotrosaca PotrosacType { get; set; }
        public string IdEkipe { get; set; }


        public Potrosac() { }
        public Potrosac(string ime, string prezime, string id, string lokacija, int prio, string tele, TipPotrosaca tip, string idEkipe)
        {

            this.Ime = ime;
            this.Prezime = prezime;
            this.Id = id;
            this.Lokacija = lokacija;
            this.Prioritet = prio;
            this.TelefonskiBroj = tele;
            this.PotrosacType = tip;
            this.IdEkipe = idEkipe;

        }
    }
}
