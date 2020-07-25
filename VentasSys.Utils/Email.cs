using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.Mail;
using VentasSys.EL;
using Humanizer;

namespace VentasSys.Utils
{
    public class Email
    {
        private Ent_Tienda _ent_tienda { get; set; }
        private Ent_Configuracion _ent_configuracion { get; set; }
        private string obser { get; set; }
        public string Send_Email(Ent_Venta venta, Ent_Tienda ent_tienda, Ent_Configuracion ent_configuracion, string observacion, string adjunto)
        {
            string send ="1";
            try
            {
                obser = observacion;
                _ent_configuracion = ent_configuracion;
                _ent_tienda = ent_tienda;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("gator4068.hostgator.com");

                mail.From = new MailAddress("info@osmosisperu.com", "Osmosis Perú");
                if (!adjunto.Equals(String.Empty))
                {
                    Attachment attachment = new Attachment(adjunto);
                    mail.Attachments.Add(attachment);
                }
                //mail.To.Add("carlosarcesh@gmail.com");
                mail.To.Add(venta.email);
                mail.Subject = "Cotización";
                mail.IsBodyHtml = true;
                //mail.Body = Armar_Cotizacion_hmtl(venta);
                mail.AlternateViews.Add(Armar_Cotizacion_hmtl(venta));

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("info@osmosisperu.com", "info190792");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex) {
                send = ex.Message;
            }

            return send;
        }

        private AlternateView Armar_Cotizacion_hmtl(Ent_Venta venta)
        {
            string pagina = "<html>";
            string style = "<head></style>";
            string html = "<body>";
            LinkedResource res = new LinkedResource("logo.png");
            res.ContentId = Guid.NewGuid().ToString();
            try
            {
                //style
                //Image.FromFile("logo.png")
                style += "</style></head>";
                //html
                html += "<table style='width:100%'>";
                html += "<tr><td colspan='4' align=center><img src='cid:" + res.ContentId + @"'/></td></tr>";
                html += "<tr><td colspan='4' style='font-weight: bold;font-size: 20px; height:60px; line-height:60px; text-align:center'>OFERTA</td></tr>";
                html += "<tr><td></td><td>N° Oferta : </td><td><span>" + venta.id_cab.ToString().PadLeft(6, '0') + "</span></td></tr>";
                html += "<tr><td>Observaciones: </td><td colspan='3'><span>" + venta.denominacion + "</span></td></tr>";
                html += "<tr><td>Cliente :</td><td><span>" + venta.cliente + "</span></td><td>DNI/RUC :</td><td><span>" + venta.cliente_doc + "</span></td></tr>";
                html += "<tr><td>Ubicación :</td><td><span>LIMA</span></td><td>Fecha Emision</td><td><span>" + venta.emision + "</span></td></tr>";
                html += venta.tipo_cotizacion == "AL" ? "<tr><td>Dia(s) de Alquiler:</td><td><span>" + venta.dias_alquiler + " dia(s)</span></td></tr>" : "";
                html += "</table>";
                html += "<p style='font-weight: bold;font-size: 14px; padding-left:20px;'> Detalle de Producto(s):</p>";
                html += "<table style='margin: 20px; width: 90%; margin-left:5%; border-collapse: collapse;'>";
                html += "<tr style='height:35px; line-height:35px;font-weight: bold;font-size: 12px; background-color:blue; color:white'><th style='border: 1px solid #ddd;'>ID</th><th style='border: 1px solid #ddd;'>Producto</th><th style='border: 1px solid #ddd;'>Cantidad</th><th style='border: 1px solid #ddd;'>Precio Unit.</th><th style='border: 1px solid #ddd;'>Total Importe</th></tr>";
                foreach (Ent_Productos prod in venta.lstProductos) {
                    html += "<tr style='height:30px; font-weight: normal;font-size: 10px;'><th style='border: 1px solid #ddd;'>" + prod.cod_producto + "</th><th style='border: 1px solid #ddd;'>" + prod.nombre + "</th><th style='border: 1px solid #ddd;'>" + prod.cantidad + "</th><th style='border: 1px solid #ddd;'>" + prod.precio.ToString("#0.00") + "</th><th style='border: 1px solid #ddd;'>" + prod.monto_total.ToString("#0.00") + "</th></tr>";
                }
                html += "<tr style='font-weight: normal;font-size: 10px;'><th></th><th></th><th style='border: 1px solid #ddd;' colspan='2'>Total Oferta (Sin IGV)</th><th style='border: 1px solid #ddd;'>" + (venta.monto_total - (venta.monto_total * 0.18)).ToString("#0.00") + "</th></tr>";
                html += "<tr style='font-weight: normal;font-size: 10px;'><th></th><th></th><th style='border: 1px solid #ddd;' colspan='2'>IGV - 18%</th><th style='border: 1px solid #ddd;'>" + (venta.monto_total * 0.18).ToString("#0.00") + "</th></tr>";
                html += "<tr style='font-weight: normal;font-size: 10px;'><th></th><th></th><th style='border: 1px solid #ddd;' colspan='2'>Monto Total</th><th style='border: 1px solid #ddd;'>" + venta.monto_total.ToString("#0.00") + "</th></tr>";
                html += "</table>";

                String intPart = venta.monto_total.ToString().Split('.')[0];

                String totalString = Convert.ToInt32(intPart).ToWords().ToUpper();
                var decimalPart = (int)(((decimal)venta.monto_total % 1) * 100);
                String textoTotal = "Son " + totalString + " Y " + decimalPart.ToString().PadLeft(2, '0') + "/100 " + ((venta.moneda == "PEN") ? "Soles" : "Dólares Americanos");

                html += "<p style='font-weight: bold;font-size: 11px; padding-left:20px;'>" + textoTotal + "</p>";

                html += "<span style='font-weight: bold;font-size: 11px; padding-left:20px;'>" + obser + "</span><br/>";
                html += "<span style='color:red; font-weight: bold;font-size: 11px; padding-left:20px;'>SOLO POR PAGO POR TRANSFERENCIA BANCARIA</span><br/>";
                html += "<span style='color:red; font-weight: bold;font-size: 11px; padding-left:20px;'>RECOGER CON VOUCHER DE DEPOSITO</span><br/>";
                html += "<span style='font-weight: bold;font-size: 11px; padding-left:20px;'>" + _ent_configuracion.RAZON_SOCIAL + "</span><br/>";
                html += "<span style='font-weight: bold;font-size: 11px; padding-left:20px;'>RUC: " + _ent_configuracion.RUC + " - " + _ent_configuracion.DIRECCION + "</span><br/>";
                html += "<span style='font-weight: bold;font-size: 11px; padding-left:20px;'>CUENTA BBVA</span><br/>";
                html += "<span style='font-weight: bold;font-size: 11px; padding-left:20px;'>SOLES: 0011-0117-0100097865 INTERBANCARIO SOLES 011-117-000100097865</span><br/>";
                html += "<span style='font-weight: bold;font-size: 11px; padding-left:20px;'>DOLARES: 0011-0117-01-00095641 INTERBANCARIO DOLARES 011-117-000100095641-95</span><br/>";

                html += "<p style='color: red'>NOTA IMPORTANTE DE INSTALACIÓN: OSMOSISPERU NO SE HACE RESPONSABLE POR DESPERFECTOS PRODUCIDO POR ACCIONES AJENAS A NUESTRA INSTALACIÓN COMO POR EJEMPLO, TUBERIAS ANTIGUAS, TUBOS DE ABASTO VIEJOS, O DESPERFECTOS EN SUS DESAGÜES, ASI TAMBIÉN  NO NOS HACEMOS RESPONSABLES POR ALGUNA MODIFICACIÓN QUE SE HAYA REALIZADO AL MOMENTO DE INSTALARLO.</p>";
                html += "<p style='color: red'>SI NO ESTUVIERA CONFORME CON EL EQUIPO TIENE DENTRO DE LOS 07 DÍAS NATURALES PARA REALIZAR LA DEVOLUCIÓN DEL EQUIPO DEBIDAMENTE EMBALADO Y CON SU RESPECTIVA CAJA PREVIA REVISIÓN DEL MISMO. SI TODO ESTA CONFORME PASAREMOS A REALIZAR LA DEVOLUCIÓN DEL COSTO DEL EQUIPO, MAS NO DE LA INSTALACIÓN NI DE LOS FILTROS, PUES YA ESTAN USADOS Y SE TIENEN QUE DESHECHAR, SE CONSIDERA COMO PÉRDIDA. EL COSTO DE LOS FILTROS.</p>";


                html += "</body>";
            }
            catch (Exception ex) {
                pagina = "<b>" + ex.Message + "</b>";
            }

            pagina += style;
            pagina += html;
            pagina += "</html>";

            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(@pagina, null, "text/html");
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }

    }
}
