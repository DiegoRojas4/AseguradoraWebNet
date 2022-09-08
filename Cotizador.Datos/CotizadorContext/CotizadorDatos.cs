using System;
using System.Collections.Generic;
using System.Text;

namespace Cotizador.Datos.CotizadorContext
{
    public class CotizadorDatos
    {
        private string ConnectionString;

        public CotizadorDatos(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
    }
}
