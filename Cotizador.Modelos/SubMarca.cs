using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cotizador.Modelos
{
    [Table("SubMarcas", Schema ="dbo")]
    public class SubMarca
    {
        private int submarcaid = 0;
        [Column("IdSubMarca")]
        public int SubMarcaId { get => submarcaid; set => submarcaid = value; }

        private string nombre = string.Empty;
        [Column("SubMarca")]
        public string Nombre { get => nombre; set => nombre = value; }

        private int marcaid = 0;
        [Column("IdMarca")]
        public int MarcaId { get => marcaid; set => marcaid = value; }

    }
}
