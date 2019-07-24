using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasSys.EL
{
    public class Ent_Prog_Mantenimiento
    {
        public int documento { get; set; }
        public string documento_des { get; set; }
        public string tienda { get; set; }
        public string tipo_persona { get; set; }
        public string tipo_documento { get; set; }
        public string numero_documento { get; set; }
        public string cliente_des { get; set; }
        public Ent_Clientes cliente { get; set; }
        public List<Ent_Tipo_Mantenimiento> mantenimiento { get; set; }
        public string estado { get; set; }
        public string fecha_salida { get; set; }
        public string usuario { get; set; }
    }
}
