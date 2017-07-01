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
    public partial class frmBuscarCliente : Form
    {
        public Ent_Clientes ent_cliente;

        public frmBuscarCliente(string cliente)
        {
            InitializeComponent();
            txtCliente.Text = cliente;
            BuscarCliente();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void BuscarCliente()
        {

            dgvClientes.AutoGenerateColumns = false;

            if (dgvClientes.Rows.Count > 0)
            {
                dgvClientes.Rows.Clear();
            }

            string nombre = txtCliente.Text.Trim();
            List<Ent_Clientes> lstClientes = BL_Clientes.getClientesxNombre(nombre);

            var bindingList = new BindingList<Ent_Clientes>(lstClientes);
            var source = new BindingSource(bindingList, null);

            dgvClientes.DataSource = source;
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                ent_cliente = new Ent_Clientes();
                ent_cliente.id = dgvClientes.Rows[e.RowIndex].Cells["id"].Value.ToString();
                ent_cliente.nombres = dgvClientes.Rows[e.RowIndex].Cells["nombres"].Value.ToString();
                ent_cliente.dni = dgvClientes.Rows[e.RowIndex].Cells["dni"].Value.ToString();
                ent_cliente.direccion = dgvClientes.Rows[e.RowIndex].Cells["direccion"].Value.ToString();
                this.Close();
            }

        }
    }
}
