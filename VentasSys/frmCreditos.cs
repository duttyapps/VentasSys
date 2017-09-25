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
        private string usuario { get; set; }
        private Ent_Venta ent_venta { get; set; }
        public frmCreditos(string _cod_tienda, string _usuario)
        {
            InitializeComponent();
            fillTipoVenta();
            cod_tienda = _cod_tienda;
            usuario = _usuario;
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

            double total = dgvAbonos.Rows.Cast<DataGridViewRow>()
                  .Sum(t => Convert.ToDouble(t.Cells["MONTO"].Value));

            txtTotalRecibido.Text = total.ToString("#0.00");
            txtRecibido.Text = (total + ent_venta.monto_recibido).ToString("#0.00");
            txtSaldo.Text = (ent_venta.monto_total - double.Parse(txtRecibido.Text)).ToString("#0.00");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            reiniciarCredito();

            if (txtNroDocumento.Text == String.Empty)
            {
                MessageBox.Show("El número de documento no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroDocumento.Focus();
                return;
            }

            int v_nro_doc = int.Parse(txtNroDocumento.Text.Substring(4, txtNroDocumento.Text.Length - 4));
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
                ent_venta = res_venta;
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
                txtTotal.Text = res_venta.monto_total.ToString("#0.00");

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

        private void txtNroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '-'
                && (sender as TextBox).Text.IndexOf('-') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtAmortizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void btnGrabarAbono_Click(object sender, EventArgs e)
        {
            if (txtAmortizar.Text == String.Empty)
            {
                txtAmortizar.Text = "0.00";
            }

            if (txtAmortizar.Text == "0.00")
            {
                MessageBox.Show("El monto a amortizar no puede ser S/. 0.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmortizar.Focus();
                return;
            }

            double monto_deuda = ent_venta.monto_total - double.Parse(txtTotalRecibido.Text);
            double monto_abono = double.Parse(txtAmortizar.Text) + double.Parse(txtTotalRecibido.Text);

            if (monto_abono > ent_venta.monto_total)
            {
                MessageBox.Show("El monto a amortizar no puede ser mayor al monto de deuda.\nMonto Deuda: S/. " + monto_deuda.ToString("#0.00"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmortizar.Focus();
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro que desea amortizar S/. " + txtAmortizar.Text + " en la cuenta?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                grabarAbono();
            }
        }

        private void grabarAbono()
        {
            double monto = double.Parse(txtAmortizar.Text);

            Ent_Abonos abono = new Ent_Abonos();

            abono.id = ent_venta.id_cab;
            abono.id_cab = ent_venta.nro_doc;
            abono.cod_tienda = cod_tienda;
            abono.usuario = usuario;
            abono.monto = monto;

            string res = BL_Ventas.setAbono(abono);

            if (res.Equals("1"))
            {
                fillAbonos(abono.id, abono.id_cab);
                txtAmortizar.Text = "0.00";
            }
            else
            {
                MessageBox.Show("Error al grabar el abono.\n" + res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reiniciarCredito()
        {
            txtNroDocumento.Focus();
            tbDetalles.SelectTab(0);
            tbDetalles.Enabled = false;
            lblNroDocumento.Text = "001-000000";
            lblTipoVenta.Text = "Ninguno";
            txtDNI.Text = String.Empty;
            lblFecha.Text = "-";
            txtCliente.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            txtEmail.Text = String.Empty;

            if(dgvDetalleVenta.Rows.Count > 0)
            {
                dgvDetalleVenta.Rows.Clear();
            }

            txtSubTotal.Text = "0.00";
            txtIGV.Text = "0.00";
            txtTotal.Text = "0.00";
            txtRecibido.Text = "0.00";
            txtSaldo.Text = "0.00";
        }

        private void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            double saldo = double.Parse(txtSaldo.Text);

            if (saldo != 0)
            {
                MessageBox.Show("No se puede finalizar la venta debido a que aún existe deuda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro que desea finalizar la venta?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                reiniciarCredito();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Está seguro que desea cancelar el proceso?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(confirm == DialogResult.Yes)
            {
                reiniciarCredito();
            }
        }
    }
}
