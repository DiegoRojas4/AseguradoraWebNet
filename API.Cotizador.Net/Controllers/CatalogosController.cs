using Cotizador.Entidades;
using Cotizador.Modelos;
using Cotizador.Repositorio.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Cotizador.Net.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {
        private readonly IOptions<AppSettings> appsettings;
        private CatalogosImplement implementacion;

        public CatalogosController(IOptions<AppSettings> settings)
        {
            appsettings = settings;
            implementacion = new CatalogosImplement(appsettings);
        }

        [Route("cotizador/CatalogoMarca")]
        [HttpGet]
        public async Task<Catalogos<List<CatMarca>>> CatalogoMarca() //Servicio de pruebas
        {
            try
            {
                var test = await implementacion.CatalogoMarca();

                return test;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
