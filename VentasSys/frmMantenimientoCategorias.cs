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
    public partial class frmMantenimientoCategorias : Form
    {
        public frmMantenimientoCategorias()
        {
            InitializeComponent();
            fillComboEstados();
            fillCategorias();
        }

        private void fillComboEstados()
        {
            List<Object> items = new List<Object>();
            items.Add(new { id = "", desc = "Seleccionar" });
            items.Add(new { id = "1", desc = "Activo" });
            items.Add(new { id = "0", desc = "Inactivo" });

            cboEstado.DataSource = items;
            cboEstado.ValueMember = "id";
            cboEstado.DisplayMember = "desc";

            List<Object> items_det = items.ToList();
            cboEstadoDet.DataSource = items_det;
            cboEstadoDet.ValueMember = "id";
            cboEstadoDet.DisplayMember = "desc";
        }

        private void fillCategorias()
        {
            string nombre = txtNombre.Text;
            string estado = (cboEstado.SelectedValue == null) ? null : cboEstado.SelectedValue.ToString();

            dgvCategorias.AutoGenerateColumns = false;

            if (dgvCategorias.Rows.Count > 0)
            {
                dgvCategorias.Rows.Clear();
            }

            List<Ent_CategoriaProductos> lstCategorias = BL_CategoriaProductos.getCategorias(nombre, estado);

            var bindingList = new BindingList<Ent_CategoriaProductos>(lstCategorias);
            var source = new BindingSource(bindingList, null);

            dgvCategorias.DataSource = source;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            fillCategorias();
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillCategorias();
        }
    }
}
