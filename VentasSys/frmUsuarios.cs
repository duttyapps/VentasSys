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
    public partial class frmUsuarios : Form
    {
        private string accion { get; set; }
        private string id_usuario { get; set; }
        public frmUsuarios()
        {
            InitializeComponent();
            fillComboRango();
            fillComboSexo();
            fillUsuarios();
        }

        private void fillUsuarios()
        {
            dgvUsuarios.AutoGenerateColumns = false;
            
            if (dgvUsuarios.Rows.Count > 0)
            {
                dgvUsuarios.Rows.Clear();
            }

            Ent_Usuario entity = new Ent_Usuario();
            entity.dni = txtDNI.Text;
            entity.rango = cboRango.SelectedValue.ToString();

            if (entity.rango == "{ id = , desc = Todos }")
            {
                return;
            }

            List<Ent_Usuario> lstUsuarios = BL_Usuario.getUsuarios(entity);

            var bindingList = new BindingList<Ent_Usuario>(lstUsuarios);
            var source = new BindingSource(bindingList, null);

            dgvUsuarios.DataSource = source;

        }

        private void fillComboRango()
        {
            List<Object> items = new List<Object>();
            items.Add(new { id = "", desc = "Todos" });
            items.Add(new { id = "1", desc = "Administrador" });
            items.Add(new { id = "0", desc = "Cajero" });

            cboRango.DataSource = items;
            cboRango.ValueMember = "id";
            cboRango.DisplayMember = "desc";

            cboRango.SelectedValue = "";
        }

        private void fillComboSexo()
        {
            List<Object> items = new List<Object>();
            items.Add(new { id = "", desc = "Seleccionar" });
            items.Add(new { id = "M", desc = "Masculino" });
            items.Add(new { id = "F", desc = "Femenino" });

            cboSexo.DataSource = items;
            cboSexo.ValueMember = "id";
            cboSexo.DisplayMember = "desc";
        }

        private void fillDatosUsuario(DataGridViewCellEventArgs e)
        {
            string id = dgvUsuarios.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            Ent_Usuario usuario = BL_Usuario.getUsuario(id);

            txtCodigo.Text = usuario.codigo;
            txtFechaReg.Text = usuario.fecha_reg;
            txtFechaNac.Text = usuario.fecha_nac;
            txtDNIDet.Text = usuario.dni;
            txtNombres.Text = usuario.nombres;
            txtEmail.Text = usuario.email;
            cboSexo.SelectedValue = usuario.sexo;
            if(usuario.rango == "A")
            {
                rbAdmin.Checked = true;
            } else
            {
                rbCajero.Checked = true;
            }
            txtTelefono.Text = usuario.telefono;

            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            fillUsuarios();
        }

        private void cboRango_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillUsuarios();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                btnCancelar_Click(null, EventArgs.Empty);
                fillDatosUsuario(e);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarDatos();
            txtDNIDet.Enabled = true;
            txtFechaNac.Enabled = true;
            txtNombres.Enabled = true;
            txtEmail.Enabled = true;
            cboSexo.Enabled = true;
            rbAdmin.Enabled = true;
            rbCajero.Enabled = true;
            txtTelefono.Enabled = true;
            txtContrasena.Enabled = true;

            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;

            accion = "N";
        }

        private void limpiarDatos()
        {
            txtCodigo.Text = String.Empty;
            txtCodigo.Enabled = false;
            txtDNIDet.Text = String.Empty;
            txtFechaReg.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFechaReg.Enabled = false;
            txtFechaNac.Text = String.Empty;
            txtNombres.Text = String.Empty;
            txtEmail.Text = String.Empty;
            cboSexo.SelectedValue = String.Empty;
            rbAdmin.Checked = false;
            rbCajero.Checked = false;
            txtTelefono.Text = String.Empty;
            txtContrasena.Text = String.Empty;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarDatos();
            txtDNIDet.Enabled = false;
            txtFechaNac.Enabled = false;
            txtNombres.Enabled = false;
            txtEmail.Enabled = false;
            cboSexo.Enabled = false;
            rbAdmin.Enabled = false;
            rbCajero.Enabled = false;
            txtTelefono.Enabled = false;
            txtContrasena.Enabled = false;

            btnRestaurar.Enabled = false;

            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;

            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;

            txtEmail.Enabled = true;
            txtTelefono.Enabled = true;
            rbAdmin.Enabled = true;
            rbCajero.Enabled = true;

            btnRestaurar.Enabled = true;

            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;

            accion = "M";
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            txtContrasena.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Ent_Usuario user = new Ent_Usuario();

            user.dni = txtDNIDet.Text;
            user.password = txtContrasena.Text;
            user.nombres = txtNombres.Text;
            user.sexo = cboSexo.SelectedValue.ToString();
            user.fecha_nac = txtFechaNac.Value.ToShortDateString();
            user.email = txtEmail.Text;
            user.telefono = txtTelefono.Text;
            if (rbAdmin.Checked == true) user.rango = "A";
            else if (rbCajero.Checked == true) user.rango = "C";
            else return;

            if (accion == "N")
            {
                string inserta_usuario = BL_Usuario.insertarUsuario(user);
                if (inserta_usuario == "1")
                {
                    MessageBox.Show("Se agrego usuario exitosamente");
                    fillUsuarios();
                    limpiarDatos();
                }
                else
                {
                    MessageBox.Show(inserta_usuario);
                }
            }
            else if (accion=="M"){
                user.id = txtCodigo.Text;
                string inserta_usuario = BL_Usuario.editarUsuario(user);
                if (inserta_usuario == "1")
                {
                    MessageBox.Show("Se modifico usuario exitosamente");
                    fillUsuarios();
                    limpiarDatos();
                }
                else
                {
                    MessageBox.Show(inserta_usuario);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "") {
                string delete_usuario = BL_Usuario.eliminarUsuario(txtCodigo.Text);
                fillUsuarios();
            }
        }
    }
}
