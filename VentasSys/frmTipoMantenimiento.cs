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
    public partial class frmTipoMantenimiento : Form
    {
        private string selectedIndex;

        public frmTipoMantenimiento()
        {
            InitializeComponent();
            fillTipoMantenimiento();
            fillComboEstado();
        }

        private void fillTipoMantenimiento()
        {
            dgvTipoMantenimiento.AutoGenerateColumns = false;

            if (dgvTipoMantenimiento.Rows.Count > 0)
            {
                dgvTipoMantenimiento.Rows.Clear();
            }

            List<Ent_Tipo_Mantenimiento> lista_tipo = BL_Programacion.getTipoMantenimiento();

            var bindingList = new BindingList<Ent_Tipo_Mantenimiento>(lista_tipo);
            var source = new BindingSource(bindingList, null);

            dgvTipoMantenimiento.DataSource = source;
        }

        private void fillComboEstado()
        {
            List<Object> items = new List<Object>();
            items.Add(new { id = "1", desc = "Activo" });
            items.Add(new { id = "0", desc = "Inactivo" });

            cboEstado.DataSource = items;
            cboEstado.ValueMember = "id";
            cboEstado.DisplayMember = "desc";
        }

        private void dgvTipoMantenimiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;

            if(e.RowIndex >= 0)
            {
                selectedIndex = dgvTipoMantenimiento.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                txtDescripcion.Text = dgvTipoMantenimiento.Rows[e.RowIndex].Cells["DESCRIPCION"].Value.ToString();
                cboEstado.SelectedValue = dgvTipoMantenimiento.Rows[e.RowIndex].Cells["ESTADO"].Value.ToString() == "Activo" ? "1" : "0";
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Ent_Tipo_Mantenimiento tipo = new Ent_Tipo_Mantenimiento();
            tipo.id = Convert.ToInt32(selectedIndex);
            tipo.descripcion = txtDescripcion.Text;
            tipo.estado = cboEstado.SelectedValue.ToString();

            try
            {
                String result = BL_Mantenimiento.updTipoMantenimiento(tipo);

                if (result == "1")
                {
                    MessageBox.Show("¡Tipo de Mantenimiento modificado exitosamente!", "Mantenimiento Tipo de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillTipoMantenimiento();
                }
                else
                {
                    MessageBox.Show("¡Ocurrió un error al modificar Tipo de Mantenimiento!", "Mantenimiento Tipo de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mantenimiento Tipo de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Ent_Tipo_Mantenimiento tipo = new Ent_Tipo_Mantenimiento();
            tipo.id = Convert.ToInt32(selectedIndex);

            try
            {
                String result = BL_Mantenimiento.delTipoMantenimiento(tipo);

                if (result == "1")
                {
                    MessageBox.Show("¡Tipo de Mantenimiento eliminado exitosamente!", "Mantenimiento Tipo de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillTipoMantenimiento();
                }
                else
                {
                    MessageBox.Show("¡Ocurrió un error al eliminar Tipo de Mantenimiento!", "Mantenimiento Tipo de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mantenimiento Tipo de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Ent_Tipo_Mantenimiento tipo = new Ent_Tipo_Mantenimiento();
            tipo.descripcion = txtDescripcion.Text;
            tipo.estado = cboEstado.SelectedValue.ToString();

            try
            {
                String result = BL_Mantenimiento.setTipoMantenimiento(tipo);

                if (result == "1")
                {
                    MessageBox.Show("¡Tipo de Mantenimiento agregado exitosamente!", "Mantenimiento Tipo de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillTipoMantenimiento();
                }
                else
                {
                    MessageBox.Show("¡Ocurrió un error al agregar Tipo de Mantenimiento!", "Mantenimiento Tipo de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mantenimiento Tipo de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
