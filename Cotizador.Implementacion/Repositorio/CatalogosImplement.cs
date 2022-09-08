using Cotizador.Entidades;
using Cotizador.Modelos;
using Cotizador.Negocio;
using Cotizador.Repositorio.IRepositorio;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
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

        public async Task<Catalogos<List<CatMarca>>> CatalogoMarca()
        {
            Catalogos<List<CatMarca>> resultado = new Catalogos<List<CatMarca>>();
            resultado.Catalogo = new List<CatMarca>();

            try
            {
                CatalogosNegocio negocio = new CatalogosNegocio(appsettings);

                resultado = await negocio.ConsultarCatalogoMarca();
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Mensaje = ex.Message;
            }

            return resultado;
        }
    }
}
