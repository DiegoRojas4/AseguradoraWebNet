using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cotizador.Modelos
{
    [Table("Modelos", Schema = "dbo")]
    public class ModelosAutos
    {
        private int modeloid = 0;
        [Column("IdModelo")]
        public int ModeloId { get => modeloid; set => modeloid = value; }

        private int submarcaid = 0;
        [Column("IdSubMarca")]
        public int SubMarcaId { get => submarcaid; set => submarcaid = value; }

        private int marcaid = 0;
        [Column("IdMarca")]
        public int MarcaId { get => marcaid; set => marcaid = value; }

        private int modelo = 0;
        [Column("Modelo")]
        public int Modelo { get => modelo; set => modelo = value; }
    }
}
