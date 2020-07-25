using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using VentasSys.BL;
using VentasSys.EL;
using VentasSys.Utils;

namespace VentasSys
{
    public partial class frmConsultarCotizacion : Form
    {
        private Ent_Configuracion ent_configuracion;
        private string cod_tienda { get; set; }
        private string id_cab { get; set; }
        public List<Ent_Productos> lista_producto { get; set; }
        private List<Ent_Venta> lista_cabecera{ get; set; }
        private Ent_Venta cotizacion;
        private List<Ent_Productos> lstDetalles;
        public string continuar { get; set; }
        public string tipo { get; set; }
        public string numero_doc { get; set; }
        public string nombres { get; set; }
        public string tipo_doc { get; set; }
        public int dias_alquiler { get; set; }

        public frmConsultarCotizacion(string tienda)
        {
            InitializeComponent();
            cod_tienda = tienda;

            ent_configuracion = new Ent_Configuracion();
            ent_configuracion = BL_Configuracion.getConfiguracion();
            cotizacion = new Ent_Venta();

            Dictionary<string, string> lista_tipo = new Dictionary<string, string>();
            lista_tipo.Add("", ":: TODAS ::");
            lista_tipo.Add("CO", "COMPRA");
            lista_tipo.Add("AL", "ALQUILER");
            cboTipo.DataSource = new BindingSource(lista_tipo, null);
            cboTipo.DisplayMember = "Value";
            cboTipo.ValueMember = "Key";

            btnBuscar_Click(new object(), new EventArgs());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            reiniciarCotizacion();
            Ent_Venta ventas = new Ent_Venta();

            if (txtDNI.Text != String.Empty)
            {
                ventas.nro_doc = int.Parse(txtDNI.Text);
            }

            if (cboTipo.SelectedValue == null)
            {
                ventas.tipo_cotizacion = String.Empty;
            }

            if (cboTipo.SelectedValue != null && cboTipo.SelectedValue.ToString() != String.Empty)
            {
                ventas.tipo_cotizacion = cboTipo.SelectedValue.ToString();
            }
            ventas.cod_tienda = cod_tienda;

            List<Ent_Venta> lista_cotizacion = BL_Ventas.getConsultaCotizacion(ventas);

            dgvDocumentos.Rows.Clear();

            foreach (Ent_Venta venta in lista_cotizacion)
            {
                dgvDocumentos.Rows.Add(venta.nro_doc_str, venta.id_cab, venta.tipo_cotizacion, venta.emision, venta.usuario, venta.cliente_doc, venta.cliente,venta.monto_total, venta.dias_alquiler, venta.moneda);
            }
        }
        
        private void dgvDocumentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                showDetallesDoc(e);
            }
        }

        private void showDetallesDoc(DataGridViewCellEventArgs e)
        {
            reiniciarCotizacion();
            string id = dgvDocumentos.Rows[e.RowIndex].Cells["ID_CAB"].Value.ToString();
            id_cab = id;
            fillDetalles(id);
            tipo = dgvDocumentos.Rows[e.RowIndex].Cells["TIPO_VENTA"].Value.ToString();
            lblTipo.Text = dgvDocumentos.Rows[e.RowIndex].Cells["TIPO_VENTA"].Value.ToString() == "CO" ? "Compra" : "Alquiler";
            
            lblFecha.Text = dgvDocumentos.Rows[e.RowIndex].Cells["FECHA"].Value.ToString();
            lblUsuario.Text = dgvDocumentos.Rows[e.RowIndex].Cells["USUARIO"].Value.ToString();
            lblDNI.Text = dgvDocumentos.Rows[e.RowIndex].Cells["DNI"].Value.ToString();
            lblNombre.Text = dgvDocumentos.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
            lblTotal.Text = dgvDocumentos.Rows[e.RowIndex].Cells["MONEDA"].Value.ToString() + " " + String.Format("{0:f2}", dgvDocumentos.Rows[e.RowIndex].Cells["MONTO_TOTAL"].Value);
            gbDetalle.Visible = true;
            btnConfirmar.Enabled = true;

            cotizacion.id_cab = Convert.ToInt32(id_cab);
            cotizacion.cliente = lblNombre.Text;
            cotizacion.cliente_doc = lblDNI.Text;
            Ent_Clientes cliente = BL_Clientes.getCliente(lblDNI.Text);
            cotizacion.direccion = cliente.direccion;
            cotizacion.tipo_cotizacion = tipo;
            cotizacion.dias_alquiler = Convert.ToInt32(dgvDocumentos.Rows[e.RowIndex].Cells["DIAS_ALQUILER"].Value.ToString());
            cotizacion.monto_total = Convert.ToDouble(lblTotal.Text.Split(' ')[1]);
            cotizacion.monto_subtotal = Convert.ToDouble(cotizacion.monto_total / (0.18 + 1));
            cotizacion.monto_igv = (cotizacion.monto_total - Convert.ToDouble(cotizacion.monto_subtotal));
            cotizacion.moneda = dgvDocumentos.Rows[e.RowIndex].Cells["MONEDA"].Value.ToString();
        }

        private void fillDetalles(string id)
        {
            dgvDetalle.AutoGenerateColumns = false;

            if (dgvDetalle.Rows.Count > 0)
            {
                dgvDetalle.Rows.Clear();
            }

            lstDetalles = BL_Ventas.getDetalleCotizacion(id);
            lista_producto = lstDetalles;

            if (lstDetalles != null)
            {
                cotizacion.lstProductos = lstDetalles;
            }

            var bindingList = new BindingList<Ent_Productos>(lstDetalles);
            var source = new BindingSource(bindingList, null);

            dgvDetalle.DataSource = source;

        }

        private void reiniciarCotizacion()
        {
            txtDNI.Text = String.Empty;
            gbDetalle.Visible = false;
            btnConfirmar.Enabled = false;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            continuar = "1";
            numero_doc = lblDNI.Text;
            nombres = lblNombre.Text;
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            InvoicePDF invoicePDF = new InvoicePDF();
            invoicePDF.createCotizacion(ent_configuracion, cotizacion);
 
            /*String filename = "invoices\\cotizacion_" + id_cab + ".pdf";
            if (File.Exists(filename))
            {
                Process.Start(filename);
            }
            else
            {
                MessageBox.Show("Cotización no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Está seguro que desea eliminar la cotización?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (confirm == DialogResult.Yes)
            {
                String result = BL_Ventas.delCotizacion(id_cab);
                if(result.Equals("1"))
                {
                    MessageBox.Show("¡Cotización eliminada!.", "Consulta Cotización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnBuscar_Click(new object(), new EventArgs());
                } else
                {
                    MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
