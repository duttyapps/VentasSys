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
    public partial class frmConsultaVentas : Form
    {
        private string tienda { get; set; }
        public frmConsultaVentas(string _tienda)
        {
            tienda = _tienda;
            InitializeComponent();
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            fillComboEstados();
            fillTipoVenta();
            fillFormaPago();
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

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                e.RowIndex >= 0)
            {
                string id = dgvVentas.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                frmDetalleVenta frm = new frmDetalleVenta(id);
                frm.ShowDialog();
            }
        }
    }
}
