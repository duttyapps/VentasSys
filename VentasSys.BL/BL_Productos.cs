using System.Collections.Generic;
using System.Data;
using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys.BL
{
    public static class BL_Productos
    {
        public static List<Ent_Productos> getProductos(string nombre, string cat, string tienda, string estado)
        {
            return DAO_Productos.getProductos(nombre, cat, tienda, estado);
        }

        public static Ent_Productos getProducto(string id, string tienda)
        {
            return DAO_Productos.getProducto(id, tienda);
        }

        public static int getStockProducto(int id_prod, string tienda)
        {
            return DAO_Productos.getStockProducto(id_prod, tienda);
        }

        public static string insertarProducto(Ent_Productos producto, string tienda)
        {
            return DAO_Productos.insertarProducto(producto, tienda);
        }

        public static double getPrecioProducto(int id)
        {
            return DAO_Productos.getPrecioProducto(id);
        }

        public static string eliminarProducto(string id)
        {
            return DAO_Productos.eliminarProducto(id);
        }

        public static string editarProducto(Ent_Productos producto)
        {
            return DAO_Productos.editarProducto(producto);
        }

        public static List<Ent_Proveedores> getProveedores()
        {
            return DAO_Productos.getProveedores();
        }

        public static void getReporteStockProductos(string cat, string estado, string tienda, ref DataSet ds, ref DataTable dt)
        {
            DAO_Productos.getReporteStockProductos(cat, estado, tienda, ref ds, ref dt);
        }

        public static string generarCodigoProducto(string cod_tienda, int id, int cat)
        {
            return id.ToString(cod_tienda + cat.ToString("00") + "00000");
        }
    }
}
