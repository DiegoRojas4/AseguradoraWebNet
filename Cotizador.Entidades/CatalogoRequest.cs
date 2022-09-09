using System;
using System.Collections.Generic;
using System.Text;

namespace Cotizador.Entidades
{
    public class CatalogoRequest
    {
        private int marcaid = 0;
        public int MarcaId { get => marcaid; set => marcaid = value; }

        private int submarcaid = 0;
        public int SubMarcaId { get => submarcaid; set => submarcaid = value; }

        private int modeloid = 0;
        public int ModeloId { get => modeloid; set => modeloid = value; }
    }
}
