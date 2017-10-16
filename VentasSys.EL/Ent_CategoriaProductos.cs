using System;

namespace VentasSys.EL
{
    public class Ent_CategoriaProductos
    {
        public string id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string fecha { get; set; }
        public string activo { get; set; }

        public Ent_CategoriaProductos()
        {
            this.id = String.Empty;
            this.codigo = String.Empty;
            this.nombre = String.Empty;
            this.fecha = String.Empty;
            this.activo = String.Empty;
        }
    }
}
