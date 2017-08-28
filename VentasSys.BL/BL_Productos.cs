using System.Collections.Generic;
using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys.BL
{
    public static class BL_Productos
    {
        public static List<Ent_Productos> getProductos(string nombre, string cat, string tienda)
        {
            return DAO_Productos.getProductos(nombre, cat, tienda);
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
    }
}
