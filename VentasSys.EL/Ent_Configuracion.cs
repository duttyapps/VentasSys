using System;

namespace VentasSys.EL
{
    public class Ent_Configuracion
    {
        public string RUC { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public double IGV { get; set; }
        public double TIPO_CAMBIO { get; set; }
        public string TIENDA { get; set; }

        public Ent_Configuracion()
        {
            this.RUC = String.Empty;
            this.RAZON_SOCIAL = String.Empty;
            this.DIRECCION = String.Empty;
            this.TELEFONO = String.Empty;
            this.IGV = 0D;
            this.TIPO_CAMBIO = 0D;
            this.TIENDA = String.Empty;
        }
    }
}
