using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web2ProjekatBackend.Models;
using Web2ProjekatBackend.Models.DTO;
using Web2ProjekatBackend.Repository.Interfaces;
using Web2ProjekatBackend.Repository.Repository;

namespace Web2ProjekatBackend.Controllers
{
    public class CrewController : ApiController
    {
        ICrewRepository proxy;
        IIncidentRepository proxy2;

        public CrewController()
        {
            proxy = new CrewRepository();
            proxy2 = new IncidentRepository();
        }

        public IEnumerable<Ekipa> Get()
        {
            return proxy.GetAll();
        }

        public IHttpActionResult GetCrewForIncident(string incId)
        {
            Incident i = proxy2.GetIncidentById(incId);
            if (i == null)
            {
                return NotFound();
            }
            Ekipa e = proxy.GetEkipaById(i.EkipaId);
            if (e == null)
            {
                return BadRequest();
            }
            return Ok(e);
        }

        public IHttpActionResult Post([FromBody] CrewAssignDTO dto)
        {
            Incident i = proxy2.GetIncidentById(dto.IncidentId);
            if (i == null)
            {
                return NotFound();
            }

            Ekipa e = proxy.GetEkipaById(dto.CrewId);
            if (e == null)
            {
                return NotFound();
            }
            proxy.UpdateIncidentCrew(dto.IncidentId, dto.CrewId);
            return Ok();
        }

    }
}
