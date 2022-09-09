using System;
using System.Collections.Generic;
using System.Text;

namespace Cotizador.Entidades
{
    public class CatalogoRequest
    {
        private int marcaid = 0;
        public int MarcaId { get => marcaid; set => marcaid = value; }
    }
}
