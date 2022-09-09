using Cotizador.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cotizador.Datos.CotizadorContext
{
    public class CotizadorDataContext : DbContext
    {

        public CotizadorDataContext(string ConnectionString) : base(GetContext(ConnectionString))
        {

        }

        public static DbContextOptions GetContext(string ConnectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), ConnectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marca>().HasKey(x => x.MarcaId);
            modelBuilder.Entity<SubMarca>().HasKey(x => x.SubMarcaId);
            modelBuilder.Entity<ModelosAutos>().HasKey(x => x.ModeloId);
            modelBuilder.Entity<ModeloDescripcion>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Repositoriotxt> RepositorioNotas { get; set; }
        public DbSet<Marca> MarcaAutos { get; set; }
        public DbSet<SubMarca> SubMarcaAutos { get; set; }
        public DbSet<ModelosAutos> VersionAuto { get; set; }

        public DbSet<ModeloDescripcion> DescripcionAutos { get; set; }


    }
}
