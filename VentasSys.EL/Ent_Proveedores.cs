using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasSys.EL
{
    public class Ent_Proveedores
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string activo { get; set; }

        public Ent_Proveedores()
        {
            this.id = String.Empty;
            this.nombre = String.Empty;
            this.direccion = String.Empty;
            this.telefono = String.Empty;
            this.activo = String.Empty;
        }
    }
}
