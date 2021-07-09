using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web2ProjekatBackend.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string NazivProfilneSlike { get; set; }
        public VrsteKorisnika UserType { get; set; }
    }
}