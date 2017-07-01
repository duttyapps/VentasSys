using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasSys.EL
{
    public class Ent_Clientes
    {
        public string id { get; set; }
        public string nombres { get; set; }
        public string dni { get; set; }
        public string direccion { get; set; }

        public Ent_Clientes()
        {
            this.id = String.Empty;
            this.nombres = String.Empty;
            this.dni = String.Empty;
            this.direccion = String.Empty;
        }
    }
}
