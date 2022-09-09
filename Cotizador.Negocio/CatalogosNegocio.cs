using AutoMapper;
using Cotizador.Datos.CotizadorContext;
using Cotizador.Entidades;
using Cotizador.Entidades.Catalogos;
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
        private CotizadorDataContext cotizadorContext = null;

        IMapper mapper = new Automapper().configuracion.CreateMapper();

        public CatalogosNegocio(IOptions<AppSettings> _appsettings)
        {
            appsettings = _appsettings;
        }

        public async Task<Catalogos<List<Repositoriotxt>>> AgregarCatalogoMarca()
        {
            Catalogos<List<Repositoriotxt>> resultado = new Catalogos<List<Repositoriotxt>>();
            resultado.Catalogo = new List<Repositoriotxt>();
            try
            {
                var tempList = new List<Repositoriotxt>();

                string ApiEndPoint = appsettings.Value.Servicios["ApiMarcas"];

                ClienteRest _clienteRest = new ClienteRest(ApiEndPoint);

                Stream responsetxt = await _clienteRest.SimpleGetStreamer();

                using (StreamReader leerObjeto = new StreamReader(responsetxt))
                {
                    string Line;
                    while ((Line = leerObjeto.ReadLine()) != null)
                    {
                        string[] separacion = Line.Split("\t");

                        Repositoriotxt marca = new Repositoriotxt();

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
                    bool result = await InsertarDatosNuevosMarca(resultado.Catalogo);

                    resultado.Codigo = result ? 1 : 0;
                    resultado.Mensaje = result  ? "Datos insertados correctamente" : "No se pudo realizar la inserción de datos";
                }
            }
            catch (Exception ex)
            {
                string logger = string.Empty;

                resultado.Codigo = 0;
                logger = ex.Message;
                if (ex.InnerException != null)
                {
                    logger = ex.InnerException.Message;
                }
                resultado.Mensaje = logger;
            }

            return resultado;
        }
        private List<Repositoriotxt> RemoverItems(List<Repositoriotxt> listaOriginal)
        {
            try
            {
                var listatemporal = new List<Repositoriotxt>(listaOriginal);

                var resultLista = new List<Repositoriotxt>();

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
        private async Task<bool> InsertarDatosNuevosMarca(List<Repositoriotxt> listaOriginal)
        {
            bool ejecucionExitosa = false;
            try
            {
                cotizadorContext = new CotizadorDataContext(appsettings.Value.ConnectionStrings["CotizadorBD"]);

                await cotizadorContext.RepositorioNotas.AddRangeAsync(listaOriginal);
                var resultado = await cotizadorContext.SaveChangesAsync();

                ejecucionExitosa = true;
            }
            catch (Exception ex)
            {
                ejecucionExitosa = false;
                throw ex;
            }

            return ejecucionExitosa;
        }


        public List<CatAgenciasAutos> ConsultarMarcasdeAutos()
        {
            List<CatAgenciasAutos> listmarcas = new List<CatAgenciasAutos>();
            try
            {
                cotizadorContext = new CotizadorDataContext(appsettings.Value.ConnectionStrings["CotizadorBD"]);

                List<Marca> resulConsulta = cotizadorContext.MarcaAutos.ToList();

                listmarcas = mapper.Map<List<Marca>, List<CatAgenciasAutos>>(resulConsulta);

                return listmarcas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public List<CatSubMarca> ConsultarSubMarca(CatalogoRequest requets)
        {
            List<CatSubMarca> listsubmarcas = new List<CatSubMarca>();
            try
            {
                cotizadorContext = new CotizadorDataContext(appsettings.Value.ConnectionStrings["CotizadorBD"]);

                List<SubMarca> resultConsulta = cotizadorContext.SubMarcaAutos.Where(x => x.MarcaId == requets.MarcaId).ToList();

                listsubmarcas = mapper.Map<List<SubMarca>, List<CatSubMarca>>(resultConsulta);

                return listsubmarcas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CatModeloAnio> ConsultarAnioAutos(CatalogoRequest request)
        {
            List<CatModeloAnio> listModelos = new List<CatModeloAnio>();
            try
            {
                cotizadorContext = new CotizadorDataContext(appsettings.Value.ConnectionStrings["CotizadorBD"]);

                List<ModelosAutos> resultConsulta = cotizadorContext.VersionAuto.Where(x => x.SubMarcaId == request.SubMarcaId).ToList();

                listModelos = mapper.Map<List<ModelosAutos>, List<CatModeloAnio>>(resultConsulta);

                return listModelos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
