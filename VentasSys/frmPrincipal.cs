using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VentasSys.BL;
using VentasSys.EL;
using VentasSys.Utils;

namespace VentasSys
{
    public partial class frmPrincipal : Form
    {
        private Log log = new Log();
        private Ent_Usuario ent_usuario;
        private Ent_Configuracion ent_configuracion;
        private string tipo_venta { get; set; }
        private string correlativo { get; set; }
        public double total;

        public frmPrincipal(Ent_Usuario ent_us)
        {
            try
            {
                InitializeComponent();
                ent_usuario = ent_us;
                tipo_venta = "BO";
                InicializarSistema();
                log.Info("Tipo de Venta: " + tipo_venta, System.Reflection.MethodBase.GetCurrentMethod().Name);
                log.Info("Serie N°: " + lblSerie.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            } catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                log.Error(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void InicializarSistema()
        {
            fillMenuTipoVenta();
            ent_configuracion = new Ent_Configuracion();
            ent_configuracion = BL_Configuracion.getConfiguracion();
            lblRUC.Text = "R.U.C. " + ent_configuracion.RUC;
            lblRazonSocial.Text = ent_configuracion.RAZON_SOCIAL;
            Image logo = Image.FromFile("logo.png");
            pbLogo.Image = logo;
            correlativo = BL_Ventas.getCorrelativo(tipo_venta);
            lblBienvenido.Text = "Bienvenid@ " + ent_usuario.nombres;
            lblSerie.Text = "N° 001-" + correlativo;
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dgvProductos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void fillMenuTipoVenta()
        {
            List<Ent_TipoVentas> lstTipoVentas = BL_Ventas.getTipoVenta(String.Empty);

            ToolStripMenuItem[] items = new ToolStripMenuItem[lstTipoVentas.Count];
            int i = 0;
            lstTipoVentas.ForEach(delegate(Ent_TipoVentas tipo_venta)
            {
                items[i] = new ToolStripMenuItem();
                items[i].Name = tipo_venta.id;
                items[i].Tag = tipo_venta.codigo;
                items[i].Text = tipo_venta.descripcion;
                items[i].Click += new EventHandler(MenuVentasTipoItemClickHandler);
                i++;
            });

            menuTipoVenta.DropDownItems.AddRange(items);

        }

        private void MenuVentasTipoItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            tipo_venta = clickedItem.Tag.ToString();
            correlativo = BL_Ventas.getCorrelativo(tipo_venta);
            lblTipoVenta.Text = clickedItem.Text.ToString().ToUpper();
            lblSerie.Text = "N° 001-" + correlativo;

            if (tipo_venta == "FA")
            {
                lblCliente.Text = "Razón Social";
                lblDNI.Text = "R.U.C.";
            }
            else
            {
                lblCliente.Text = "Cliente";
                lblDNI.Text = "DNI";
            }

            log.Info("Cambio Tipo Venta: " + tipo_venta, System.Reflection.MethodBase.GetCurrentMethod().Name);
            log.Info("Serie N°: " + lblSerie.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sistema.Base_de_Datos.frmConfiguracion frm = new Sistema.Base_de_Datos.frmConfiguracion();
            frm.ShowDialog();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBuscarCliente frm = new frmBuscarCliente(txtCliente.Text);
            frm.ShowDialog();

            if (frm.ent_cliente != null)
            {
                txtCliente.Text = (frm.ent_cliente.nombres == null) ? "" : frm.ent_cliente.nombres;
                txtDireccion.Text = (frm.ent_cliente.direccion == null) ? "" : frm.ent_cliente.direccion;
                txtDNI.Text = (frm.ent_cliente.dni == null) ? "" : frm.ent_cliente.dni;
            }
        }

        private void btnBuscarDNI_Click(object sender, EventArgs e)
        {
            frmBuscarCliente frm = new frmBuscarCliente(txtCliente.Text, "dni");
            frm.ShowDialog();

            if (frm.ent_cliente != null)
            {
                txtCliente.Text = (frm.ent_cliente.nombres == null) ? "" : frm.ent_cliente.nombres;
                txtDireccion.Text = (frm.ent_cliente.direccion == null) ? "" : frm.ent_cliente.direccion;
                txtDNI.Text = (frm.ent_cliente.dni == null) ? "" : frm.ent_cliente.dni;
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            frmBuscarProducto frm = new frmBuscarProducto();
            frm.ShowDialog();

            if(frm.ent_producto != null)
            {
                if (dgvProductos.Rows.Count > 0)
                {
                    bool agregar = true;
                    foreach (DataGridViewRow item in dgvProductos.Rows)
                    {
                        if (item.Cells["ID"].Value.ToString().Equals(frm.ent_producto.id))
                        {
                            item.Cells["CANTIDAD"].Value = int.Parse(item.Cells["CANTIDAD"].Value.ToString()) + 1;
                            item.Selected = true;
                            agregar = false;
                            return;
                        }
                    }
                    if (agregar)
                    {
                        dgvProductos.Rows.Add("1", frm.ent_producto.id, frm.ent_producto.nombre, frm.ent_producto.precio.ToString("#0.00"), frm.ent_producto.precio.ToString("#0.00"));
                    }
                }
                else
                {
                    dgvProductos.Rows.Add("1", frm.ent_producto.id, frm.ent_producto.nombre, frm.ent_producto.precio.ToString("#0.00"), frm.ent_producto.precio.ToString("#0.00"));
                }
            }

            sumarTotal();
        }

        private void sumarTotal()
        {
            total = dgvProductos.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDouble(t.Cells["IMPORTE"].Value));

            txtTotal.Text = total.ToString("#0.00");
            txtSubTotal.Text = Convert.ToDouble(total / (ent_configuracion.IGV + 1)).ToString("#0.00");
            txtIGV.Text = (total - Convert.ToDouble(txtSubTotal.Text)).ToString("#0.00");
        }

        private void dgvProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            multiplicarxCantidad(row);
        }

        private void multiplicarxCantidad(int row)
        {
            double precio_unitario = Convert.ToDouble(dgvProductos.Rows[row].Cells["PU"].Value);
            int cantidad = int.Parse(dgvProductos.Rows[row].Cells["CANTIDAD"].Value.ToString());

            double _total = Convert.ToDouble((cantidad * precio_unitario));

            dgvProductos.Rows[row].Cells["IMPORTE"].Value = _total.ToString("#0.00");

            sumarTotal();
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvProductos.SelectedRows)
            {
                dgvProductos.Rows.RemoveAt(item.Index);
            }
            sumarTotal();
        }

        private void dgvProductos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                multiplicarxCantidad(dgvProductos.CurrentRow.Index);
            }
        }

        private void dgvProductos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnaCantidad_KeyPress);
            if (dgvProductos.CurrentCell.ColumnIndex == 0)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnaCantidad_KeyPress);
                }
            }
        }

        private void ColumnaCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.Rows.Count == 0)
            {
                MessageBox.Show("No se ha seleccionado ningún producto. La compra no puede ser realizada.");
                return;
            }

            if (txtCliente.Text.Length == 0)
            {
                var confirm = MessageBox.Show("¿Está seguro que desea realizar la venta sin cliente?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == System.Windows.Forms.DialogResult.Yes)
                {
                    txtCliente.Text = "-";
                    txtDireccion.Text = "-";
                    txtDNI.Text = "-";
                }
                else
                {
                    txtCliente.Focus();
                    return;
                }
            }

            if (txtDireccion.Text.Length == 0)
            {
                txtDireccion.Text = "-";
            }

            if (txtDNI.Text.Length == 0)
            {
                txtDNI.Text = "-";
            }
        }

        private void procesarCompra()
        {

        }
    }
}
