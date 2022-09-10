using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Web.Cotizador.Front.Entidades;
using Web.Cotizador.Front.Herramientas;

namespace Web.Cotizador.Front.Negocio
{
    public class CatalogosNegocio
    {
        private ClienteRest clienterest;

        public async Task<List<CatAgencias>> ObtenerCatalogodeAgencias()
        {
            try
            {
                List<CatAgencias> lsagencias = new List<CatAgencias>();

                clienterest = new ClienteRest("https://localhost:5001/Catalogos/api/ConsultarMarcas");

                var response =  await clienterest.SimpleGet<Catalogos<List<CatAgencias>>>();

                if (response.Codigo == 1)
                {
                    lsagencias = response.Catalogo;
                }

                return lsagencias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}