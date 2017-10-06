using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using VentasSys.EL;
using VentasSys.Utils;

namespace VentasSys.DAL
{
    public class DAO_Proveedores
    {
        private static MySqlConnection con;

        public static List<Ent_Proveedores> getProveedores()
        {
            List<Ent_Proveedores> lstProveedores = new List<Ent_Proveedores>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_PROVEEDORES";
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Proveedores proveedor = new Ent_Proveedores();
                proveedor.id = Convert.ToString(dr["ID"]);
                proveedor.nombre = Convert.ToString(dr["NOMBRE"]);
                proveedor.direccion = Convert.ToString(dr["DIRECCION"]);
                proveedor.telefono = Convert.ToString(dr["TELEFONO"]);

                lstProveedores.Add(proveedor);
            }

            con.Close();

            return lstProveedores;
        }
    }
}
