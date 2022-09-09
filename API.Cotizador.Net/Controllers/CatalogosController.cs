using Cotizador.Entidades;
using Cotizador.Entidades.Catalogos;
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

        [Route("api/AgregarMarcas")]
        [Produces("application/json")]
        [HttpGet]
        public async Task<Catalogos<List<Repositoriotxt>>> AgregarMarcas()
        {
            Catalogos<List<Repositoriotxt>> catalogoResult = new Catalogos<List<Repositoriotxt>>();

            try
            {
                catalogoResult = await implementacion.AgregarRegistroMarca();

                return catalogoResult;
            }
            catch (Exception ex)
            {
                catalogoResult.Catalogo = new List<Repositoriotxt>();
                catalogoResult.Codigo = 0;
                catalogoResult.Mensaje = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return catalogoResult;
            }
        }

        [Route("api/ConsultarMarcas")]
        [Produces("application/json")]
        [HttpGet]
        public Task<Catalogos<List<CatAgenciasAutos>>> ConsultarMarcasdeAutos()
        {
            Catalogos<List<CatAgenciasAutos>> listAgencias = new Catalogos<List<CatAgenciasAutos>>();
            listAgencias.Catalogo = new List<CatAgenciasAutos>();
            try
            {
                return implementacion.ConsultarMarcasdeAutos();
            }
            catch (Exception ex)
            {
                listAgencias.Codigo = 0;
                listAgencias.Mensaje = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return Task.FromResult<Catalogos<List<CatAgenciasAutos>>>(listAgencias);
            }
        }
    }
}
