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

        public static string setVenta(Ent_Venta venta)
        {
            string result_cab = DAO_Ventas.setCabeceraVenta(venta);

            if (result_cab == "1")
            {
                string result_det = DAO_Ventas.setDetalleVenta(venta);

                if (result_det != "1")
                {
                    return result_det;
                }
            }

            return result_cab;
        }
    }
}
