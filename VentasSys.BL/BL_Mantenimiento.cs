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

        public static List<Ent_Mantenimiento> getAlertaMantenimiento()
        {
            return DAO_Mantenimiento.getAlertaMantenimiento();
        }

        public static string updMantenimiento(Ent_Prog_Mantenimiento mant)
        {
            return DAO_Mantenimiento.updMantenimiento(mant);
        }

        public static string setTipoMantenimiento(Ent_Tipo_Mantenimiento tipo)
        {
            return DAO_Mantenimiento.setTipoMantenimiento(tipo);
        }

        public static string updTipoMantenimiento(Ent_Tipo_Mantenimiento tipo)
        {
            return DAO_Mantenimiento.updTipoMantenimiento(tipo);
        }

        public static string delTipoMantenimiento(Ent_Tipo_Mantenimiento tipo)
        {
            return DAO_Mantenimiento.delTipoMantenimiento(tipo);
        }

        public static string delMantenimiento(String id)
        {
            return DAO_Mantenimiento.delMantenimiento(id);
        }
    }
}
