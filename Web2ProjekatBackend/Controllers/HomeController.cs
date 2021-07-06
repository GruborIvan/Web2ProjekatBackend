using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web2ProjekatBackend.Models;

namespace Web2ProjekatBackend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DatabaseNotificationController dbnc = new DatabaseNotificationController();

            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
