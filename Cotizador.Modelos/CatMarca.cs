using System;

namespace Cotizador.Modelos
{
    public class CatMarca
    {
        private string marca = string.Empty;
        public string Marca { get => marca; set => marca = value; }

        private string submarca = string.Empty;
        public string Submarca { get => submarca; set => submarca = value; }

        private string modelo = string.Empty;
        public string Modelo { get => modelo; set => modelo = value; }

        private string descripcion = string.Empty;
        public string Descripcion { get => descripcion; set => descripcion = value; }

        private string descripcionid = string.Empty;
        public string DescripcionId { get => descripcionid; set => descripcionid = value; }

    }
}
