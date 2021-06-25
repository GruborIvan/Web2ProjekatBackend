using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web2ProjekatBackend.Models
{
    [Table ("Resolutions")]
    public class Resolution
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Cause { get; set; }

        [Required]
        public string SubCause { get; set; }

        [Required]
        public string Construction { get; set; }

        [Required]
        public string Material { get; set; }

        [Required]
        public string IncidentId { get; set; }

        public Resolution() 
        {
            
        }

    }
}
