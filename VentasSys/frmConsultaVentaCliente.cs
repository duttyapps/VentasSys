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
    public partial class frmConsultaVentaCliente : Form
    {
        public frmConsultaVentaCliente()
        {
            InitializeComponent();
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
            entity.cliente_doc = txtDNI.Text;
            entity.cliente = txtNombre.Text;
            entity.emision = txtFecha.Text;

            List<Ent_Venta> lstVentas = BL_Ventas.getVentasPorCliente(entity);

            var bindingList = new BindingList<Ent_Venta>(lstVentas);
            var source = new BindingSource(bindingList, null);

            dgvVentas.DataSource = source;
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

            txtTotal.Text = dgvDetalle.Rows.Count.ToString();

        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string id = dgvVentas.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                fillDetalles(id);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fillVentas();
        }
    }
}
