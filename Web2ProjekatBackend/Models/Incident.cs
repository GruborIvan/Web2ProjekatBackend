using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web2ProjekatBackend.Models
{

    [Table("Incidents")]
    public class Incident
    {

        [Key]
        public string ID { get; set; }
        [Required]
        public TipIncidenta IncidentType { get; set; }
        [Required]
        public int Prioritet { get; set; }
        [Required]
        public bool Confirmed { get; set; }
        [Required]
        [StringLength(255)]
        public string Status { get; set; }
        [Required]
        public DateTime ETA { get; set; }
        [Required]
        public DateTime ATA { get; set; }
        [Required]
        public DateTime ETR { get; set; }
        [Required]
        public DateTime VremeIncidenta { get; set; }
        [Required]
        public DateTime VremeRada { get; set; }
        [Required]
        public int AffectedPeople { get; set; }
        [Required]
        public int Pozivi { get; set; }
        [Required]
        public int Voltage { get; set; }
        [StringLength(255)]
        public string IdKorisnika { get; set; }



        public Incident() { }
        public Incident(string id, TipIncidenta tip, int prio, bool conf, string status, DateTime eta, DateTime ata, DateTime etr, DateTime vrijeme, int aff, int pozivi, int voltage)
        {

            this.ID = id;
            this.IncidentType = tip;
            this.Prioritet = prio;
            this.Confirmed = conf;
            this.Status = status;
            this.ETA = eta;
            this.ATA = ata;
            this.ETR = etr;
            this.VremeRada = vrijeme;
            this.AffectedPeople = aff;
            this.Pozivi = pozivi;
            this.Voltage = voltage;



        }
    }
}
