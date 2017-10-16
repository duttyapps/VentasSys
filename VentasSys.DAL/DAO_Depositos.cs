using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasSys.EL;
using VentasSys.Utils;

namespace VentasSys.DAL
{
    public static class DAO_Depositos
    {
        private static MySqlConnection con;

        public static List<Ent_Bancos> getBancos()
        {
            List<Ent_Bancos> lstBancos = new List<Ent_Bancos>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_BANCOS";
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Bancos banco = new Ent_Bancos();
                banco.id = Convert.ToInt32(dr["ID"]);
                banco.nombre = Convert.ToString(dr["NOMBRE"]);
                banco.fecha_reg = Convert.ToString(dr["FECHA_REG"]);
                banco.activo = Convert.ToString(dr["ACTIVO"]);

                lstBancos.Add(banco);
            }

            con.Close();

            return lstBancos;
        }

        public static List<Ent_Depositos> getDepositos(string fecha)
        {
            List<Ent_Depositos> lstDepositos = new List<Ent_Depositos>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_DEPOSITOS";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_FECHA", fecha);
            cmd.Parameters["@PSTR_FECHA"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Depositos deposito = new Ent_Depositos();

                deposito.codigo = Convert.ToString(dr["CODIGO"]);
                deposito.fecha_emision = Convert.ToString(dr["FECHA_EMISION"]);
                deposito.banco = Convert.ToString(dr["BANCO"]);
                deposito.usuario = Convert.ToString(dr["USUARIO"]);
                deposito.monto = Convert.ToDouble(dr["MONTO"]);

                lstDepositos.Add(deposito);
            }

            con.Close();

            return lstDepositos;
        }

        public static string registrarDeposito(Ent_Depositos ent)
        {
            MySqlTransaction tr = null;
            con = Conexion.getConnection();

            string retval = "1";

            try
            {
                con.Open();

                tr = con.BeginTransaction();

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = con;
                cmd.Transaction = tr;

                cmd.CommandText = "SYS_SP_SET_DEPOSITO";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_ID_BANCO", ent.id_banco);
                cmd.Parameters["@PSTR_ID_BANCO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_USUARIO", ent.usuario);
                cmd.Parameters["@PSTR_USUARIO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_MONTO", ent.monto);
                cmd.Parameters["@PSTR_MONTO"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                retval = cmd.Parameters["@RETVAL"].Value.ToString();

                if (retval == "1")
                {
                    tr.Commit();
                }
                else
                {
                    tr.Rollback();
                    return retval;
                }

            }
            catch (MySqlException ex)
            {
                try
                {
                    tr.Rollback();
                }
                catch (MySqlException ex1)
                {
                    return ex1.ToString();
                }

                return ex.ToString();
            }
            finally
            {
                con.Close();
            }

            return retval;
        }
    }
}
