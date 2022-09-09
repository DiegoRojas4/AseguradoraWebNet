using AutoMapper;
using Cotizador.Entidades.Catalogos;
using Cotizador.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cotizador.Negocio
{
    public class Automapper : Profile
    {
        private MapperConfiguration _config;
        public MapperConfiguration configuracion { get => _config; set => _config = value; }

        public Automapper()
        {
            _config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Marca, CatAgenciasAutos>()
                .ForMember(x => x.AgenciaId, x => x.MapFrom(y => y.MarcaId))
                .ForMember(x => x.Nombre, x => x.MapFrom(y => y.Nombre));

                cfg.CreateMap<CatAgenciasAutos, Marca>()
                .ForMember(x => x.MarcaId, x => x.MapFrom(y => y.AgenciaId))
                .ForMember(x => x.Nombre, x => x.MapFrom(y => y.Nombre));

                cfg.CreateMap<SubMarca, CatSubMarca>()
                .ForMember(x => x.AgenciaId, x => x.MapFrom(y => y.MarcaId))
                .ForMember(x => x.SubMarcaId, x => x.MapFrom(y => y.SubMarcaId))
                .ForMember(x => x.Nombre, x => x.MapFrom(y => y.Nombre));

                cfg.CreateMap<CatSubMarca, SubMarca>()
                .ForMember(x => x.MarcaId, x => x.MapFrom(y => y.AgenciaId))
                .ForMember(x => x.SubMarcaId, x => x.MapFrom(y => y.SubMarcaId))
                .ForMember(x => x.Nombre, x => x.MapFrom(y => y.Nombre));

                cfg.CreateMap<ModelosAutos, CatModeloAnio>()
                .ForMember(x => x.ModeloId, x => x.MapFrom(y => y.ModeloId))
                .ForMember(x => x.AgenciaId, x => x.MapFrom(y => y.MarcaId))
                .ForMember(x => x.SubMarcaId, x => x.MapFrom(y => y.SubMarcaId))
                .ForMember(x => x.Anio, x => x.MapFrom(y => y.Modelo));

                cfg.CreateMap<CatModeloAnio, ModelosAutos>()
                .ForMember(x => x.ModeloId, x => x.MapFrom(y => y.ModeloId))
                .ForMember(x => x.MarcaId, x => x.MapFrom(y => y.AgenciaId))
                .ForMember(x => x.SubMarcaId, x => x.MapFrom(y => y.SubMarcaId))
                .ForMember(x => x.Modelo, x => x.MapFrom(y => y.Anio));

                cfg.CreateMap<ModeloDescripcion, CatDescripciones>()
                .ForMember(x => x.SubMarcaId, x => x.MapFrom(y => y.SubMarcaId))
                .ForMember(x => x.ModeloId, x => x.MapFrom(y => y.ModeloId))
                .ForMember(x => x.Descripcion, x => x.MapFrom(y => y.Descripcion))
                .ForMember(x => x.DescripcionId, x => x.MapFrom(y => y.DescripcionId));

                cfg.CreateMap<CatDescripciones, ModeloDescripcion>()
                .ForMember(x => x.SubMarcaId, x => x.MapFrom(y => y.SubMarcaId))
                .ForMember(x => x.ModeloId, x => x.MapFrom(y => y.ModeloId))
                .ForMember(x => x.Descripcion, x => x.MapFrom(y => y.Descripcion))
                .ForMember(x => x.DescripcionId, x => x.MapFrom(y => y.DescripcionId));

            });
        }
    }
}
