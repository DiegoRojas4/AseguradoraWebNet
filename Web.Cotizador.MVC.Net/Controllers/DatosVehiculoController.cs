using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Cotizador.MVC.Net.Controllers
{
    public class DatosVehiculoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
