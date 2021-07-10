using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web2ProjekatBackend.Models
{
    [Table("PrioAddress")]
    public class PrioAddress
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string address { get; set; }
        [Required]
        public int prio { get; set; }
    }
}