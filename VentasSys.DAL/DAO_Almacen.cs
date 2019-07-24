using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using VentasSys.EL;
using VentasSys.Utils;
using MySql.Data.MySqlClient;

namespace VentasSys.DAL
{
    public class DAO_Almacen
    {    
        private static MySqlConnection con;
        public static List<Ent_AlmacenProd> getProducto_Almacen(string codigo, string nombre)
        {
            List<Ent_AlmacenProd> lstAlmacen = new List<Ent_AlmacenProd>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "sp_get_Almacen_productos";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@pstr_codigo", codigo);
            cmd.Parameters["@pstr_codigo"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@pstr_producto", nombre);
            cmd.Parameters["@pstr_producto"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_AlmacenProd almacen = new Ent_AlmacenProd();

                almacen.id = Convert.ToString(dr["id"]);
                almacen.codigo = Convert.ToString(dr["codigo"]);
                almacen.producto = Convert.ToString(dr["nombre"]);
                almacen.fecha_registro = Convert.ToString(dr["fecha_reg"]);
                almacen.tienda = Convert.ToString(dr["cod_tienda"]);
                almacen.fecha_salida = Convert.ToString(dr["fecha_emision"]);
                almacen.cantidad = Convert.ToString(dr["cantidad"]);
                almacen.tipo = Convert.ToString(dr["venta"]);

                lstAlmacen.Add(almacen);
            }

            con.Close();

            return lstAlmacen;
        }
    }
}
