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
using VentasSys.Utils;

namespace VentasSys
{
    public partial class frmProgMantenimiento : Form
    {
        private string cod_tienda { get; set; }
        private string usuario { get; set; }
        private string correlativo { get; set; }
        private Ent_Clientes cliente { get; set; }

        private Ent_Configuracion ent_configuracion;

        public frmProgMantenimiento(string tienda, string user)
        {
            InitializeComponent();
            ent_configuracion = new Ent_Configuracion();
            ent_configuracion = BL_Configuracion.getConfiguracion();
            correlativo = BL_Mantenimiento.getCorrelativo();
            lblSerie.Text = "N° 001-" + correlativo.PadLeft(6, '0');
            cod_tienda = tienda;
            usuario = user;
            txtFechaEmision.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dtpFechaSalida.Value = DateTime.Now;

            fillTipoMantenimiento();

            Dictionary<string, string> lista_tipo = new Dictionary<string, string>();
            lista_tipo.Add("", "SELECCIONE");
            lista_tipo.Add("RE", "REALIZADO");
            lista_tipo.Add("NR", "NO REALIZADO");
            lista_tipo.Add("RP", "REPACION");
            cboEstado.DataSource = new BindingSource(lista_tipo, null);
            cboEstado.DisplayMember = "Value";
            cboEstado.ValueMember = "Key";
        }

        private void fillTipoMantenimiento()
        {
            List<Ent_Tipo_Mantenimiento> lista_tipo = new List<Ent_Tipo_Mantenimiento>();

            var tipos = BL_Programacion.getTipoMantenimiento();

            lista_tipo.AddRange(tipos);

            cboMantenimiento.DataSource = lista_tipo;
            cboMantenimiento.ValueMember = "id";
            cboMantenimiento.DisplayMember = "descripcion";
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string tipo = "";
            if (rdbEmpresa.Checked == true) { tipo = "FA"; } else if (rdbPersona.Checked == true) { tipo = "BO"; } else { MessageBox.Show("Seleccione si es Persona o Empresa."); return; }

            frmBuscarCliente frm = new frmBuscarCliente(String.Empty, "nombre", tipo);
            frm.ShowDialog();

            if (frm.ent_cliente != null)
            {
                cliente = frm.ent_cliente;
                txtDesCliente.Text = (frm.ent_cliente.nombres == null) ? "" : frm.ent_cliente.nombres;
                txtDesRuc.Text = (frm.ent_cliente.dni == null) ? "" : frm.ent_cliente.dni;
            }
        }

        private void btnBuscarRuc_Click(object sender, EventArgs e)
        {
            string tipo = "";
            if (rdbEmpresa.Checked == true) { tipo = "FA"; } else if (rdbPersona.Checked == true) { tipo = "BO"; } else { MessageBox.Show("Seleccione si es Persona o Empresa."); return; }

            frmBuscarCliente frm = new frmBuscarCliente(String.Empty, "dni", tipo);
            frm.ShowDialog();

            if (frm.ent_cliente != null)
            {
                cliente = frm.ent_cliente;
                txtDesCliente.Text = (frm.ent_cliente.nombres == null) ? "" : frm.ent_cliente.nombres;
                txtDesRuc.Text = (frm.ent_cliente.dni == null) ? "" : frm.ent_cliente.dni;
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            if (dgvMantenimiento.Rows.Count > 0)
            {
                bool agregar = true;
                foreach (DataGridViewRow item in dgvMantenimiento.Rows)
                {
                    if (item.Cells["ID"].Value.ToString().Equals(cboMantenimiento.SelectedValue.ToString()))
                    {                        
                        MessageBox.Show("El tipo de mantenimiento ya ha sido agregado.");
                        return;
                    }
                }
                if (agregar)
                {
                    dgvMantenimiento.Rows.Add(cboMantenimiento.SelectedValue.ToString(), cboMantenimiento.Text);
                }
            }
            else
            {
                dgvMantenimiento.Rows.Add(cboMantenimiento.SelectedValue.ToString(),cboMantenimiento.Text);
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            Ent_Prog_Mantenimiento prog = new Ent_Prog_Mantenimiento();

            prog.documento = correlativo == "" ? 0 : int.Parse(correlativo);
            prog.documento_des = lblSerie.Text;
            prog.tienda = cod_tienda;
            prog.usuario = usuario;
            prog.tipo_persona = rdbEmpresa.Checked == true ? "N" : "E";
            prog.numero_documento = txtDesRuc.Text;
            prog.cliente_des = txtDesCliente.Text;
            prog.cliente = cliente;
            prog.estado = cboEstado.SelectedValue.ToString();
            prog.fecha_salida = dtpFechaSalida.Value.ToShortDateString();

            List<Ent_Tipo_Mantenimiento> lista_mant = new List<Ent_Tipo_Mantenimiento>();
            foreach (DataGridViewRow row in dgvMantenimiento.Rows)
            {
                Ent_Tipo_Mantenimiento prd = new Ent_Tipo_Mantenimiento();
                prd.id = int.Parse(row.Cells["ID"].Value.ToString());
                prd.descripcion = row.Cells["DESCRIPCION"].Value.ToString();

                lista_mant.Add(prd);
            }
            prog.mantenimiento=lista_mant;
            string request = BL_Mantenimiento.setProg_Mantenimiento(prog);
            if (request == "1")
            {
                MessageBox.Show("Se agregó correctamente");
                InvoicePDF pdf = new InvoicePDF();
                pdf.createServicioTecnico(ent_configuracion, prog);
            }
            else {
                MessageBox.Show(request);
            }
        }
    }
}
