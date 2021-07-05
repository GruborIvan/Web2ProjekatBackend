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
    public class ElementController : ApiController
    {
        // GET: Element
        Service.IWebService proxy;
        public ElementController()
        {
            proxy = new Service.WebService();
        }

        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Models.Element))]
        public IHttpActionResult Put(string id, [FromBody] Element element)
        {
            if (element.ID != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                proxy.updateEntity(element);
            }
            catch (Exception e) { return BadRequest(); }
            return Ok(proxy.getEntity(TipEntiteta.ELEMENTS, element.ID));
        }

        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Models.Element))]
        public IHttpActionResult Post(Element element)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            proxy.addEntity(element);
            return CreatedAtRoute("DefaultApi", new { id = element.ID }, element);
        }
        //[System.Web.Http.Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(string id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            Element el = context.Elementi.ToList().Find(x => x.ID.Equals(id));
            if (el == null)
            {
                return NotFound();
            }

            proxy.deleteEntity(el);
            return Ok();
        }
        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Element))]
        public IHttpActionResult Get(string id)
        {
            Element el = proxy.getEntity(TipEntiteta.ELEMENTS, id) as Element;
            if (el == null)
            {
                return NotFound();
            }
            return Ok(el);
        }
        public IEnumerable<Element> Get()
        {
            List<Element> el = new List<Element>();
            foreach (object item in proxy.getEntities(TipEntiteta.ELEMENTS))
            {
                el.Add(item as Element);
            }
            return el;
        }
        [ResponseType(typeof(Element))]
        public IEnumerable<Element> Search(string property, string value)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            List<Element> ret = new List<Element>();

            switch (property) 
            {
                case "id":
                    ret = context.Elementi.ToList().FindAll(x => x.ID.Contains(value));
                    break;
                case "name":
                    ret = context.Elementi.ToList().FindAll(x => x.Naziv.Contains(value));
                    break;
                case "address":
                    ret = context.Elementi.ToList().FindAll(x => x.Adress.Contains(value));
                    break;
                case "longitude":
                    ret = context.Elementi.ToList().FindAll(x => x.Longitude.Contains(value));
                    break;
                case "latitude":
                    ret = context.Elementi.ToList().FindAll(x => x.Latitude.Contains(value));
                    break;
                case "type":
                    ret = context.Elementi.ToList().FindAll(x => x.ElementType.ToString().Contains(value));
                    break;
            }
            return ret;

        }
    }
}