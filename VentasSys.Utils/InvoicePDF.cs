using System;
using System.Diagnostics;
using System.IO;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using VentasSys.EL;

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
            gfx.DrawString("Cel." + ent_configuracion.TELEFONO, font, XBrushes.Black, marginLeft, yPosHeader1);
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

            int yPosHeader1 = marginTop + 20;
            gfx.DrawString(ent_configuracion.RAZON_SOCIAL, font, XBrushes.Black, marginLeft, yPosHeader1);
            yPosHeader1 = yPosHeader1 + 15;
            gfx.DrawString(ent_configuracion.DIRECCION, font, XBrushes.Black, marginLeft, yPosHeader1);
            yPosHeader1 = yPosHeader1 + 15;
            gfx.DrawString("Cel." + ent_configuracion.TELEFONO, font, XBrushes.Black, marginLeft, yPosHeader1);
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
            gfx.DrawString("SubTotal", font, XBrushes.Black, xPosPUnit, yPosTotales);
            gfx.DrawString(venta.monto_subtotal.ToString("#0.00"), font, XBrushes.Black, xPosImporte + 5, yPosTotales);
            yPosTotales = yPosTotales + 15;
            gfx.DrawString("IGV", font, XBrushes.Black, xPosPUnit, yPosTotales);
            gfx.DrawString(venta.monto_igv.ToString("#0.00"), font, XBrushes.Black, xPosImporte + 5, yPosTotales);
            yPosTotales = yPosTotales + 15;
            gfx.DrawString("TOTAL", font, XBrushes.Black, xPosPUnit, yPosTotales);
            gfx.DrawString(venta.monto_total.ToString("#0.00"), font, XBrushes.Black, xPosImporte + 5, yPosTotales);


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

            int yPosHeader1 = marginTop + 20;
            gfx.DrawString(ent_configuracion.RAZON_SOCIAL, font, XBrushes.Black, marginLeft, yPosHeader1);
            yPosHeader1 = yPosHeader1 + 15;
            gfx.DrawString(ent_configuracion.DIRECCION, font, XBrushes.Black, marginLeft, yPosHeader1);
            yPosHeader1 = yPosHeader1 + 15;
            gfx.DrawString("Cel." + ent_configuracion.TELEFONO, font, XBrushes.Black, marginLeft, yPosHeader1);
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

            int yPosTotales = yPosLastItem + 20;
            gfx.DrawString("SubTotal", font, XBrushes.Black, xPosPUnit, yPosTotales);
            gfx.DrawString(venta.monto_subtotal.ToString("#0.00"), font, XBrushes.Black, xPosImporte + 5, yPosTotales);
            yPosTotales = yPosTotales + 15;
            gfx.DrawString("IGV", font, XBrushes.Black, xPosPUnit, yPosTotales);
            gfx.DrawString(venta.monto_igv.ToString("#0.00"), font, XBrushes.Black, xPosImporte + 5, yPosTotales);
            yPosTotales = yPosTotales + 15;
            gfx.DrawString("TOTAL", font, XBrushes.Black, xPosPUnit, yPosTotales);
            gfx.DrawString(venta.monto_total.ToString("#0.00"), font, XBrushes.Black, xPosImporte + 5, yPosTotales);


            String filename = "invoices\\factura" + venta.nro_doc + ".pdf";
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
