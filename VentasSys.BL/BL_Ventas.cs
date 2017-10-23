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

        public static Ent_Venta getCabeceraVenta(string id)
        {
            return DAO_Ventas.getCabeceraVenta(id);
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

        public static Ent_Venta getVentaCredito(int nro_doc, string cod_tienda, string tipo_venta, string fecha)
        {
            return DAO_Ventas.getVentaCredito(nro_doc, cod_tienda, tipo_venta, fecha);
        }

        public static List<Ent_Abonos> getAbonos(Ent_Abonos abono)
        {
            return DAO_Ventas.getAbonos(abono);
        }

        public static string setAbono(Ent_Abonos entity)
        {
            return DAO_Ventas.setAbono(entity);
        }

        public static string finalizarCredito(int id)
        {
            return DAO_Ventas.finalizarCredito(id);
        }

        public static List<Ent_Venta> getConsultaVentas(Ent_Venta ent_venta)
        {
            return DAO_Ventas.getConsultaVentas(ent_venta);
        }

        public static List<Ent_Venta> getVentasPorCliente(Ent_Venta entity)
        {
            return DAO_Ventas.getVentasPorCliente(entity);
        }
    }
}
