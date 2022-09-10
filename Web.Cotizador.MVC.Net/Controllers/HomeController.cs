using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Cotizador.Datos.ServicioRepositorio;
using Web.Cotizador.Entidades;
using Web.Cotizador.Entidades.Catalogos;
using Web.Cotizador.MVC.Net.Models;

namespace Web.Cotizador.MVC.Net.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<AppSettings> appsettings;
        ServicioImplementacion _Implementacion;

        public HomeController(ILogger<HomeController> logger, IOptions<AppSettings> _appsettings)
        {
            _logger = logger;
            appsettings = _appsettings;
            _Implementacion = new ServicioImplementacion(appsettings);
        }

        public IActionResult Index()
        {
            List<SelectListItem> lsMarcas = new List<SelectListItem>();

            var marcas = _Implementacion.ConsultarMarcasdeAutos().Result;

            foreach (var i in marcas)
            {
                SelectListItem itemList = new SelectListItem();
                itemList.Value = i.AgenciaId.ToString();
                itemList.Text = i.Nombre;

            }

            return View(lsMarcas);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
