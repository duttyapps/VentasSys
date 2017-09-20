using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentasSys.BL;
using VentasSys.EL;

namespace VentasSys
{
    public partial class frmCreditos : Form
    {
        private string cod_tienda { get; set; }
        public frmCreditos(string _cod_tienda)
        {
            InitializeComponent();
            fillTipoVenta();
            cod_tienda = _cod_tienda;
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dgvDetalleVenta.Columns["PRECIO"].DefaultCellStyle.Format = "f";
            dgvDetalleVenta.Columns["IMPORTE"].DefaultCellStyle.Format = "f";
            dgvAbonos.Columns["MONTO"].DefaultCellStyle.Format = "f";
        }

        private void fillTipoVenta()
        {
            List<Ent_TipoVentas> items = new List<Ent_TipoVentas>();

            var tipo_venta = BL_Ventas.getTipoVenta(String.Empty);

            items.AddRange(tipo_venta);

            cboTipoVenta.DataSource = items;
            cboTipoVenta.ValueMember = "codigo";
            cboTipoVenta.DisplayMember = "descripcion";
        }

        private void fillDetalles(string id)
        {
            dgvDetalleVenta.AutoGenerateColumns = false;

            if (dgvDetalleVenta.Rows.Count > 0)
            {
                dgvDetalleVenta.Rows.Clear();
            }

            List<Ent_Productos> lstDetalles = BL_Ventas.getDetalleVenta(id);

            var bindingList = new BindingList<Ent_Productos>(lstDetalles);
            var source = new BindingSource(bindingList, null);

            dgvDetalleVenta.DataSource = source;

        }

        private void fillAbonos(int id, int id_cab)
        {
            dgvAbonos.AutoGenerateColumns = false;

            if (dgvAbonos.Rows.Count > 0)
            {
                dgvAbonos.Rows.Clear();
            }

            Ent_Abonos param = new Ent_Abonos();
            param.id = id;
            param.id_cab = id_cab;

            List<Ent_Abonos> lstAbonos = BL_Ventas.getAbonos(param);

            var bindingList = new BindingList<Ent_Abonos>(lstAbonos);
            var source = new BindingSource(bindingList, null);

            dgvAbonos.DataSource = source;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNroDocumento.Text == String.Empty)
            {
                MessageBox.Show("El número de documento no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroDocumento.Focus();
                return;
            }

            int v_nro_doc = int.Parse(txtNroDocumento.Text.Substring(4,txtNroDocumento.Text.Length - 4));
            string v_tipo_venta = cboTipoVenta.SelectedValue.ToString();
            string v_fecha = txtFecha.Text;
            Ent_Venta res_venta = BL_Ventas.getVentaCredito(v_nro_doc, cod_tienda, v_tipo_venta, v_fecha);

            if (res_venta.nro_doc == 0)
            {
                MessageBox.Show("Documento no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                tbDetalles.Enabled = true;
                lblNroDocumento.Text = res_venta.nro_doc_str;
                lblNroDocumento2.Text = res_venta.nro_doc_str;
                lblTipoVenta.Text = res_venta.tipo_venta_des;
                txtDNI.Text = res_venta.cliente_doc;
                txtCliente.Text = res_venta.cliente;
                lblFecha.Text = res_venta.emision;
                txtEmail.Text = res_venta.email;
                txtTelefono.Text = res_venta.telefono;
                txtDireccion.Text = res_venta.direccion;
                txtTotal.Text = res_venta.monto_total.ToString("#.00");

                if (v_tipo_venta == "FA")
                {
                    lblDNI.Text = "RUC";
                    lblCliente.Text = "Razón Social";
                }
                else
                {
                    lblDNI.Text = "DNI";
                    lblCliente.Text = "Cliente";
                }
            }

            fillDetalles(v_nro_doc.ToString());
            fillAbonos(res_venta.id_cab, res_venta.nro_doc);
        }
    }
}
