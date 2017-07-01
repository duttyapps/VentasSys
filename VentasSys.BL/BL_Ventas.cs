using System;
using System.Collections.Generic;
using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys.BL
{
    public static class BL_Ventas
    {
        public static List<Ent_TipoVentas> getTipoVenta(String codigo)
        {
            return DAO_Ventas.getTipoVenta(codigo);
        }

        public static string getCorrelativo(string tipo_venta)
        {
            return DAO_Ventas.getCorrelativo(tipo_venta);
        }
    }
}
