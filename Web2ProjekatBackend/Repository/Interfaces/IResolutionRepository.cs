using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web2ProjekatBackend.Models;

namespace Web2ProjekatBackend.Repository.Interfaces
{
    public interface IResolutionRepository
    {
        IEnumerable<Resolution> GetResolutions();
        Resolution GetResolutionsForIncident(string incidentId);
        void AddResolution(Resolution resolution);
        void UpdateResolution(Resolution resolution);
    }
}
