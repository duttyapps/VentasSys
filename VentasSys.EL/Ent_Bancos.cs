using System;

namespace VentasSys.EL
{
    public class Ent_Bancos
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string fecha_reg { get; set; }
        public string activo { get; set; }

        public Ent_Bancos()
        {
            this.id = 0;
            this.nombre = String.Empty;
            this.fecha_reg = String.Empty;
            this.activo = String.Empty;
        }
    }
}
