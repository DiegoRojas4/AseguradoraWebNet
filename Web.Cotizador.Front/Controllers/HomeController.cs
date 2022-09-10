using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Cotizador.Front.Implementacion;

namespace Web.Cotizador.Front.Controllers
{
    public class HomeController : Controller
    {
        private CatalogoImplementacion _catalogosImplementacion;

        public ActionResult Index()
        {

            _catalogosImplementacion = new CatalogoImplementacion();

            var resultConsulta = _catalogosImplementacion.ObtenerCatalogodeAgencias().Result;

            if (resultConsulta.Count() > 0)
            {

            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}