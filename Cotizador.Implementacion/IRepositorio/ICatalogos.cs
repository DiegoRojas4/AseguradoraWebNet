using Cotizador.Entidades;
using Cotizador.Entidades.Catalogos;
using Cotizador.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cotizador.Repositorio.IRepositorio
{
    public interface ICatalogos
    {
        public Task<Catalogos<List<Repositoriotxt>>> AgregarRegistroMarca();
        public Task<Catalogos<List<CatAgenciasAutos>>> ConsultarMarcasdeAutos();
        public Task<Catalogos<List<CatSubMarca>>> ConsultarSubMarca(CatalogoRequest peticion);
        public Task<Catalogos<List<CatModeloAnio>>> ConsultarAnioAutos(CatalogoRequest peticion);
        public Task<Catalogos<List<CatDescripciones>>> ConsultarDescripciones(CatalogoRequest peticion);
    }
}
