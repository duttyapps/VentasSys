using System;
using System.Collections.Generic;
using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys.BL
{
    public static class BL_Ventas
    {
        public static List<Ent_Venta> getVentas(Ent_Venta ent_tienda)
        {
            return DAO_Ventas.getVentas(ent_tienda);
        }

        public static List<Ent_Productos> getDetalleVenta(string id)
        {
            return DAO_Ventas.getDetalleVenta(id);
        }

        public static List<Ent_TipoVentas> getTipoVenta(String codigo)
        {
            return DAO_Ventas.getTipoVenta(codigo);
        }

        public static string getCorrelativo(string tipo_venta)
        {
            return DAO_Ventas.getCorrelativo(tipo_venta);
        }

        public static string procesarVenta(Ent_Venta venta)
        {
            return DAO_Ventas.procesarVenta(venta);
        }

        public static string anularVenta(Ent_Anular anular)
        {
            return DAO_Ventas.anularVenta(anular);
        }

        public static List<Ent_FormaPago> getFormaPago()
        {
            return DAO_Ventas.getFormaPago();
        }

        public static List<Ent_TipoMoneda> getTipoMoneda()
        {
            return DAO_Ventas.getTipoMoneda();
        }
    }
}
