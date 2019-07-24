using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasSys.EL
{
    public class Ent_Alquiler
    {
        public int id { get; set; }
        public string fecha_ent { get; set; }
        public string hora_ent { get; set; }
        public string fecha_dev { get; set; }
        public string hora_dev { get; set; }
        public string cliente { get; set; }
        public string detalle { get; set; }
    }
}
