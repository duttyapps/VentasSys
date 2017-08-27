using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasSys.EL
{
    public class Ent_FormaPago
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }

        public Ent_FormaPago()
        {
            this.codigo = String.Empty;
            this.descripcion = String.Empty;
        }
    }
}
