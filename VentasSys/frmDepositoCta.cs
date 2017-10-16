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
    public partial class frmDepositoCta : Form
    {
        private DateTime _dateNow;
        private string usuario { get; set; }

        public frmDepositoCta(string _usuario)
        {
            InitializeComponent();
            _dateNow = DateTime.Now.Date;
            txtFecha.Value = _dateNow;
            usuario = _usuario;

            fillBancos();
            fillDepositos();
        }

        private void fillBancos()
        {
            List<Ent_Bancos> items = new List<Ent_Bancos>();

            var bancos = BL_Depositos.getBancos();

            items.AddRange(bancos);

            cboBanco.DataSource = items;
            cboBanco.ValueMember = "id";
            cboBanco.DisplayMember = "nombre";
        }

        private void fillDepositos()
        {
            dgvDepositos.AutoGenerateColumns = false;

            if (dgvDepositos.Rows.Count > 0)
            {
                dgvDepositos.Rows.Clear();
            }

            string fecha = txtFecha.Value.Date.ToString();

            List<Ent_Depositos> lstDepositos = BL_Depositos.getDepositos(fecha);

            var bindingList = new BindingList<Ent_Depositos>(lstDepositos);
            var source = new BindingSource(bindingList, null);

            dgvDepositos.DataSource = source;

            sumarTotal();
        }

        private void sumarTotal()
        {
            double total = dgvDepositos.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDouble(t.Cells["MONTO"].Value));

            txtTotal.Text = total.ToString("#0.00");
        }

        private void txtFecha_ValueChanged(object sender, EventArgs e)
        {
            if (txtFecha.Value != _dateNow)
            {
                btnRegistrar.Enabled = false;
                cboBanco.Enabled = false;
                txtMonto.Enabled = false;
            }
            else
            {
                btnRegistrar.Enabled = true;
                cboBanco.Enabled = true;
                txtMonto.Enabled = true;
            }

            fillDepositos();
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtMonto.Text.Equals(String.Empty))
            {
                MessageBox.Show("El monto no puede estar vacío o ser menor o igual a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMonto.Text = "0.00";
                txtMonto.Focus();
                return;
            }

            int id_banco = int.Parse(cboBanco.SelectedValue.ToString());
            double monto = double.Parse(txtMonto.Text);

            Ent_Depositos ent = new Ent_Depositos();

            ent.id_banco = id_banco;
            ent.usuario = usuario;
            ent.monto = monto;

            string result = BL_Depositos.registrarDeposito(ent);

            if (result == "1")
            {
                MessageBox.Show("Depósito registrado con éxito!.", "Regitrar Depósito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reiniciarDeposito();

            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar el depósito.\n\n" + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reiniciarDeposito()
        {
            txtMonto.Text = "0.00";
            fillDepositos();
        }
    }
}
