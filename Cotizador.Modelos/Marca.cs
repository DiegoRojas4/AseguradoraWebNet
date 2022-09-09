using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cotizador.Modelos
{
    [Table("Marcas", Schema ="dbo")]
    public class Marca
    {
        private int marcaid = 0;
        [Column("IdMarca")]
        public int MarcaId { get => marcaid; set => marcaid = value; }

        private string nombre = string.Empty;
        [Column("Marca")]
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
