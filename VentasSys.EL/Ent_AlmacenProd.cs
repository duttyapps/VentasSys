using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasSys.EL
{
    public class Ent_AlmacenProd
    {
        public string id { get; set; }
        public string codigo { get; set; }
        public string producto { get; set; }
        public string fecha_registro { get; set; }
        public string tienda { get; set; }
        public string fecha_salida { get; set; }
        public string cantidad { get; set; }
        public string tipo { get; set; }
    }
}
