using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using VentasSys.BL;
using VentasSys.EL;
using VentasSys.Utils;

namespace VentasSys
{
    public partial class frmBuscarCliente : Form
    {
        public Ent_Clientes ent_cliente;
        private string tipo;
        private string tipo_cliente { get; set; }

        public frmBuscarCliente(string cliente, string _tipo = "nombre", string tipo_venta = "BO")
        {
            InitializeComponent();
            txtCliente.Text = cliente;
            tipo = _tipo;
            tipo_cliente = (tipo_venta == "FA") ? "E" : "N";

            if (tipo_venta == "FA")
            {
                dgvClientes.Columns["NOMBRES"].HeaderText = "Razón Social";
                dgvClientes.Columns["DNI"].HeaderText = "RUC";
            }

            if (tipo == "dni")
            {
                if (tipo_cliente == "N")
                {
                    lblBuscarCliente.Text = "Buscar por DNI de cliente:";
                }
                else
                {
                    lblBuscarCliente.Text = "Buscar por RUC de cliente:";
                }
            }
            else
            {
                if (tipo_cliente == "N")
                {
                    lblBuscarCliente.Text = "Buscar por nombre de cliente:";
                }
                else
                {
                    lblBuscarCliente.Text = "Buscar por razón social del cliente:";
                }
            }
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

            string input = txtCliente.Text.Trim();

            List<Ent_Clientes> lstClientes;

            if (tipo == "dni")
            {
                lstClientes = BL_Clientes.getClientesxDNI(input, tipo_cliente);
            }
            else
            {
                lstClientes = BL_Clientes.getClientesxNombre(input, tipo_cliente);
            }

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

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            BuscarCliente();
        }
    }
}
