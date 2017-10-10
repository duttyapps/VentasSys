using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using VentasSys.BL;
using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys
{
    public partial class frmAnularVenta : Form
    {
        private string cod_tienda { get; set; }
        private string usuario { get; set; }
        private string id_cab { get; set; }

        public frmAnularVenta(string _cod_tienda, string _usuario)
        {
            cod_tienda = _cod_tienda;
            usuario = _usuario;
            InitializeComponent();
            fillDocumentos();
            fillTipoVenta();
            dgvDetalle.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns[2].DefaultCellStyle.Format = "f";
            dgvDetalle.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns[3].DefaultCellStyle.Format = "f";
        }

        private void fillDocumentos()
        {
            dgvDocumentos.AutoGenerateColumns = false;

            if (dgvDocumentos.Rows.Count > 0)
            {
                dgvDocumentos.Rows.Clear();
            }

            if (dgvDetalle.Rows.Count > 0)
            {
                dgvDetalle.Rows.Clear();
            }

            Ent_Venta param_venta = new Ent_Venta();
            param_venta.cod_tienda = cod_tienda;

            if (txtNroDocumento.Text != String.Empty)
            {
                param_venta.nro_doc = int.Parse(txtNroDocumento.Text);
            }

            if (cboTipoVenta.SelectedValue == null)
            {
                param_venta.tipo_venta = String.Empty;
            }

            if (cboTipoVenta.SelectedValue != null && cboTipoVenta.SelectedValue.ToString() != String.Empty)
            {
                param_venta.tipo_venta = cboTipoVenta.SelectedValue.ToString();
            }

            List<Ent_Venta> lstVenta = BL_Ventas.getVentas(param_venta);

            var bindingList = new BindingList<Ent_Venta>(lstVenta);
            var source = new BindingSource(bindingList, null);

            dgvDocumentos.DataSource = source;

        }

        private void fillDetalles(string id)
        {
            dgvDetalle.AutoGenerateColumns = false;

            if (dgvDetalle.Rows.Count > 0)
            {
                dgvDetalle.Rows.Clear();
            }

            List<Ent_Productos> lstDetalles = BL_Ventas.getDetalleVenta(id);

            var bindingList = new BindingList<Ent_Productos>(lstDetalles);
            var source = new BindingSource(bindingList, null);

            dgvDetalle.DataSource = source;

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

        private void dgvDocumentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                showDetallesDoc(e);
            }
        }

        private void showDetallesDoc(DataGridViewCellEventArgs e)
        {
            reiniciarAnular();
            string id = dgvDocumentos.Rows[e.RowIndex].Cells["ID_CAB"].Value.ToString();
            id_cab = id;
            fillDetalles(id);
            lblTipoVenta.Text = dgvDocumentos.Rows[e.RowIndex].Cells["TIPO_VENTA_DES"].Value.ToString();

            if(lblTipoVenta.Text == "Factura")
            {
                lbl_DNI.Text = "RUC:";
                lbl_Nombres.Text = "Razón Social:";
            } else
            {
                lbl_DNI.Text = "DNI:";
                lbl_Nombres.Text = "Nombre Cliente:";
            }

            lblFormaPago.Text = dgvDocumentos.Rows[e.RowIndex].Cells["FORMA_PAGO_DES"].Value.ToString();
            lblFecha.Text = dgvDocumentos.Rows[e.RowIndex].Cells["FECHA"].Value.ToString();
            lblUsuario.Text = dgvDocumentos.Rows[e.RowIndex].Cells["USUARIO"].Value.ToString();
            lblDNI.Text = dgvDocumentos.Rows[e.RowIndex].Cells["DNI"].Value.ToString();
            lblNombre.Text = dgvDocumentos.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
            lblRecibido.Text = String.Format("{0:f2}", dgvDocumentos.Rows[e.RowIndex].Cells["MONTO_RECIBIDO"].Value);
            lblVuelto.Text = String.Format("{0:f2}", dgvDocumentos.Rows[e.RowIndex].Cells["MONTO_VUELTO"].Value);
            lblTotal.Text = String.Format("{0:f2}", dgvDocumentos.Rows[e.RowIndex].Cells["MONTO_TOTAL"].Value);
            gbDetalle.Visible = true;
            btnAnular.Enabled = true;
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (id_cab == String.Empty)
            {
                MessageBox.Show("Debe seleccionar un documento para anular.", "Anular Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var confirm = MessageBox.Show("¿Está seguro que desea anular la venta?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (confirm == DialogResult.Yes)
            {
                if (id_cab == String.Empty)
                {
                    MessageBox.Show("Debe seleccionar un documento para anular.", "Anular Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtMotivo.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("El Motivo no puede estar vacío.", "Anular Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMotivo.Focus();
                    return;
                }

                Ent_Anular anular = new Ent_Anular();
                anular.id_cab = int.Parse(id_cab);
                anular.tienda_cod = cod_tienda;
                anular.usuario = usuario;
                anular.motivo = txtMotivo.Text;

                anularVenta(anular);
            }
        }

        private void anularVenta(Ent_Anular anular)
        {
            try
            {
                string result = BL_Ventas.anularVenta(anular);
                if (result == "1")
                {
                    MessageBox.Show("¡Venta anulada exitosamente!", "Anular Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillDocumentos();
                    reiniciarAnular();
                }
                else
                {
                    MessageBox.Show("¡Ocurrió un error al anular la venta!\n" + result, "Anular Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Anular Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fillDocumentos();
            reiniciarAnular();
        }

        private void reiniciarAnular()
        {
            txtNroDocumento.Text = String.Empty;
            txtMotivo.Text = String.Empty;
            gbDetalle.Visible = false;
            btnAnular.Enabled = false;
        }
    }
}
