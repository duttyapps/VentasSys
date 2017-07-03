using System;

namespace VentasSys.EL
{
    public class Ent_CategoriaProductos
    {
        public string id { get; set; }
        public string nombre { get; set; }

        public Ent_CategoriaProductos()
        {
            this.id = String.Empty;
            this.nombre = String.Empty;
        }
    }
}
