using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using Web2ProjekatBackend.Models;

namespace Web2ProjekatBackend.Controllers
{
    public class SafetyDocumentsController : ApiController
    {
        // GET: PlanoviRada
        Service.IWebService proxy;
        public SafetyDocumentsController()
        { 
            proxy = new Service.WebService();
        }

        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Models.SafetyDocument))]
        public IHttpActionResult Put(string id, [FromBody] SafetyDocument safetyDocument)
        {
            if (safetyDocument.Id != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                proxy.updateEntity(safetyDocument);
            }
            catch (Exception e) { return BadRequest(); }
            return Ok(proxy.getEntity(TipEntiteta.SAFETY_DOCUMENTS, safetyDocument.Id));
        }
        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Models.SafetyDocument))]
        public IHttpActionResult Post(SafetyDocument safetyDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            proxy.addEntity(safetyDocument);
            return CreatedAtRoute("DefaultApi", new { id = safetyDocument.Id }, safetyDocument);
        }
        //[System.Web.Http.Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(string id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            SafetyDocument f = context.SafetyDocuments.ToList().Find(x => x.Id.Equals(id));
            if (f == null)
            {
                return NotFound();
            }

            proxy.deleteEntity(f);
            return Ok();
        }
        //[System.Web.Http.Authorize]
        [ResponseType(typeof(SafetyDocument))]
        public IHttpActionResult Get(string id)
        {
            SafetyDocument f = proxy.getEntity(TipEntiteta.SAFETY_DOCUMENTS, id) as SafetyDocument;
            if (f == null)
            {
                return NotFound();
            }
            return Ok(f);
        }
        public IEnumerable<SafetyDocument> Get()
        {
            List<SafetyDocument> pr = new List<SafetyDocument>();
            foreach (object item in proxy.getEntities(TipEntiteta.SAFETY_DOCUMENTS))
            {
                pr.Add(item as SafetyDocument);
            }
            return pr;
        }
    }
}