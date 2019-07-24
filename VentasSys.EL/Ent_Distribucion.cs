using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasSys.EL
{
    public class Ent_Distribucion
    {
        public int id { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string destino { get; set; }
        public string encargado { get; set; }
        public string detalle { get; set; }

        public Ent_Distribucion()
        {
            this.id = 0;
            this.fecha = String.Empty;
            this.hora = String.Empty;
            this.destino = String.Empty;
            this.encargado = String.Empty;
            this.detalle = String.Empty;
        }
    }
}
