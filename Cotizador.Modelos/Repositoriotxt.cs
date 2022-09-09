using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cotizador.Modelos
{
    [Table("Repositorio", Schema ="dbo")]
    public class Repositoriotxt
    {
        private int idmarca = 0;
        [Key]
        [Column("IdRepositorio")]
        public int IdRepositorio { get => idmarca; set => idmarca = value; }


        private string marca = string.Empty;
        [Column("Marca")]
        public string Marca { get => marca; set => marca = value; }


        private string submarca = string.Empty;
        [Column("Submarca")]
        public string Submarca { get => submarca; set => submarca = value; }


        private string modelo = string.Empty;
        [Column("Modelo")]
        public string Modelo { get => modelo; set => modelo = value; }


        private string descripcion = string.Empty;
        [Column("Descripcion")]
        public string Descripcion { get => descripcion; set => descripcion = value; }


        private string descripcionid = string.Empty;
        [Column("DescripcionId")]
        public string DescripcionId { get => descripcionid; set => descripcionid = value; }

    }
}
