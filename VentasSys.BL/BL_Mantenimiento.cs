using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys.BL
{
    public static class BL_Mantenimiento
    {
        public static string setProg_Mantenimiento(Ent_Prog_Mantenimiento mantenimiento)
        {
            return DAO_Mantenimiento.setProg_Mantenimiento(mantenimiento);
        }

        public static string getCorrelativo()
        {
            return DAO_Mantenimiento.getCorrelativo();
        }
    }
}
