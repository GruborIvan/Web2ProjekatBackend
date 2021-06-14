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
            ViewBag.Title = "Home Page";
            PlanoviRadaController prc = new PlanoviRadaController();
            PlanRada pr = new PlanRada(TipRada.NEPLANIRANI_RAD, "asd", "asd", "asd", "asd", DateTime.Now, DateTime.Now, "asd", "asd", "asd", "asd", "asd", "asd", DateTime.Now);
            pr.IdPlana = "0";
            pr.Detalji = "zxc";
            PlanRada pr1 = new PlanRada(TipRada.NEPLANIRANI_RAD, "asd", "dfhdf", "ert", "cvb", DateTime.Now, DateTime.Now, "asd", "dfg", "asd", "asd", "asd", "asd", DateTime.Now);
            pr1.IdPlana = "1";
            pr1.Detalji = "sdsd";
            PlanRada pr2 = new PlanRada(TipRada.NEPLANIRANI_RAD, "asd", "fafas", "asd", "asd", DateTime.Now, DateTime.Now, "asd", "asd", "asda", "asd", "azzzsd", "zxc", DateTime.Now);
            pr2.IdPlana = "2";
            pr2.Detalji = "fa";

            prc.Post(pr);
            prc.Post(pr1);
            prc.Post(pr2);

            prc.Get();
            prc.Get("0");
            return View();
        }
    }
}
