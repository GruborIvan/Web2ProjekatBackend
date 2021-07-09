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
    public class PorukaController : ApiController
    {
        // GET: PlanoviRada
        INotificationRepository proxy;
        public PorukaController()
        {
            proxy = new NotificationRepository();
        }

        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Models.Poruka))]
        public IHttpActionResult Post(Poruka poziv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            proxy.AddNotification(poziv);
            return CreatedAtRoute("DefaultApi", new { id = poziv.IdPoruke }, poziv);
        }

        public IEnumerable<Poruka> Get(string mode)
        {
            if (mode == "all")
            {
                return proxy.GetAll();
            }
            else
            {
                return proxy.GetAllUnread();
            }
        }

        public IQueryable<Poruka> GetByType(TipPoruke tip)
        {
            return proxy.GetByType(tip);
        }

        public IHttpActionResult Put(List<string> ids)
        {
            if (ids == null)
            {
                return Ok();
            }
            if (ids.Count > 0)
            {
                proxy.ReadAll(ids);
            }
            return Ok();
        }

    }
}