using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Web.Cotizador.Front.Entidades;
using Web.Cotizador.Front.Models;
using Web.Cotizador.Front.Negocio;

namespace Web.Cotizador.Front.Implementacion
{
    public class CatalogoImplementacion
    {
        public Task<List<ModelMarca>> ObtenerCatalogodeAgencias()
        {
            List<ModelMarca> marcas = new List<ModelMarca>();
            try
            {
                List<CatAgencias> lsagencias = new List<CatAgencias>();

                CatalogosNegocio negocio = new CatalogosNegocio();

                lsagencias = negocio.ObtenerCatalogodeAgencias().Result;

                if (lsagencias.Count() > 0)
                {
                    foreach (var i in lsagencias)
                    {
                        ModelMarca model = new ModelMarca();

                        model.Id = i.AgenciaId;
                        model.Nombre = i.Nombre;

                        marcas.Add(model);
                    }
                }

                return Task.FromResult<List<ModelMarca>>(marcas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}