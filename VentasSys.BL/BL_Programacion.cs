using System.Collections.Generic;
using System.Data;
using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys.BL
{
    public static class BL_Programacion
    {
        /*
        public static string setMantenimiento(Ent_Mantenimiento mantenimiento)
        {
            return DAO_Mantenimiento.setMantenimiento(mantenimiento);
        }
        */
        public static string setDistribucion(Ent_Distribucion distribucion)
        {
            return DAO_Distribucion.setDistribucion(distribucion);
        }

        public static string setAlquiler(Ent_Alquiler alquiler)
        {
            return DAO_Alquiler.setAlquiler(alquiler);
        }

        public static List<Ent_Tipo_Mantenimiento> getTipoMantenimiento(string showAll = "1")
        {
            return DAO_Mantenimiento.getTipoMantenimiento(showAll);
        }

        public static List<Ent_Mantenimiento> getMantenimiento(string nombre, string numero_doc)
        {
            return DAO_Mantenimiento.getConsultaMantenimiento(nombre, numero_doc);
        }

        public static List<Ent_Tipo_Mantenimiento> getConsultaMantenimientoDetalle(int id)
        {
            return DAO_Mantenimiento.getConsultaMantenimientoDetalle(id);
        }
    }
}
