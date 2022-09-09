using System;
using System.Collections.Generic;
using System.Text;

namespace Cotizador.Entidades.Catalogos
{
    public class CatAgenciasAutos
    {
        private int agenciaid = 0;
        public int AgenciaId { get => agenciaid; set => agenciaid = value; }

        private string nombre = string.Empty;
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
