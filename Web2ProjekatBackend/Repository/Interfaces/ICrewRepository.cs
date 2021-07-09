using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web2ProjekatBackend.Models;

namespace Web2ProjekatBackend.Repository.Interfaces
{
    public interface ICrewRepository
    {
        IEnumerable<Ekipa> GetAll();
    }
}