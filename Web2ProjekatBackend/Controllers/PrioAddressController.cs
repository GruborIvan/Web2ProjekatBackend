using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Web2ProjekatBackend.Models;

namespace Web2ProjekatBackend.Controllers
{
    public class PrioAddressController : ApiController
    {
        Service.IWebService proxy;
        public PrioAddressController()
        {
            proxy = new Service.WebService();
        }

        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Models.PrioAddress))]
        public IHttpActionResult Put(string id, [FromBody] PrioAddress prioAddress)
        {
            if (prioAddress.Id.ToString() != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                proxy.updateEntity(prioAddress);
            }
            catch (Exception e) { return BadRequest(); }
            return Ok(proxy.getEntity(TipEntiteta.ELEMENTS, prioAddress.Id.ToString()));
        }

        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Models.PrioAddress))]
        public IHttpActionResult Post(PrioAddress prioAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            proxy.addEntity(prioAddress);
            return CreatedAtRoute("DefaultApi", new { id = prioAddress.Id.ToString() }, prioAddress);
        }
        //[System.Web.Http.Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(string id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            PrioAddress el = context.PrioAddresses.ToList().Find(x => x.Id.Equals(id));
            if (el == null)
            {
                return NotFound();
            }

            proxy.deleteEntity(el);
            return Ok();
        }
        //[System.Web.Http.Authorize]
        [ResponseType(typeof(PrioAddress))]
        public IHttpActionResult Get(string id)
        {
            PrioAddress el = proxy.getEntity(TipEntiteta.ELEMENTS, id) as PrioAddress;
            if (el == null)
            {
                return NotFound();
            }
            return Ok(el);
        }
        public IEnumerable<PrioAddress> Get()
        {
            List<PrioAddress> el = new List<PrioAddress>();
            foreach (object item in proxy.getEntities(TipEntiteta.ELEMENTS))
            {
                el.Add(item as PrioAddress);
            }
            return el;
        }
        [ResponseType(typeof(PrioAddress))]
        public IEnumerable<PrioAddress> Search(string property, string value)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            List<PrioAddress> ret = new List<PrioAddress>();

            switch (property)
            {
                case "id":
                    ret = context.PrioAddresses.ToList().FindAll(x => x.Id.ToString().Contains(value));
                    break;
                case "name":
                    ret = context.PrioAddresses.ToList().FindAll(x => x.address.Contains(value));
                    break;
                case "address":
                    ret = context.PrioAddresses.ToList().FindAll(x => x.prio.ToString().Equals(value));
                    break;
            }
            return ret;

        }
    }
}
