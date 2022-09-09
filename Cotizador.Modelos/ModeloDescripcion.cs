using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cotizador.Modelos
{
    [Table("Descripciones", Schema ="dbo")]
    public class ModeloDescripcion
    {
        private int modeloid = 0;
        [Column("IdModelo")]
        public int ModeloId { get => modeloid; set => modeloid = value; }

        private int submarcaid = 0;
        [Column("IdSubMarca")]
        public int SubMarcaId { get => submarcaid; set => submarcaid = value; }

        private string descripcion = string.Empty;
        [Column("Descripcion")]
        public string Descripcion { get => descripcion; set => descripcion = value; }

        private string descripcionid = string.Empty;
        [Column("DescripcionId")]
        public string DescripcionId { get => descripcionid; set => descripcionid = value; }

    }
}
