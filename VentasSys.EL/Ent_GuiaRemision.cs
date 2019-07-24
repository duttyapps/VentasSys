using System;

namespace VentasSys.EL
{
    public class Ent_GuiaRemision
    {
        public string nro_guia { get; set; }
        public string nro_guia_str { get; set; }
        public string cod_tienda { get; set; }
        public string fecha_emision { get; set; }
        public string fecha_traslado { get; set; }
        public string destinatario_ruc { get; set; }
        public string destinatario_razon_social { get; set; }
        public string destinatario_direccion { get; set; }
        public string ref_tipo_doc { get; set; }
        public string ref_nro_doc { get; set; }
        public int cantidad { get; set; }
        public string motivo { get; set; }

        public Ent_GuiaRemision()
        {
            this.nro_guia = String.Empty;
            this.nro_guia_str = String.Empty;
            this.cod_tienda = String.Empty;
            this.fecha_emision = String.Empty;
            this.fecha_traslado = String.Empty;
            this.destinatario_ruc = String.Empty;
            this.destinatario_razon_social = String.Empty;
            this.destinatario_direccion = String.Empty;
            this.ref_tipo_doc = String.Empty;
            this.ref_nro_doc = String.Empty;
            this.cantidad = 0;
            this.motivo = String.Empty;
        }
    }
}
