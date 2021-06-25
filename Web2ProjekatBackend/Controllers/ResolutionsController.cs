using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using Web2ProjekatBackend.Models;
using Web2ProjekatBackend.Repository.Interfaces;
using Web2ProjekatBackend.Repository.Repository;

namespace Web2ProjekatBackend.Controllers
{
    public class ResolutionsController : ApiController
    {
        // GET: PlanoviRada
        IResolutionRepository proxy;
       
        public ResolutionsController()
        {
            proxy = new ResolutionRepository();
        }

        public IEnumerable<Resolution> Get()
        {
            return proxy.GetResolutions();
        }

        public IEnumerable<Resolution> Get(string incidentId)
        {
            return proxy.GetResolutionsForIncident(incidentId);
        }

        public IHttpActionResult Post([FromBody] Resolution resolution)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            proxy.AddResolution(resolution);
            return CreatedAtRoute("DefaultApi", new { id = resolution.Id }, resolution);
        }
       
    }
}