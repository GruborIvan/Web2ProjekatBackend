using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web2ProjekatBackend.Models
{
    [Table ("SafetyDocuments")]
    public class SafetyDocument
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public TipRada Type { get; set; }
        [Required]
        [StringLength(255)]
        public string Status { get; set; }
        [Required]
        [StringLength(255)]
        public string CreatedBy { get; set; }
        [Required]
        [StringLength(255)]
        public string IdPlanRada { get; set; }
        [Required]
        [StringLength(255)]
        public string Ekipa { get; set; } // Uzimamo iz naloga za rad
        [Required]
        [StringLength(255)]
        public string Detalji { get; set; }
        [Required]
        [StringLength(255)]
        public string Beleske { get; set; }
        [Required]
        [StringLength(255)]
        public string TelefonskiBroj { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }


        public SafetyDocument() { }
        public SafetyDocument(string id, TipRada tip, string status, string createdby, string idnalogarada, string ekipa, string detalji, string beleske, string telefon, DateTime createdon)
        {

            this.Id = id;
            this.Type = tip;
            this.Status = status;
            this.CreatedBy = createdby;
            this.IdPlanRada = idnalogarada;
            this.Ekipa = ekipa;
            this.Detalji = detalji;
            this.Beleske = beleske;
            this.TelefonskiBroj = telefon;
            this.CreatedOn = createdon;


        }
    }
}
