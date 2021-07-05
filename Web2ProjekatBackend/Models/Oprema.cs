using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web2ProjekatBackend.Models
{
    public class Oprema
    {
        [Key]
        public string IdOprema { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string OpremaType { get; set; }

        [Required]
        public double CoordinateX { get; set; }

        [Required]
        public double CoordinateY { get; set; }

        public Incident Incident { get; set; }

        public string IncidentId { get; set; }


        public Oprema()
        {

        }

        public Oprema(string id, string name, string opremaType, double CoordinateX, double CoordinateY)
        {
            IdOprema = id;
            Name = name;
            OpremaType = opremaType;
            this.CoordinateX = CoordinateX;
            this.CoordinateY = CoordinateY;
        }
    }
}