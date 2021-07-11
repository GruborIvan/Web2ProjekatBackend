using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web2ProjekatBackend.Models
{
    [Table ("Nalozi")]
    public class NalogRada
    {
        [Key]
        public string IdNaloga { get; set; }
        [Required]
        public TipRada Type { get; set; }
        [Required]
        [StringLength(255)]
        public string Status { get; set; }
        [Required]
        [StringLength(255)]
        public string IdIncidenta { get; set; }
        [Required]
        [StringLength(255)]
        public string Ulica { get; set; }
        [Required]
        public DateTime PocetakRada { get; set; }
        [Required]
        public DateTime KrajRada { get; set; }
        [Required]
        [StringLength(255)]
        public string Svrha { get; set; }
        [Required]
        [StringLength(255)]
        public string Beleske { get; set; }
        [Required]
        public bool Hitno { get; set; }
        [Required]
        [StringLength(255)]
        public string Kompanija { get; set; }
        [Required]
        [StringLength(255)]
        public string TelefonskiBroj { get; set; }
        [Required]
        [StringLength(255)]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; }



        public NalogRada() { }
        public NalogRada(string idNaloga, TipRada type, string status, string id, string ulica, DateTime pocetak, DateTime kraj, string createdby, string svrha, string beleske, bool hitno, string kompanija, string broj, DateTime created)
        {
            this.Type = type;
            this.IdNaloga = idNaloga;
            this.Status = status;
            this.IdIncidenta = id;
            this.Ulica = ulica;
            this.PocetakRada = pocetak;
            this.KrajRada = kraj;
            this.CreatedBy = createdby;
            this.Svrha = svrha;
            this.Beleske = beleske;
            this.Hitno = hitno;
            this.Kompanija = kompanija;
            this.TelefonskiBroj = broj;
            this.CreatedTime = created;


        }
    }
}
