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
    }
}
