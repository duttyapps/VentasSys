using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentasSys.BL;
using VentasSys.EL;
using VentasSys.Utils;

namespace VentasSys
{
    public partial class frmConsultaVentas : Form
    {
        private string tienda { get; set; }
        public Ent_Venta ent_venta { get; set; }
        private bool auto_close { get; set; }
        private Ent_Configuracion ent_configuracion;

        public frmConsultaVentas(string _tienda, bool _auto_close = false, bool doc_credito = false)
        {
            ent_configuracion = new Ent_Configuracion();
            ent_configuracion = BL_Configuracion.getConfiguracion();
            tienda = _tienda;
            auto_close = _auto_close;
            InitializeComponent();
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            fillComboEstados();
            fillTipoVenta();
            fillFormaPago();
            if (doc_credito) {
                cboFormaPago.SelectedValue = "CR";
                cboFormaPago.Enabled = false;
            }
            fillVentas();
        }

        private void fillVentas()
        {
            dgvVentas.AutoGenerateColumns = false;

            if (dgvVentas.Rows.Count > 0)
            {
                dgvVentas.Rows.Clear();
            }

            Ent_Venta entity = new Ent_Venta();
            entity.cod_tienda = tienda;
            entity.nro_doc_str = txtNroDoc.Text;
            entity.tipo_venta = cboTipoVenta.SelectedValue.ToString();
            entity.forma_pago = cboFormaPago.SelectedValue.ToString();
            entity.emision = txtFecha.Text;
            entity.anulado = cboEstado.SelectedValue.ToString();

            List<Ent_Venta> lstVentas = BL_Ventas.getConsultaVentas(entity);

            var bindingList = new BindingList<Ent_Venta>(lstVentas);
            var source = new BindingSource(bindingList, null);

            dgvVentas.DataSource = source;

            txtTotal.Text = dgvVentas.Rows.Count.ToString();
        }

        private void fillComboEstados()
        {
            List<Object> items = new List<Object>();
            items.Add(new { id = String.Empty, desc = "Todos" });
            items.Add(new { id = "0", desc = "Activo" });
            items.Add(new { id = "1", desc = "Inactivo" });

            cboEstado.DataSource = items;
            cboEstado.ValueMember = "id";
            cboEstado.DisplayMember = "desc";
        }

        private void fillTipoVenta()
        {
            List<Ent_TipoVentas> items = new List<Ent_TipoVentas>();

            var tipo_venta = BL_Ventas.getTipoVenta(String.Empty);

            items.Add(new Ent_TipoVentas { id = "", descripcion = "Todos" });

            items.AddRange(tipo_venta);

            cboTipoVenta.DataSource = items;
            cboTipoVenta.ValueMember = "codigo";
            cboTipoVenta.DisplayMember = "descripcion";
        }

        public void fillFormaPago()
        {
            List<Ent_FormaPago> items = new List<Ent_FormaPago>();

            var formapago = BL_Ventas.getFormaPago();

            items.Add(new Ent_FormaPago { codigo = String.Empty, descripcion = "Todos" });

            items.AddRange(formapago);

            cboFormaPago.DataSource = items;
            cboFormaPago.ValueMember = "codigo";
            cboFormaPago.DisplayMember = "descripcion";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fillVentas();
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == 9)
            {
                string id = dgvVentas.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                frmDetalleVenta frm = new frmDetalleVenta(id);
                frm.ShowDialog();
            }

            if (e.ColumnIndex == 11)
            {
                string nro_doc = dgvVentas.Rows[e.RowIndex].Cells["DOC"].Value.ToString();
                string tipo = dgvVentas.Rows[e.RowIndex].Cells["TIPO_VENTA"].Value.ToString();

                InvoicePDF pdf = new InvoicePDF();

                ent_venta = new Ent_Venta();
                ent_venta.nro_doc_str = dgvVentas.Rows[e.RowIndex].Cells["NRO_DOC"].Value.ToString();
                ent_venta.tipo_venta = dgvVentas.Rows[e.RowIndex].Cells["TIPO_VENTA"].Value.ToString();
                ent_venta.emision = dgvVentas.Rows[e.RowIndex].Cells["FECHA"].Value.ToString();
                ent_venta.cliente = dgvVentas.Rows[e.RowIndex].Cells["NOMBRES"].Value.ToString();
                ent_venta.cliente_doc = dgvVentas.Rows[e.RowIndex].Cells["DNI"].Value.ToString();
                ent_venta.direccion = dgvVentas.Rows[e.RowIndex].Cells["DIRECCION"].Value.ToString();
                ent_venta.monto_total = Convert.ToDouble(dgvVentas.Rows[e.RowIndex].Cells["TOTAL"].Value.ToString());
                ent_venta.monto_subtotal = Convert.ToDouble(ent_venta.monto_total / (ent_configuracion.IGV + 1));
                ent_venta.monto_igv = (ent_venta.monto_total - Convert.ToDouble(ent_venta.monto_subtotal));
                ent_venta.monto_descuento = Convert.ToDouble(dgvVentas.Rows[e.RowIndex].Cells["DESCUENTO"].Value.ToString()); ;
                ent_venta.nro_doc = Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Cells["DOC"].Value.ToString());
                ent_venta.moneda = dgvVentas.Rows[e.RowIndex].Cells["MONEDA"].Value.ToString();

                ent_venta.lstProductos = BL_Ventas.getDetalleVenta(nro_doc);

                if (tipo == "BO")
                {
                    pdf.createBoleta(ent_configuracion, ent_venta);
                }
                else
                {
                    pdf.createFactura(ent_configuracion, ent_venta);
                }

                /*String filename = "invoices\\" + (tipo == "BO" ? "boleta" : "factura") + "_" + nro_doc + ".pdf";
                if (File.Exists(filename))
                {
                    Process.Start(filename);
                } else
                {
                    MessageBox.Show((tipo == "BO" ? "Boleta" : "Factura") + " no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/
            }
        }

        private void dgvVentas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                ent_venta = new Ent_Venta();
                ent_venta.nro_doc_str = dgvVentas.Rows[e.RowIndex].Cells["NRO_DOC"].Value.ToString();
                ent_venta.tipo_venta = dgvVentas.Rows[e.RowIndex].Cells["TIPO_VENTA"].Value.ToString();
                ent_venta.emision = dgvVentas.Rows[e.RowIndex].Cells["FECHA"].Value.ToString();

                if(auto_close)
                {
                    this.Close();
                }
            }
        }
    }
}
