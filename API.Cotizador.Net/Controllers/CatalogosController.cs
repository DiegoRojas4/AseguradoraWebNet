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

        [Route("api/ConsultarSubMarcas")]
        [Produces("application/json")]
        [HttpPost]
        public Task<Catalogos<List<CatSubMarca>>> ConsultarSubMarca(CatalogoRequest peticion)
        {
            Catalogos<List<CatSubMarca>> listSubMarca = new Catalogos<List<CatSubMarca>>();
            listSubMarca.Catalogo = new List<CatSubMarca>();
            try
            {
                return implementacion.ConsultarSubMarca(peticion);
            }
            catch (Exception ex)
            {
                listSubMarca.Codigo = 0;
                listSubMarca.Mensaje = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return Task.FromResult<Catalogos<List<CatSubMarca>>>(listSubMarca);
            }
        }


        [Route("api/ConsultarModelos")]
        [Produces("application/json")]
        [HttpPost]
        public Task<Catalogos<List<CatModeloAnio>>> ConsultarAnioAutos(CatalogoRequest peticion)
        {
            Catalogos<List<CatModeloAnio>> listModelos = new Catalogos<List<CatModeloAnio>>();
            listModelos.Catalogo = new List<CatModeloAnio>();
            try
            {
                return implementacion.ConsultarAnioAutos(peticion);
            }
            catch (Exception ex)
            {
                listModelos.Codigo = 0;
                listModelos.Mensaje = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return Task.FromResult<Catalogos<List<CatModeloAnio>>>(listModelos);
            }
        }


        [Route("api/ConsultarDescripciones")]
        [Produces("application/json")]
        [HttpPost]
        public Task<Catalogos<List<CatDescripciones>>> ConsultarDescripciones(CatalogoRequest peticion)
        {
            Catalogos<List<CatDescripciones>> listDescripciones = new Catalogos<List<CatDescripciones>>();
            listDescripciones.Catalogo = new List<CatDescripciones>();
            try
            {
                return implementacion.ConsultarDescripciones(peticion);
            }
            catch (Exception ex)
            {
                listDescripciones.Codigo = 0;
                listDescripciones.Mensaje = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return Task.FromResult<Catalogos<List<CatDescripciones>>>(listDescripciones);
            }
        }
    }
}
