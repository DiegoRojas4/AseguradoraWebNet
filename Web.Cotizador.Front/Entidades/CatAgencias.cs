using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Cotizador.Front.Entidades
{
    public class CatAgencias
    {
        private int agenciaid = 0;
        public int AgenciaId { get => agenciaid; set => agenciaid = value; }

        private string nombre = string.Empty;
        public string Nombre { get => nombre; set => nombre = value; }
    }
}