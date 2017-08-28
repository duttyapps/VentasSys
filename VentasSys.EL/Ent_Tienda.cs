using System;

namespace VentasSys.EL
{
    public class Ent_Tienda
    {
        public string cod_tienda { get; set; }
        public string des_tienda { get; set; }

        public Ent_Tienda()
        {
            this.cod_tienda = String.Empty;
            this.des_tienda = String.Empty;
        }
    }
}
