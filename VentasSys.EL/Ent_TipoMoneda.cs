using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasSys.EL
{
    public class Ent_TipoMoneda
    {
        public string id { get; set; }
        public string descripcion { get; set; }
        public string simbolo { get; set; }
        public double tipo_cambio { get; set; }

        public Ent_TipoMoneda()
        {
            this.id = String.Empty;
            this.descripcion = String.Empty;
            this.simbolo = String.Empty;
            this.tipo_cambio = 0D;
        }
    }
}
