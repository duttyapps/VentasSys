using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using VentasSys.BL;
using VentasSys.EL;

namespace VentasSys
{
    public partial class frmPagoProveedores : Form
    {
        private DateTime _dateNow;
        private string usuario { get; set; }

        public frmPagoProveedores(string _usuario)
        {
            InitializeComponent();
            _dateNow = DateTime.Now.Date;
            usuario = _usuario;
            txtFecha.Value = _dateNow;
            fillProveedores();
            fillPagos();

            dgvPagos.Columns["MONTO"].DefaultCellStyle.Format = "f";
            dgvPagos.Columns["MONTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void fillProveedores()
        {
            List<Ent_Proveedores> items = new List<Ent_Proveedores>();

            Ent_Proveedores prov = new Ent_Proveedores();

            var formapago = BL_Proveedores.getProveedores(prov);

            items.AddRange(formapago);

            cboProveedores.DataSource = items;
            cboProveedores.ValueMember = "id";
            cboProveedores.DisplayMember = "nombre";
        }

        private void fillPagos()
        {
            dgvPagos.AutoGenerateColumns = false;

            if (dgvPagos.Rows.Count > 0)
            {
                dgvPagos.Rows.Clear();
            }

            string fecha = txtFecha.Value.Date.ToString();

            List<Ent_PagosProveedores> lstPagos;

            lstPagos = BL_Proveedores.getPagos(fecha);

            var bindingList = new BindingList<Ent_PagosProveedores>(lstPagos);
            var source = new BindingSource(bindingList, null);

            dgvPagos.DataSource = source;

            sumarTotal();
        }

        private void sumarTotal()
        {
            double total = dgvPagos.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDouble(t.Cells["MONTO"].Value));

            txtTotal.Text = total.ToString("#0.00");
        }

        private void txtFecha_ValueChanged(object sender, EventArgs e)
        {
            if (txtFecha.Value != _dateNow)
            {
                btnRegistrarPago.Enabled = false;
                cboProveedores.Enabled = false;
                txtNroFactura.Enabled = false;
                txtMonto.Enabled = false;
            }
            else
            {
                btnRegistrarPago.Enabled = true;
                cboProveedores.Enabled = true;
                txtNroFactura.Enabled = true;
                txtMonto.Enabled = true;
            }

            fillPagos();
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (txtNroFactura.Text.Equals(String.Empty))
            {
                MessageBox.Show("El número de factura no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNroFactura.Focus();
                return;
            }

            if (txtMonto.Text.Equals(String.Empty))
            {
                MessageBox.Show("El monto no puede estar vacío o ser menor o igual a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMonto.Text = "0.00";
                txtMonto.Focus();
                return;
            }

            try
            {
                int id_proveedor = int.Parse(cboProveedores.SelectedValue.ToString());
                int nro_factura = int.Parse(txtNroFactura.Text.Split('-')[1]);
                double monto = double.Parse(txtMonto.Text);

                Ent_PagosProveedores ent = new Ent_PagosProveedores();
                ent.id_proveedor = id_proveedor;
                ent.nro_factura = nro_factura;
                ent.usuario = usuario;
                ent.monto = monto;

                string result = BL_Proveedores.registrarPago(ent);

                if (result == "1")
                {
                    MessageBox.Show("Pago registrado con éxito!.", "Regitrar Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reiniciarRegistrarPago();

                }
                else
                {
                    MessageBox.Show("Ocurrió un error al registrar el pago.\n\n" + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Error en el formato del número de factura.\n\nFormato: 000-000000", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reiniciarRegistrarPago()
        {
            txtNroFactura.Text = String.Empty;
            txtMonto.Text = "0.00";
            fillPagos();
        }
    }
}
