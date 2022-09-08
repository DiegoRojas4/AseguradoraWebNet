using Cotizador.Datos.CotizadorContext;
using Cotizador.Entidades;
using Cotizador.Herramientas;
using Cotizador.Modelos;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cotizador.Negocio
{
    public class CatalogosNegocio
    {
        private IOptions<AppSettings> appsettings;

        public CatalogosNegocio(IOptions<AppSettings> _appsettings)
        {
            appsettings = _appsettings;
        }

        public async Task<Catalogos<List<CatMarca>>> ConsultarCatalogoMarca()
        {
            Catalogos<List<CatMarca>> resultado = new Catalogos<List<CatMarca>>();
            resultado.Catalogo = new List<CatMarca>();
            try
            {
                var tempList = new List<CatMarca>();

                ClienteRest _clienteRest = new ClienteRest("https://api-test.aarco.com.mx/examen-insumos/ListaDeAutos.txt");

                Stream responsetxt = await _clienteRest.SimpleGetStreamer();

                using (StreamReader leerObjeto = new StreamReader(responsetxt))
                {
                    string Line;
                    while ((Line = leerObjeto.ReadLine()) != null)
                    {
                        string[] separacion = Line.Split("\t");

                        CatMarca marca = new CatMarca();

                        marca.Marca = separacion[0].ToString();
                        marca.Submarca = separacion[1].ToString();
                        marca.Modelo = separacion[2].ToString();
                        marca.Descripcion = separacion[3].ToString();
                        marca.DescripcionId = separacion[4].ToString();

                        tempList.Add(marca);
                    }
                }

                if (tempList.Count() > 0)
                {
                    resultado.Catalogo = RemoverItems(tempList);
                }

                resultado.Codigo = 1;
                resultado.Mensaje = "Ejecución exitosa";
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Mensaje = ex.Message;
            }

            return resultado;
        }


        private List<CatMarca> RemoverItems(List<CatMarca> listaOriginal)
        {
            try
            {
                var listatemporal = new List<CatMarca>(listaOriginal);

                var resultLista = new List<CatMarca>();

                if (listatemporal.Count() > 0)
                {
                    var removerItem = listatemporal.Where(x => x.Descripcion == "Descripcion").FirstOrDefault();

                    if (removerItem != null)
                    {
                        listatemporal.Remove(removerItem);
                    }
                }

                return listatemporal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertarDatosNuevosMarca(List<CatMarca> listaOriginal)
        {
            try
            {
                CotizadorDataContext cotizadorContext = new CotizadorDataContext(appsettings.Value.ConnectionStrings["CotizadorBD"]);



            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
