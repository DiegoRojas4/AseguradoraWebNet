using Cotizador.Entidades;
using Cotizador.Entidades.Catalogos;
using Cotizador.Modelos;
using Cotizador.Negocio;
using Cotizador.Repositorio.IRepositorio;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizador.Repositorio.Repositorio
{
    public class CatalogosImplement : ICatalogos
    {
        private IOptions<AppSettings> appsettings;

        public CatalogosImplement(IOptions<AppSettings> _appsettings)
        {
            appsettings = _appsettings;
        }

        public async Task<Catalogos<List<Repositoriotxt>>> AgregarRegistroMarca()
        {
            Catalogos<List<Repositoriotxt>> resultado = new Catalogos<List<Repositoriotxt>>();
            resultado.Catalogo = new List<Repositoriotxt>();

            try
            {
                CatalogosNegocio negocio = new CatalogosNegocio(appsettings);

                resultado = await negocio.AgregarCatalogoMarca();
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Mensaje = ex.Message;
            }

            return resultado;
        }

        public Task<Catalogos<List<CatAgenciasAutos>>> ConsultarMarcasdeAutos()
        {
            Catalogos<List<CatAgenciasAutos>> listAgencias = new Catalogos<List<CatAgenciasAutos>>();
            listAgencias.Catalogo = new List<CatAgenciasAutos>();

            try
            {
                CatalogosNegocio negocio = new CatalogosNegocio(appsettings);

                listAgencias.Catalogo = negocio.ConsultarMarcasdeAutos();
                listAgencias.Codigo = 1;
                listAgencias.Mensaje = listAgencias.Catalogo.Count() > 0 ? "Consulta éxitosa" : "No se pudo realizo la consulta";

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult<Catalogos<List<CatAgenciasAutos>>>(listAgencias);
        }

        public Task<Catalogos<List<CatSubMarca>>> ConsultarSubMarca(CatalogoRequest peticion)
        {
            Catalogos<List<CatSubMarca>> listSubMarcass = new Catalogos<List<CatSubMarca>>();
            listSubMarcass.Catalogo = new List<CatSubMarca>();

            try
            {
                CatalogosNegocio negocio = new CatalogosNegocio(appsettings);
                listSubMarcass.Catalogo = negocio.ConsultarSubMarca(peticion);

                listSubMarcass.Codigo = 1;
                listSubMarcass.Mensaje = listSubMarcass.Catalogo.Count() > 0 ? "Consulta éxitosa" : string.Concat("SubMarcas no encontradas con el IdMarca ", peticion.MarcaId.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return Task.FromResult<Catalogos<List<CatSubMarca>>>(listSubMarcass);
        }

        public Task<Catalogos<List<CatModeloAnio>>> ConsultarAnioAutos(CatalogoRequest peticion)
        {
            Catalogos<List<CatModeloAnio>> listModelos = new Catalogos<List<CatModeloAnio>>();
            listModelos.Catalogo = new List<CatModeloAnio>();

            try
            {
                CatalogosNegocio negocio = new CatalogosNegocio(appsettings);
                listModelos.Catalogo = negocio.ConsultarAnioAutos(peticion);

                listModelos.Codigo = 1;
                listModelos.Mensaje = listModelos.Catalogo.Count() > 0 ? "Consulta éxitosa" : string.Concat("Modelo no encontrado con el IdSubMarca ", peticion.SubMarcaId.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult<Catalogos<List<CatModeloAnio>>>(listModelos);
        }

        public Task<Catalogos<List<CatDescripciones>>> ConsultarDescripciones(CatalogoRequest peticion)
        {
            Catalogos<List<CatDescripciones>> listdescripciones = new Catalogos<List<CatDescripciones>>();
            listdescripciones.Catalogo = new List<CatDescripciones>();

            try
            {
                CatalogosNegocio negocio = new CatalogosNegocio(appsettings);
                listdescripciones.Catalogo = negocio.ConsultarDescripciones(peticion);

                listdescripciones.Codigo = 1;
                listdescripciones.Mensaje = listdescripciones.Catalogo.Count() > 0 ? "Consulta éxitosa" : string.Concat("Descripcione no encontrado con el IdSubMarca ", peticion.SubMarcaId.ToString(), " y IdModelo ", peticion.ModeloId.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult<Catalogos<List<CatDescripciones>>>(listdescripciones);
        }
    }
}
