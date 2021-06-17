﻿using System;
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
        [StringLength(255)]
        public string Coordinates { get; set; }
        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        public virtual ICollection<Incident> Incidenti { get; set; }
        public Oprema()
        {

        }
        public Oprema(string id, string name, string opremaType, string coordinates, string address)
        {
            IdOprema = id;
            Name = name;
            OpremaType = opremaType;
            Coordinates = coordinates;
            Address = address;
        }
    }
}