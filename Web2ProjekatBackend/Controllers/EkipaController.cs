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
    public class EkipaController : ApiController
    {
        // GET: Ekipa
        Service.IWebService proxy;
        public EkipaController()
        {
            proxy = new Service.WebService();
        }

    }
}