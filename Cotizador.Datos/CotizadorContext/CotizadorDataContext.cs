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
            base.OnModelCreating(modelBuilder);
        }




    }
}
