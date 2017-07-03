using System;

namespace VentasSys.EL
{
    public class Ent_Productos
    {
        public string id { get; set; }
        public string id_cat { get; set; }
        public string nombre { get; set; }
        public double costo { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }

        public Ent_Productos()
        {
            this.id = String.Empty;
            this.id_cat = String.Empty;
            this.nombre = String.Empty;
            this.costo = 0D;
            this.precio = 0D;
            this.cantidad = 1;
        }
    }
}
