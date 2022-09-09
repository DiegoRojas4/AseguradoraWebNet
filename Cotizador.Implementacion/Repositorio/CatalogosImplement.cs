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
    }
}
