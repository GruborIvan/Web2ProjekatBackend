using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web2ProjekatBackend.Models;

namespace Web2ProjekatBackend.Repository.Interfaces
{
    public interface IOpremaRepository
    {
        IEnumerable<Oprema> GetOprema();
        Oprema GetOpremaById(string id);
        void AddOprema(Oprema oprema);
        void UpdateOprema(Oprema oprema);
        void DeleteOprema(Oprema oprema);
    }
}
