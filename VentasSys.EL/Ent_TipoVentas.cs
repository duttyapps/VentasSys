using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasSys.EL
{
    public class Ent_TipoVentas
    {
        public String id { get; set; }
        public String codigo { get; set; }
        public String descripcion { get; set; }

        public Ent_TipoVentas()
        {
            this.id = String.Empty;
            this.codigo = String.Empty;
            this.descripcion = String.Empty;
        }
    }
}
