using System;
using System.Collections.Generic;

namespace Cotizador.Entidades
{
    public class AppSettings
    {
        public Dictionary<string, string> ConnectionStrings { get; set; }
        public Dictionary<string, string> Servicios { get; set; }
    }
}
