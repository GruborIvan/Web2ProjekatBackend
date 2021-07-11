using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web2ProjekatBackend.Models
{
    [Table ("Planovi")]
    public class PlanRada
    {
        [Key]
        public string IdPlana { get; set; }

        [Required]
        public TipRada Type { get; set; }
        [Required]
        [StringLength(255)]
        public string IdNalogaRada { get; set; }
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
        public string Ekipa { get; set; }
        [Required]
        [StringLength(255)]
        public string CreatedBy { get; set; }
        [Required]
        public string Svrha { get; set; }
        [Required]
        [StringLength(255)]
        public string Detalji { get; set; }
        [Required]
        [StringLength(255)]
        public string Beleske { get; set; }
        [Required]
        [StringLength(255)]
        public string Kompanija { get; set; }
        [Required]
        [StringLength(255)]
        public string TelefonskiBroj { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }

        public PlanRada() { }
        public PlanRada(TipRada type, string idNaloga, string status, string idInc, string ulica, DateTime pocetak, DateTime kraj, string ekipa, string createdBy, string svrha, string belekse,
            string kompanija, string telefonskibroj, DateTime createdon)
        {

            this.Type = type;
            this.IdNalogaRada = idNaloga;
            this.Status = status;
            this.IdIncidenta = idInc;
            this.Ulica = ulica;
            this.PocetakRada = pocetak;
            this.KrajRada = kraj;
            this.Ekipa = ekipa;
            this.CreatedBy = createdBy;
            this.Svrha = svrha;
            this.Beleske = belekse;
            this.Kompanija = kompanija;
            this.TelefonskiBroj = telefonskibroj;
            this.CreatedOn = createdon;


        }
    }
}
