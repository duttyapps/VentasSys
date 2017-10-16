using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys.BL
{
    public static class BL_Depositos
    {
        public static List<Ent_Bancos> getBancos()
        {
            return DAO_Depositos.getBancos();
        }

        public static List<Ent_Depositos> getDepositos(string fecha)
        {
            return DAO_Depositos.getDepositos(fecha);
        }

        public static string registrarDeposito(Ent_Depositos ent)
        {
            return DAO_Depositos.registrarDeposito(ent);
        }
    }
}
