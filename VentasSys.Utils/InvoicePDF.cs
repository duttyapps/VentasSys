using System;
using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using VentasSys.EL;
using Humanizer;

namespace VentasSys.Utils
{
    public class InvoicePDF
    {
        private String logo = "./logo.png";
        private int marginTop = 10;
        private int marginLeft = 10;
        private int marginRight = 10;
        private String fontName = "Verdana";

        public void createServicioTecnico(Ent_Configuracion ent_configuracion, Ent_Prog_Mantenimiento prog)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            //XImage image = XImage.FromFile(logo);
            //gfx.DrawImage(image, 0, marginTop, 256, 80);

            XFont font = new XFont(fontName, 10);
            XFont fontBox = new XFont(fontName, 15);

            int yPosHeader1 = marginTop + 20;
            gfx.DrawString(ent_configuracion.RAZON_SOCIAL, font, XBrushes.Black, marginLeft, yPosHeader1);
            yPosHeader1 = yPosHeader1 + 15;
            gfx.DrawString(ent_configuracion.DIRECCION, font, XBrushes.Black, marginLeft, yPosHeader1);
            yPosHeader1 = yPosHeader1 + 15;
            gfx.DrawString("Cel. " + ent_configuracion.TELEFONO, font, XBrushes.Black, marginLeft, yPosHeader1);
            yPosHeader1 = yPosHeader1 + 15;
            gfx.DrawString("serviciotecnico@osmosisperu.com / www.osmosisperu.com", font, XBrushes.Black, marginLeft, yPosHeader1);

            int yPosHeader2 = marginTop;
            drawBox(gfx, Convert.ToInt32(page.Width / 1.5), marginTop, Convert.ToInt32(page.Width / 2.9 - marginRight * 2), 80);
            yPosHeader2 = yPosHeader2 + 20;
            gfx.DrawString("R.U.C. " + ent_configuracion.RUC, fontBox, XBrushes.Black, Convert.ToInt32(page.Width / 1.5) + 15, yPosHeader2);
            gfx.DrawRectangle(XBrushes.Black, Convert.ToInt32(page.Width / 1.5), 40, Convert.ToInt32(page.Width / 2.9 - marginRight * 2), 20);
            yPosHeader2 = yPosHeader2 + 25;
            gfx.DrawString("SERVICIO TÉCNICO", fontBox, XBrushes.White, Convert.ToInt32(page.Width / 1.5) + 15, yPosHeader2);
            yPosHeader2 = yPosHeader2 + 25;
            gfx.DrawString(prog.documento_des, fontBox, XBrushes.Black, Convert.ToInt32(page.Width / 1.5) + 15, yPosHeader2);

            int yPosCustomerDetails = yPosHeader2 + 40;
            gfx.DrawString("Lima, " + DateTime.Now.ToString("d 'de' MMMM 'del' yyyy"), font, XBrushes.Black, marginLeft, yPosCustomerDetails);
            yPosCustomerDetails = yPosCustomerDetails + 20;
            gfx.DrawString("Cliente: " + prog.cliente_des, font, XBrushes.Black, marginLeft, yPosCustomerDetails);
            gfx.DrawString("Solicitante: _______________________________", font, XBrushes.Black, page.Width / 2, yPosCustomerDetails);
            yPosCustomerDetails = yPosCustomerDetails + 20;
            gfx.DrawString("Dirección: " + prog.cliente.direccion, font, XBrushes.Black, marginLeft, yPosCustomerDetails);
            gfx.DrawString("RUC: " + prog.cliente.dni, font, XBrushes.Black, page.Width / 1.35, yPosCustomerDetails);

            int yPosBoxMoreDetails = yPosCustomerDetails + 10;
            drawBox(gfx, marginLeft, yPosBoxMoreDetails, Convert.ToInt32(page.Width - marginRight * 2), 75);

            int yPosBoxMoreDetailsContent = yPosBoxMoreDetails + 20;
            gfx.DrawString("Llamada:  Fecha: ___/___/____    Hora: ___/___", font, XBrushes.Black, marginLeft + 10, yPosBoxMoreDetailsContent);
            yPosBoxMoreDetailsContent = yPosBoxMoreDetailsContent + 20;
            gfx.DrawString("Servicio:  Fecha: ___/___/____    Hora: ___/___", font, XBrushes.Black, marginLeft + 10, yPosBoxMoreDetailsContent);
            yPosBoxMoreDetailsContent = yPosBoxMoreDetailsContent + 20;
            gfx.DrawString("Persona Contacto:  ________________________________________    Teléfono Contacto: _____________", font, XBrushes.Black, marginLeft + 10, yPosBoxMoreDetailsContent);

            int totalItems = prog.mantenimiento.Count;

            int yPosBoxItems = yPosBoxMoreDetailsContent + 25;
            int yPosBoxTitle = yPosBoxItems + 15;
            int boxHeight = yPosBoxTitle + 20 * totalItems - yPosBoxItems + 10;

            //ITEMS BOX
            drawBox(gfx, marginLeft, yPosBoxItems, Convert.ToInt32(page.Width - marginRight * 2), boxHeight);

            //TITLE BOX
            drawBox(gfx, marginLeft, yPosBoxItems, Convert.ToInt32(page.Width - marginRight * 2), 20);

            int xPosDesc = marginLeft + 10;

            gfx.DrawString("DESCRIPCIÓN", font, XBrushes.Black, xPosDesc, yPosBoxTitle);

            int yPosBoxTitleWMargin = yPosBoxTitle + 20;
            int yPosLastItem = 0;
            int i = 0;

            prog.mantenimiento.ForEach(delegate (Ent_Tipo_Mantenimiento m) {
                yPosLastItem = yPosBoxTitleWMargin + 20 * i;
                gfx.DrawString(m.descripcion, font, XBrushes.Black, xPosDesc, yPosLastItem);
                i++;
            });

            String filename = "invoices\\serviciotecnico_" + prog.documento + ".pdf";
            document.Save(filename);
            Process.Start(filename);
        }

        public void createBoleta(Ent_Configuracion ent_configuracion, Ent_Venta venta)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            //XImage image = XImage.FromFile(logo);
            //gfx.DrawImage(image, 0, marginTop, 256, 80);

            XFont font = new XFont(fontName, 10);
            XFont fontBox = new XFont(fontName, 15);
            XFont fontNota = new XFont(fontName, 7);

            int yPosHeader1 = marginTop + 20;
            gfx.DrawString(ent_configuracion.RAZON_SOCIAL, font, XBrushes.Black, marginLeft, yPosHeader1);
            yPosHeader1 = yPosHeader1 + 15;
            gfx.DrawString(ent_configuracion.DIRECCION, font, XBrushes.Black, marginLeft, yPosHeader1);
            yPosHeader1 = yPosHeader1 + 15;
            gfx.DrawString("Cel. " + ent_configuracion.TELEFONO, font, XBrushes.Black, marginLeft, yPosHeader1);
            yPosHeader1 = yPosHeader1 + 15;
            gfx.DrawString("serviciotecnico@osmosisperu.com / www.osmosisperu.com", font, XBrushes.Black, marginLeft, yPosHeader1);

            int yPosHeader2 = marginTop;
            drawBox(gfx, Convert.ToInt32(page.Width / 1.5), marginTop, Convert.ToInt32(page.Width / 2.9 - marginRight * 2), 80);
            yPosHeader2 = yPosHeader2 + 20;
            gfx.DrawString("R.U.C. " + ent_configuracion.RUC, fontBox, XBrushes.Black, Convert.ToInt32(page.Width / 1.5) + 15, yPosHeader2);
            gfx.DrawRectangle(XBrushes.Black, Convert.ToInt32(page.Width / 1.5), 40, Convert.ToInt32(page.Width / 2.9 - marginRight * 2), 20);
            yPosHeader2 = yPosHeader2 + 25;
            gfx.DrawString("BOLETA", fontBox, XBrushes.White, Convert.ToInt32(page.Width / 1.5) + 65, yPosHeader2);
            yPosHeader2 = yPosHeader2 + 25;
            gfx.DrawString(venta.nro_doc_str, fontBox, XBrushes.Black, Convert.ToInt32(page.Width / 1.5) + 35, yPosHeader2);

            int yPosCustomerDetails = yPosHeader2 + 40;
            gfx.DrawString("Lima, " + DateTime.Now.ToString("d 'de' MMMM 'del' yyyy"), font, XBrushes.Black, marginLeft, yPosCustomerDetails);
            yPosCustomerDetails = yPosCustomerDetails + 20;
            gfx.DrawString("Cliente: " + venta.cliente, font, XBrushes.Black, marginLeft, yPosCustomerDetails);
            yPosCustomerDetails = yPosCustomerDetails + 20;
            gfx.DrawString("Dirección: " + venta.direccion, font, XBrushes.Black, marginLeft, yPosCustomerDetails);
            gfx.DrawString("DNI/RUC: " + venta.cliente_doc, font, XBrushes.Black, page.Width / 1.35, yPosCustomerDetails);

            int totalItems = venta.lstProductos.Count;

            int yPosBoxItems = yPosCustomerDetails + 25;
            int yPosBoxTitle = yPosBoxItems + 15;
            int boxHeight = yPosBoxTitle + 20 * totalItems - yPosBoxItems + 10;

            //ITEMS BOX
            drawBox(gfx, marginLeft, yPosBoxItems, Convert.ToInt32(page.Width - marginRight * 2), boxHeight);

            //TITLE BOX
            drawBox(gfx, marginLeft, yPosBoxItems, Convert.ToInt32(page.Width - marginRight * 2), 20);

            int xPosCant = marginLeft + 10;
            int xPosDesc = marginLeft + 60;
            int xPosPUnit = Convert.ToInt32(page.Width - 150);
            int xPosImporte = Convert.ToInt32(page.Width - 80);

            gfx.DrawString("CANT.", font, XBrushes.Black, xPosCant, yPosBoxTitle);
            gfx.DrawString("DESCRIPCIÓN", font, XBrushes.Black, xPosDesc, yPosBoxTitle);
            gfx.DrawString("P. UNIT", font, XBrushes.Black, xPosPUnit, yPosBoxTitle);
            gfx.DrawString("IMPORTE", font, XBrushes.Black, xPosImporte, yPosBoxTitle);

            int yPosBoxTitleWMargin = yPosBoxTitle + 20;
            int yPosLastItem = 0;
            int i = 0;

            venta.lstProductos.ForEach(delegate (Ent_Productos m) {
                yPosLastItem = yPosBoxTitleWMargin + 20 * i;
                gfx.DrawString(Convert.ToString(m.cantidad), font, XBrushes.Black, xPosCant, yPosLastItem);
                gfx.DrawString(m.nombre, font, XBrushes.Black, xPosDesc, yPosLastItem);
                gfx.DrawString(m.precio.ToString("#0.00"), font, XBrushes.Black, xPosPUnit, yPosLastItem);
                gfx.DrawString((m.cantidad * m.precio).ToString("#0.00"), font, XBrushes.Black, xPosImporte, yPosLastItem);
                i++;
            });

            int totalTextWidth = xPosImporte - xPosPUnit;
            int totalWidth = Convert.ToInt32(page.Width - marginRight) - xPosImporte + 1;
            //drawBox(gfx, xPosPUnit, yPosLastItem + 9, totalTextWidth, 20);
            int yPosTotalesBox = yPosLastItem + 9;
            drawBox(gfx, xPosImporte - 1, yPosTotalesBox, totalWidth, 15);
            yPosTotalesBox = yPosTotalesBox + 15;
            drawBox(gfx, xPosImporte - 1, yPosTotalesBox, totalWidth, 15);
            yPosTotalesBox = yPosTotalesBox + 15;
            drawBox(gfx, xPosImporte - 1, yPosTotalesBox, totalWidth, 15);

            int yPosTotales = yPosLastItem + 20;

            String intPart = venta.monto_total.ToString().Split('.')[0];

            String totalString = Convert.ToInt32(intPart).ToWords().ToUpper();
            var decimalPart = (int)(((decimal)venta.monto_total % 1) * 100);

            gfx.DrawString("SubTotal", font, XBrushes.Black, xPosPUnit, yPosTotales);
            gfx.DrawString(venta.monto_subtotal.ToString("#0.00"), font, XBrushes.Black, xPosImporte + 5, yPosTotales);
            yPosTotales = yPosTotales + 15;
            gfx.DrawString("IGV", font, XBrushes.Black, xPosPUnit, yPosTotales);
            gfx.DrawString(venta.monto_igv.ToString("#0.00"), font, XBrushes.Black, xPosImporte + 5, yPosTotales);
            yPosTotales = yPosTotales + 15;
            gfx.DrawString("DESCUENTO", font, XBrushes.Black, xPosPUnit, yPosTotales);
            gfx.DrawString(venta.monto_descuento.ToString("#0.00"), font, XBrushes.Black, xPosImporte + 5, yPosTotales);
            yPosTotales = yPosTotales + 15;
            gfx.DrawString("TOTAL", font, XBrushes.Black, xPosPUnit, yPosTotales);
            gfx.DrawString(venta.monto_total.ToString("#0.00"), font, XBrushes.Black, xPosImporte + 5, yPosTotales);
            yPosTotales = yPosTotales + 15;
            gfx.DrawString("Son " + totalString + " Y " + decimalPart.ToString().PadLeft(2, '0') + "/100 " + ((venta.moneda == "PEN") ? "Soles" : "Dólares Americanos"), font, XBrushes.Black, marginLeft, yPosTotales);

            int yPosNota = yPosTotales + 100;
            gfx.DrawString("OFERTA VALIDA POR 15 DÍAS", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("SOLO PAGO POR TRANSFERENCIA BANCARIA", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("RECOGER CON BAUCHER DE DEPOSITO", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("INVERSIONES GUTIERREZ Y DOMINGUEZ EIRL", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("RUC: 20512225048 - DANIEL PORTOCARRERO 376 URB. LOS LAURELES - CHORRILLOS", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("CUENTA BBVA", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("SOLES:   0011-0117-0100097865   INTERBANCARIO SOLES:   011-117-000100097865-98", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("DOLARES: 0011-0117-01-00095641  INTERBANCARIO DOLARES: 011-117-000100095641-95", fontNota, XBrushes.Black, marginLeft, yPosNota);


            yPosNota = yPosNota + 40;
            gfx.DrawString("NOTA IMPORTANTE DE INSTALACIÓN: OSMOSISPERU NO SE HACE RESPONSABLE POR DESPERFECTOS", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("PRODUCIDO POR ACCIONES AJENAS A NUESTRA INSTALACIÓN COMO POR EJEMPLO, TUBERIAS ANTIGUAS,", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("TUBOS DE ABASTO VIEJOS, O DESPERFECTOS EN SUS DESAGÜES, ASI TAMBIÉN  NO NOS HACEMOS", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("RESPONSABLES POR ALGUNA MODIFICACIÓN QUE SE HAYA REALIZADO AL MOMENTO DE INSTALARLO.", fontNota, XBrushes.Black, marginLeft, yPosNota);
            /*yPosNota = yPosNota + 15;
            gfx.DrawString("DEBE EXISTIR UN PUNTO DE CORRIENTE EN LOS MUEBLES BAJOS A NO MAS DE 2 MT.", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("SI ESTA A MAS, SE COTIZARÁ 20 SOLES POR METRO O DE LO CONTRARIO DEBERÁ REALIZARLO", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("CON SU ELECTRICISTA. EN ESTE CASO EL TÉCNICO EBE DEJAR INSTALADO Y PROBADO  CON UNA", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("EXTENCIÓN QUE USTED TENGA.", fontNota, XBrushes.Black, marginLeft, yPosNota);*/

            yPosNota = yPosNota + 30;
            gfx.DrawString("SI NO ESTUVIERA CONFORME CON EL EQUIPO TIENE DENTRO DE LOS 07 DÍAS NATURALES PARA", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("REALIZAR LA DEVOLUCIÓN DEL EQUIPO DEBIDAMENTE EMBALADO Y CON SU RESPECTIVA CAJA", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("PREVIA REVISIÓN DEL MISMO. SI TODO ESTA CONFORME PASAREMOS A REALIZAR LA DEVOLUCIÓN", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("DEL COSTO DEL EQUIPO, MAS NO DE LA INSTALACIÓN NI DE LOS FILTROS, PUES YA ESTAN USADOS", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("Y SE TIENEN QUE DESHECHAR, SE CONSIDERA COMO PÉRDIDA. EL COSTO DE LOS FILTROS", fontNota, XBrushes.Black, marginLeft, yPosNota);
            /*yPosNota = yPosNota + 15;
            gfx.DrawString("ES $50.00 DÓLARES AMERICANOS QUE SE DESCONTARAN DEL COSTO DEL EQUIPO.", fontNota, XBrushes.Black, marginLeft, yPosNota);*/

            /*yPosNota = yPosNota + 30;
            gfx.DrawString("COSTO DEL EQUIPO $250 DÓLARES AMERICANOS.", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("COSTO DE INSTALACIÓN $50 DÓLARES AMERICANOS DENTRO DE LIMA METROPOLITANA.", fontNota, XBrushes.Black, marginLeft, yPosNota);*/


            String filename = "invoices\\boleta_" + venta.nro_doc + ".pdf";
            document.Save(filename);
            Process.Start(filename);
        }

        public void createFactura(Ent_Configuracion ent_configuracion, Ent_Venta venta)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            //XImage image = XImage.FromFile(logo);
            //gfx.DrawImage(image, 0, marginTop, 256, 80);

            XFont font = new XFont(fontName, 10);
            XFont fontBox = new XFont(fontName, 15);
            XFont fontNota = new XFont(fontName, 7);

            int yPosHeader1 = marginTop + 20;
            gfx.DrawString(ent_configuracion.RAZON_SOCIAL, font, XBrushes.Black, marginLeft, yPosHeader1);
            yPosHeader1 = yPosHeader1 + 15;
            gfx.DrawString(ent_configuracion.DIRECCION, font, XBrushes.Black, marginLeft, yPosHeader1);
            yPosHeader1 = yPosHeader1 + 15;
            gfx.DrawString("Cel. " + ent_configuracion.TELEFONO, font, XBrushes.Black, marginLeft, yPosHeader1);
            yPosHeader1 = yPosHeader1 + 15;
            gfx.DrawString("serviciotecnico@osmosisperu.com / www.osmosisperu.com", font, XBrushes.Black, marginLeft, yPosHeader1);

            int yPosHeader2 = marginTop;
            drawBox(gfx, Convert.ToInt32(page.Width / 1.5), marginTop, Convert.ToInt32(page.Width / 2.9 - marginRight * 2), 80);
            yPosHeader2 = yPosHeader2 + 20;
            gfx.DrawString("R.U.C. " + ent_configuracion.RUC, fontBox, XBrushes.Black, Convert.ToInt32(page.Width / 1.5) + 15, yPosHeader2);
            gfx.DrawRectangle(XBrushes.Black, Convert.ToInt32(page.Width / 1.5), 40, Convert.ToInt32(page.Width / 2.9 - marginRight * 2), 20);
            yPosHeader2 = yPosHeader2 + 25;
            gfx.DrawString("FACTURA", fontBox, XBrushes.White, Convert.ToInt32(page.Width / 1.5) + 55, yPosHeader2);
            yPosHeader2 = yPosHeader2 + 25;
            gfx.DrawString(venta.nro_doc_str, fontBox, XBrushes.Black, Convert.ToInt32(page.Width / 1.5) + 35, yPosHeader2);

            int yPosCustomerDetails = yPosHeader2 + 40;
            gfx.DrawString("Lima, " + DateTime.Now.ToString("d 'de' MMMM 'del' yyyy"), font, XBrushes.Black, marginLeft, yPosCustomerDetails);
            yPosCustomerDetails = yPosCustomerDetails + 20;
            gfx.DrawString("Cliente: " + venta.cliente, font, XBrushes.Black, marginLeft, yPosCustomerDetails);
            yPosCustomerDetails = yPosCustomerDetails + 20;
            gfx.DrawString("Dirección: " + venta.direccion, font, XBrushes.Black, marginLeft, yPosCustomerDetails);
            gfx.DrawString("RUC: " + venta.cliente_doc, font, XBrushes.Black, page.Width / 1.35, yPosCustomerDetails);

            int totalItems = venta.lstProductos.Count;

            int yPosBoxItems = yPosCustomerDetails + 25;
            int yPosBoxTitle = yPosBoxItems + 15;
            int boxHeight = yPosBoxTitle + 20 * totalItems - yPosBoxItems + 10;

            //ITEMS BOX
            drawBox(gfx, marginLeft, yPosBoxItems, Convert.ToInt32(page.Width - marginRight * 2), boxHeight);

            //TITLE BOX
            drawBox(gfx, marginLeft, yPosBoxItems, Convert.ToInt32(page.Width - marginRight * 2), 20);

            int xPosCant = marginLeft + 10;
            int xPosDesc = marginLeft + 60;
            int xPosPUnit = Convert.ToInt32(page.Width - 150);
            int xPosImporte = Convert.ToInt32(page.Width - 80);

            gfx.DrawString("CANT.", font, XBrushes.Black, xPosCant, yPosBoxTitle);
            gfx.DrawString("DESCRIPCIÓN", font, XBrushes.Black, xPosDesc, yPosBoxTitle);
            gfx.DrawString("P. UNIT", font, XBrushes.Black, xPosPUnit, yPosBoxTitle);
            gfx.DrawString("IMPORTE", font, XBrushes.Black, xPosImporte, yPosBoxTitle);

            int yPosBoxTitleWMargin = yPosBoxTitle + 20;
            int yPosLastItem = 0;
            int i = 0;

            venta.lstProductos.ForEach(delegate (Ent_Productos m) {
                yPosLastItem = yPosBoxTitleWMargin + 20 * i;
                gfx.DrawString(Convert.ToString(m.cantidad), font, XBrushes.Black, xPosCant, yPosLastItem);
                gfx.DrawString(m.nombre, font, XBrushes.Black, xPosDesc, yPosLastItem);
                gfx.DrawString(m.precio.ToString("#0.00"), font, XBrushes.Black, xPosPUnit, yPosLastItem);
                gfx.DrawString((m.cantidad * m.precio).ToString("#0.00"), font, XBrushes.Black, xPosImporte, yPosLastItem);
                i++;
            });

            int totalTextWidth = xPosImporte - xPosPUnit;
            int totalWidth = Convert.ToInt32(page.Width - marginRight) - xPosImporte + 1;
            //drawBox(gfx, xPosPUnit, yPosLastItem + 9, totalTextWidth, 20);
            int yPosTotalesBox = yPosLastItem + 9;
            drawBox(gfx, xPosImporte - 1, yPosTotalesBox, totalWidth, 15);
            yPosTotalesBox = yPosTotalesBox + 15;
            drawBox(gfx, xPosImporte - 1, yPosTotalesBox, totalWidth, 15);
            yPosTotalesBox = yPosTotalesBox + 15;
            drawBox(gfx, xPosImporte - 1, yPosTotalesBox, totalWidth, 15);

            String intPart = venta.monto_total.ToString().Split('.')[0];

            String totalString = Convert.ToInt32(intPart).ToWords().ToUpper();
            var decimalPart = (int)(((decimal)venta.monto_total % 1) * 100);

            int yPosTotales = yPosLastItem + 20;
            gfx.DrawString("SubTotal", font, XBrushes.Black, xPosPUnit, yPosTotales);
            gfx.DrawString(venta.monto_subtotal.ToString("#0.00"), font, XBrushes.Black, xPosImporte + 5, yPosTotales);
            yPosTotales = yPosTotales + 15;
            gfx.DrawString("IGV", font, XBrushes.Black, xPosPUnit, yPosTotales);
            gfx.DrawString(venta.monto_igv.ToString("#0.00"), font, XBrushes.Black, xPosImporte + 5, yPosTotales);
            yPosTotales = yPosTotales + 15;
            gfx.DrawString("DESCUENTO", font, XBrushes.Black, xPosPUnit, yPosTotales);
            gfx.DrawString(venta.monto_descuento.ToString("#0.00"), font, XBrushes.Black, xPosImporte + 5, yPosTotales);
            yPosTotales = yPosTotales + 15;
            gfx.DrawString("TOTAL", font, XBrushes.Black, xPosPUnit, yPosTotales);
            gfx.DrawString(venta.monto_total.ToString("#0.00"), font, XBrushes.Black, xPosImporte + 5, yPosTotales);
            yPosTotales = yPosTotales + 15;
            gfx.DrawString("Son " + totalString + " Y " + decimalPart.ToString().PadLeft(2, '0') + "/100 " + ((venta.moneda == "PEN") ? "Soles" : "Dólares Americanos"), font, XBrushes.Black, marginLeft, yPosTotales);


            int yPosNota = yPosTotales + 100;
            gfx.DrawString("OFERTA VALIDA POR 15 DÍAS", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("SOLO PAGO POR TRANSFERENCIA BANCARIA", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("RECOGER CON BAUCHER DE DEPOSITO", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("INVERSIONES GUTIERREZ Y DOMINGUEZ EIRL", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("RUC: 20512225048 - DANIEL PORTOCARRERO 376 URB. LOS LAURELES - CHORRILLOS", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("CUENTA BBVA", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("SOLES:   0011-0117-0100097865   INTERBANCARIO SOLES:   011-117-000100097865-98", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("DOLARES: 0011-0117-01-00095641  INTERBANCARIO DOLARES: 011-117-000100095641-95", fontNota, XBrushes.Black, marginLeft, yPosNota);


            yPosNota = yPosNota + 40;
            gfx.DrawString("NOTA IMPORTANTE DE INSTALACIÓN: OSMOSISPERU NO SE HACE RESPONSABLE POR DESPERFECTOS", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("PRODUCIDO POR ACCIONES AJENAS A NUESTRA INSTALACIÓN COMO POR EJEMPLO, TUBERIAS ANTIGUAS,", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("TUBOS DE ABASTO VIEJOS, O DESPERFECTOS EN SUS DESAGÜES, ASI TAMBIÉN  NO NOS HACEMOS", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("RESPONSABLES POR ALGUNA MODIFICACIÓN QUE SE HAYA REALIZADO AL MOMENTO DE INSTALARLO.", fontNota, XBrushes.Black, marginLeft, yPosNota);
            /*yPosNota = yPosNota + 15;
            gfx.DrawString("DEBE EXISTIR UN PUNTO DE CORRIENTE EN LOS MUEBLES BAJOS A NO MAS DE 2 MT.", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("SI ESTA A MAS, SE COTIZARÁ 20 SOLES POR METRO O DE LO CONTRARIO DEBERÁ REALIZARLO", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("CON SU ELECTRICISTA. EN ESTE CASO EL TÉCNICO EBE DEJAR INSTALADO Y PROBADO  CON UNA", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("EXTENCIÓN QUE USTED TENGA.", fontNota, XBrushes.Black, marginLeft, yPosNota);*/

            yPosNota = yPosNota + 30;
            gfx.DrawString("SI NO ESTUVIERA CONFORME CON EL EQUIPO TIENE DENTRO DE LOS 07 DÍAS NATURALES PARA", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("REALIZAR LA DEVOLUCIÓN DEL EQUIPO DEBIDAMENTE EMBALADO Y CON SU RESPECTIVA CAJA", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("PREVIA REVISIÓN DEL MISMO. SI TODO ESTA CONFORME PASAREMOS A REALIZAR LA DEVOLUCIÓN", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("DEL COSTO DEL EQUIPO, MAS NO DE LA INSTALACIÓN NI DE LOS FILTROS, PUES YA ESTAN USADOS", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("Y SE TIENEN QUE DESHECHAR, SE CONSIDERA COMO PÉRDIDA. EL COSTO DE LOS FILTROS", fontNota, XBrushes.Black, marginLeft, yPosNota);
            /*yPosNota = yPosNota + 15;
            gfx.DrawString("ES $50.00 DÓLARES AMERICANOS QUE SE DESCONTARAN DEL COSTO DEL EQUIPO.", fontNota, XBrushes.Black, marginLeft, yPosNota);

            yPosNota = yPosNota + 30;
            gfx.DrawString("COSTO DEL EQUIPO $250 DÓLARES AMERICANOS.", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("COSTO DE INSTALACIÓN $50 DÓLARES AMERICANOS DENTRO DE LIMA METROPOLITANA.", fontNota, XBrushes.Black, marginLeft, yPosNota);*/


            String filename = "invoices\\factura" + venta.nro_doc + ".pdf";
            document.Save(filename);
            Process.Start(filename);
        }

        public void createCotizacion(Ent_Configuracion ent_configuracion, Ent_Venta venta)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            //XImage image = XImage.FromFile(logo);
            //gfx.DrawImage(image, 0, marginTop, 256, 80);

            XFont font = new XFont(fontName, 10);
            XFont fontBox = new XFont(fontName, 15);
            XFont fontNota = new XFont(fontName, 7);

            int yPosHeader1 = marginTop + 20;
            gfx.DrawString(ent_configuracion.RAZON_SOCIAL, font, XBrushes.Black, marginLeft, yPosHeader1);
            yPosHeader1 = yPosHeader1 + 15;
            gfx.DrawString(ent_configuracion.DIRECCION, font, XBrushes.Black, marginLeft, yPosHeader1);
            yPosHeader1 = yPosHeader1 + 15;
            gfx.DrawString("Cel. " + ent_configuracion.TELEFONO, font, XBrushes.Black, marginLeft, yPosHeader1);
            yPosHeader1 = yPosHeader1 + 15;
            gfx.DrawString("serviciotecnico@osmosisperu.com / www.osmosisperu.com", font, XBrushes.Black, marginLeft, yPosHeader1);

            int yPosHeader2 = marginTop;
            drawBox(gfx, Convert.ToInt32(page.Width / 1.5), marginTop, Convert.ToInt32(page.Width / 2.9 - marginRight * 2), 80);
            yPosHeader2 = yPosHeader2 + 20;
            gfx.DrawString("R.U.C. " + ent_configuracion.RUC, fontBox, XBrushes.Black, Convert.ToInt32(page.Width / 1.5) + 15, yPosHeader2);
            gfx.DrawRectangle(XBrushes.Black, Convert.ToInt32(page.Width / 1.5), 40, Convert.ToInt32(page.Width / 2.9 - marginRight * 2), 20);
            yPosHeader2 = yPosHeader2 + 25;
            gfx.DrawString("COTIZACIÓN", fontBox, XBrushes.White, Convert.ToInt32(page.Width / 1.5) + 45, yPosHeader2);
            yPosHeader2 = yPosHeader2 + 25;
            gfx.DrawString("001-" + venta.id_cab.ToString().PadLeft(6, '0'), fontBox, XBrushes.Black, Convert.ToInt32(page.Width / 1.5) + 45, yPosHeader2);

            int yPosCustomerDetails = yPosHeader2 + 40;
            gfx.DrawString("Lima, " + DateTime.Now.ToString("d 'de' MMMM 'del' yyyy"), font, XBrushes.Black, marginLeft, yPosCustomerDetails);
            yPosCustomerDetails = yPosCustomerDetails + 20;
            gfx.DrawString("Cliente: " + venta.cliente, font, XBrushes.Black, marginLeft, yPosCustomerDetails);
            yPosCustomerDetails = yPosCustomerDetails + 20;
            gfx.DrawString("Dirección: " + venta.direccion, font, XBrushes.Black, marginLeft, yPosCustomerDetails);
            gfx.DrawString("DNI/RUC: " + venta.cliente_doc, font, XBrushes.Black, page.Width / 1.35, yPosCustomerDetails);
            if (venta.tipo_cotizacion.Equals("AL"))
            {
                yPosCustomerDetails = yPosCustomerDetails + 20;
                gfx.DrawString("Días Alquiler: " + venta.dias_alquiler, font, XBrushes.Black, marginLeft, yPosCustomerDetails);
            }

            int totalItems = venta.lstProductos.Count;

            int yPosBoxItems = yPosCustomerDetails + 25;
            int yPosBoxTitle = yPosBoxItems + 15;
            int boxHeight = yPosBoxTitle + 20 * totalItems - yPosBoxItems + 10;

            //ITEMS BOX
            drawBox(gfx, marginLeft, yPosBoxItems, Convert.ToInt32(page.Width - marginRight * 2), boxHeight);

            //TITLE BOX
            drawBox(gfx, marginLeft, yPosBoxItems, Convert.ToInt32(page.Width - marginRight * 2), 20);

            int xPosCant = marginLeft + 10;
            int xPosDesc = marginLeft + 60;
            int xPosPUnit = Convert.ToInt32(page.Width - 150);
            int xPosImporte = Convert.ToInt32(page.Width - 80);

            gfx.DrawString("CANT.", font, XBrushes.Black, xPosCant, yPosBoxTitle);
            gfx.DrawString("DESCRIPCIÓN", font, XBrushes.Black, xPosDesc, yPosBoxTitle);
            gfx.DrawString("P. UNIT", font, XBrushes.Black, xPosPUnit, yPosBoxTitle);
            gfx.DrawString("IMPORTE", font, XBrushes.Black, xPosImporte, yPosBoxTitle);

            int yPosBoxTitleWMargin = yPosBoxTitle + 20;
            int yPosLastItem = 0;
            int i = 0;

            venta.lstProductos.ForEach(delegate (Ent_Productos m) {
                yPosLastItem = yPosBoxTitleWMargin + 20 * i;
                gfx.DrawString(Convert.ToString(m.cantidad), font, XBrushes.Black, xPosCant, yPosLastItem);
                gfx.DrawString(m.nombre, font, XBrushes.Black, xPosDesc, yPosLastItem);
                gfx.DrawString(m.precio.ToString("#0.00"), font, XBrushes.Black, xPosPUnit, yPosLastItem);
                gfx.DrawString((m.cantidad * m.precio).ToString("#0.00"), font, XBrushes.Black, xPosImporte, yPosLastItem);
                i++;
            });

            int totalTextWidth = xPosImporte - xPosPUnit;
            int totalWidth = Convert.ToInt32(page.Width - marginRight) - xPosImporte + 1;
            //drawBox(gfx, xPosPUnit, yPosLastItem + 9, totalTextWidth, 20);
            int yPosTotalesBox = yPosLastItem + 9;
            drawBox(gfx, xPosImporte - 1, yPosTotalesBox, totalWidth, 15);
            yPosTotalesBox = yPosTotalesBox + 15;
            drawBox(gfx, xPosImporte - 1, yPosTotalesBox, totalWidth, 15);
            yPosTotalesBox = yPosTotalesBox + 15;
            drawBox(gfx, xPosImporte - 1, yPosTotalesBox, totalWidth, 15);

            String intPart = venta.monto_total.ToString().Split('.')[0];

            String totalString = Convert.ToInt32(intPart).ToWords().ToUpper();
            var decimalPart = (int)(((decimal)venta.monto_total % 1) * 100);

            int yPosTotales = yPosLastItem + 20;
            gfx.DrawString("SubTotal", font, XBrushes.Black, xPosPUnit, yPosTotales);
            gfx.DrawString(venta.monto_subtotal.ToString("#0.00"), font, XBrushes.Black, xPosImporte + 5, yPosTotales);
            yPosTotales = yPosTotales + 15;
            gfx.DrawString("IGV", font, XBrushes.Black, xPosPUnit, yPosTotales);
            gfx.DrawString(venta.monto_igv.ToString("#0.00"), font, XBrushes.Black, xPosImporte + 5, yPosTotales);
            yPosTotales = yPosTotales + 15;
            gfx.DrawString("TOTAL", font, XBrushes.Black, xPosPUnit, yPosTotales);
            gfx.DrawString(venta.monto_total.ToString("#0.00"), font, XBrushes.Black, xPosImporte + 5, yPosTotales);
            yPosTotales = yPosTotales + 15;
            gfx.DrawString("Son " + totalString + " Y " + decimalPart.ToString().PadLeft(2, '0') + "/100 " + ((venta.moneda == "PEN") ? "Soles" : "Dólares Americanos"), font, XBrushes.Black, marginLeft, yPosTotales);

            int yPosNota = yPosTotales + 100;
            gfx.DrawString(venta.observacion, fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("SOLO PAGO POR TRANSFERENCIA BANCARIA", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("RECOGER CON BAUCHER DE DEPOSITO", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("INVERSIONES GUTIERREZ Y DOMINGUEZ EIRL", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("RUC: 20512225048 - DANIEL PORTOCARRERO 376 URB. LOS LAURELES - CHORRILLOS", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("CUENTA BBVA", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("SOLES:   0011-0117-0100097865   INTERBANCARIO SOLES:   011-117-000100097865-98", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("DOLARES: 0011-0117-01-00095641  INTERBANCARIO DOLARES: 011-117-000100095641-95", fontNota, XBrushes.Black, marginLeft, yPosNota);


            yPosNota = yPosNota + 40;
            gfx.DrawString("NOTA IMPORTANTE DE INSTALACIÓN: OSMOSISPERU NO SE HACE RESPONSABLE POR DESPERFECTOS", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("PRODUCIDO POR ACCIONES AJENAS A NUESTRA INSTALACIÓN COMO POR EJEMPLO, TUBERIAS ANTIGUAS,", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("TUBOS DE ABASTO VIEJOS, O DESPERFECTOS EN SUS DESAGÜES, ASI TAMBIÉN  NO NOS HACEMOS", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("RESPONSABLES POR ALGUNA MODIFICACIÓN QUE SE HAYA REALIZADO AL MOMENTO DE INSTALARLO.", fontNota, XBrushes.Black, marginLeft, yPosNota);
            /*yPosNota = yPosNota + 15;
            gfx.DrawString("DEBE EXISTIR UN PUNTO DE CORRIENTE EN LOS MUEBLES BAJOS A NO MAS DE 2 MT.", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("SI ESTA A MAS, SE COTIZARÁ 20 SOLES POR METRO O DE LO CONTRARIO DEBERÁ REALIZARLO", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("CON SU ELECTRICISTA. EN ESTE CASO EL TÉCNICO EBE DEJAR INSTALADO Y PROBADO  CON UNA", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("EXTENCIÓN QUE USTED TENGA.", fontNota, XBrushes.Black, marginLeft, yPosNota);*/

            yPosNota = yPosNota + 30;
            gfx.DrawString("SI NO ESTUVIERA CONFORME CON EL EQUIPO TIENE DENTRO DE LOS 07 DÍAS NATURALES PARA", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("REALIZAR LA DEVOLUCIÓN DEL EQUIPO DEBIDAMENTE EMBALADO Y CON SU RESPECTIVA CAJA", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("PREVIA REVISIÓN DEL MISMO. SI TODO ESTA CONFORME PASAREMOS A REALIZAR LA DEVOLUCIÓN", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("DEL COSTO DEL EQUIPO, MAS NO DE LA INSTALACIÓN NI DE LOS FILTROS, PUES YA ESTAN USADOS", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("Y SE TIENEN QUE DESHECHAR, SE CONSIDERA COMO PÉRDIDA. EL COSTO DE LOS FILTROS", fontNota, XBrushes.Black, marginLeft, yPosNota);
            /*yPosNota = yPosNota + 15;
            gfx.DrawString("ES $50.00 DÓLARES AMERICANOS QUE SE DESCONTARAN DEL COSTO DEL EQUIPO.", fontNota, XBrushes.Black, marginLeft, yPosNota);

            yPosNota = yPosNota + 30;
            gfx.DrawString("COSTO DEL EQUIPO $250 DÓLARES AMERICANOS.", fontNota, XBrushes.Black, marginLeft, yPosNota);
            yPosNota = yPosNota + 15;
            gfx.DrawString("COSTO DE INSTALACIÓN $50 DÓLARES AMERICANOS DENTRO DE LIMA METROPOLITANA.", fontNota, XBrushes.Black, marginLeft, yPosNota);*/


            String filename = "invoices\\cotizacion_" + venta.id_cab + ".pdf";
            document.Save(filename);
            Process.Start(filename);
        }

        private void drawBox(XGraphics gfx, int x, int y, int w, int h)
        {
            gfx.DrawRectangle(XBrushes.Black, x, y, w, h);
            gfx.DrawRectangle(XBrushes.White, x + 1, y + 1, w - 2, h - 2);
        }
    }
}
