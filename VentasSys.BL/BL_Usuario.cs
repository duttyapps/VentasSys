using System.Collections.Generic;
using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys.BL
{
    public static class BL_Usuario
    {
        public static Ent_Usuario login(Ent_Usuario ent)
        {
            return DAO_Usuario.login(ent);
        }

        public static List<Ent_Usuario> getUsuarios(Ent_Usuario ent)
        {
            return DAO_Usuario.getUsuarios(ent);
        }

        public static Ent_Usuario getUsuario(string id)
        {
            return DAO_Usuario.getUsuario(id);
        }
    }
}
