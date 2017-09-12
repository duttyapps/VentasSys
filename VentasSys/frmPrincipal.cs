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
        private Ent_Tienda ent_tienda;
        private string tipo_venta { get; set; }
        private string forma_pago { get; set; }
        private string correlativo { get; set; }
        private string cod_tienda { get; set; }
        private string des_tienda { get; set; }
        public double total;

        public frmPrincipal(Ent_Usuario ent_us)
        {
            try
            {
                InitializeComponent();
                ent_usuario = ent_us;
                tipo_venta = "BO";
                InicializarSistema();
                cod_tienda = ent_tienda.cod_tienda;
                des_tienda = ent_tienda.des_tienda;
                lblTienda.Text = "Tienda: " + des_tienda;
                log.Info("Tipo de Venta: " + tipo_venta, System.Reflection.MethodBase.GetCurrentMethod().Name);
                log.Info("Serie N°: " + lblSerie.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                log.Error(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void InicializarSistema()
        {
            fillMenuTipoVenta();
            fillMenuTienda();
            fillFormaPago();
            ent_configuracion = new Ent_Configuracion();
            ent_configuracion = BL_Configuracion.getConfiguracion();
            ent_tienda = BL_Tienda.getTienda(ent_configuracion.TIENDA);
            lblRUC.Text = "R.U.C. " + ent_configuracion.RUC;
            lblRazonSocial.Text = ent_configuracion.RAZON_SOCIAL;
            Image logo = Image.FromFile("logo.png");
            pbLogo.Image = logo;
            correlativo = BL_Ventas.getCorrelativo(tipo_venta);
            lblBienvenido.Text = "Bienvenid@ " + ent_usuario.nombres;
            lblTienda.Text = "Tienda: " + des_tienda;
            lblSerie.Text = "N° 001-" + correlativo;
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dgvProductos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            cboFormaPago.SelectedIndex = 0;
            menuAdmin();
        }

        private void fillMenuTipoVenta()
        {
            menuTipoVenta.DropDownItems.Clear();

            List<Ent_TipoVentas> lstTipoVentas = BL_Ventas.getTipoVenta(String.Empty);

            ToolStripMenuItem[] items = new ToolStripMenuItem[lstTipoVentas.Count];
            int i = 0;
            lstTipoVentas.ForEach(delegate (Ent_TipoVentas tipo_venta)
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

        private void fillMenuTienda()
        {
            menuTienda.DropDownItems.Clear();

            List<Ent_Tienda> lstTiendas = BL_Tienda.getTiendas();

            ToolStripMenuItem[] items = new ToolStripMenuItem[lstTiendas.Count];
            int i = 0;
            lstTiendas.ForEach(delegate (Ent_Tienda tienda)
            {
                items[i] = new ToolStripMenuItem();
                items[i].Name = tienda.cod_tienda;
                items[i].Tag = tienda.cod_tienda;
                items[i].Text = tienda.des_tienda;
                items[i].Click += new EventHandler(MenuTiendasItemClickHandler);
                i++;
            });

            menuTienda.DropDownItems.AddRange(items);

        }

        public void fillFormaPago()
        {
            List<Ent_FormaPago> items = new List<Ent_FormaPago>();

            var formapago = BL_Ventas.getFormaPago();

            items.AddRange(formapago);

            cboFormaPago.DataSource = items;
            cboFormaPago.ValueMember = "codigo";
            cboFormaPago.DisplayMember = "descripcion";
        }

        private void MenuVentasTipoItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            tipo_venta = clickedItem.Tag.ToString();
            cambiarTipoVenta(clickedItem.Text.ToString().ToUpper());
        }

        private void MenuTiendasItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

            if (clickedItem.Tag.ToString() != cod_tienda)
            {
                var confirm = MessageBox.Show("¿Está seguro que desea cambiar de tienda? El progreso de venta se reiniciará.", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    cod_tienda = clickedItem.Tag.ToString();
                    des_tienda = clickedItem.Text.ToString();
                    reiniciarVenta();
                }
            }
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sistema.Base_de_Datos.frmConfiguracion frm = new Sistema.Base_de_Datos.frmConfiguracion();
            frm.ShowDialog();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBuscarCliente frm = new frmBuscarCliente(txtCliente.Text, "nombre", tipo_venta);
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
            frmBuscarCliente frm = new frmBuscarCliente(txtDNI.Text, "dni", tipo_venta);
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
            frmBuscarProducto frm = new frmBuscarProducto(cod_tienda);
            frm.ShowDialog();

            if (frm.ent_producto != null)
            {
                if (dgvProductos.Rows.Count > 0)
                {
                    bool agregar = true;
                    foreach (DataGridViewRow item in dgvProductos.Rows)
                    {
                        if (item.Cells["ID"].Value.ToString().Equals(frm.ent_producto.id.ToString()))
                        {
                            int adicion = int.Parse(item.Cells["CANTIDAD"].Value.ToString()) + 1;
                            if (adicion > BL_Productos.getStockProducto(Convert.ToInt32(item.Cells["ID"].Value), cod_tienda))
                            {
                                MessageBox.Show("Stock insuficiente, no se pudo agregar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                item.Cells["CANTIDAD"].Value = adicion;
                            }
                            item.Selected = true;
                            agregar = false;
                            return;
                        }
                    }
                    if (agregar)
                    {
                        dgvProductos.Rows.Add(generarCodigoProducto(frm.ent_producto.id, frm.ent_producto.id_cat), frm.ent_producto.nombre, "1", frm.ent_producto.precio.ToString("#0.00"), frm.ent_producto.precio.ToString("#0.00"), frm.ent_producto.id);
                    }
                }
                else
                {
                    dgvProductos.Rows.Add(generarCodigoProducto(frm.ent_producto.id, frm.ent_producto.id_cat), frm.ent_producto.nombre, "1", frm.ent_producto.precio.ToString("#0.00"), frm.ent_producto.precio.ToString("#0.00"), frm.ent_producto.id);
                }
            }

            sumarTotal();
        }

        private string generarCodigoProducto(int id, int cat)
        {
            return id.ToString(cod_tienda + cat.ToString("00") + "00000");
        }

        private void sumarTotal()
        {
            total = dgvProductos.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDouble(t.Cells["IMPORTE"].Value));

            txtTotal.Text = total.ToString("#0.00");
            txtSubTotal.Text = Convert.ToDouble(total / (ent_configuracion.IGV + 1)).ToString("#0.00");
            txtIGV.Text = (total - Convert.ToDouble(txtSubTotal.Text)).ToString("#0.00");
        }

        private int sumarCantidad()
        {
            int total = dgvProductos.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToInt32(t.Cells["CANTIDAD"].Value));

            return total;
        }

        private void dgvProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (int.Parse(dgvProductos.Rows[row].Cells["CANTIDAD"].Value.ToString()) == 0)
            {
                dgvProductos.Rows[row].Cells["CANTIDAD"].Value = 1;
            }

            if (decimal.Parse(dgvProductos.Rows[row].Cells["PU"].Value.ToString()) == 0)
            {
                dgvProductos.Rows.RemoveAt(row);
            }

            if (dgvProductos.Rows.Count > 0)
            {
                multiplicarxCantidad(row);
                //formating...
                double pu = double.Parse(dgvProductos.Rows[row].Cells["PU"].Value.ToString());
                dgvProductos.Rows[row].Cells["PU"].Value = pu.ToString("#0.00");
            }
        }

        private void multiplicarxCantidad(int row)
        {
            try
            {
                int id_producto = int.Parse(dgvProductos.Rows[row].Cells["ID"].Value.ToString());
                double precio_unitario = (dgvProductos.Rows[row].Cells["PU"].Value == null) ? BL_Productos.getPrecioProducto(id_producto) : Convert.ToDouble(dgvProductos.Rows[row].Cells["PU"].Value);
                int cantidad = (dgvProductos.Rows[row].Cells["CANTIDAD"].Value == null) ? 1 : int.Parse(dgvProductos.Rows[row].Cells["CANTIDAD"].Value.ToString());
                int stock = BL_Productos.getStockProducto(id_producto, cod_tienda);

                if (dgvProductos.Rows[row].Cells["PU"].Value == null)
                {
                    dgvProductos.Rows[row].Cells["PU"].Value = BL_Productos.getPrecioProducto(id_producto).ToString("#0.00");
                }

                if (dgvProductos.Rows[row].Cells["CANTIDAD"].Value == null)
                {
                    dgvProductos.Rows[row].Cells["CANTIDAD"].Value = 1;
                }

                if (cantidad > stock)
                {
                    MessageBox.Show("No contamos con el stock suficiente para el producto.\n\nStock: " + stock, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvProductos.Rows[row].Cells["CANTIDAD"].Value = stock;
                    return;
                }

                double _total = Convert.ToDouble((cantidad * precio_unitario));

                dgvProductos.Rows[row].Cells["IMPORTE"].Value = _total.ToString("#0.00");

                sumarTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular precio por cantidad. \n\n" + ex.Message);
                log.Error(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvProductos.SelectedRows)
            {
                dgvProductos.Rows.RemoveAt(item.Index);
            }
            sumarTotal();
        }

        private void dgvProductos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvProductos.CurrentCell.ColumnIndex == 2)
            {
                e.Control.KeyPress -= new KeyPressEventHandler(CajaNumerosEnteros_KeyPress);
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(CajaNumerosEnteros_KeyPress);
                }
            }
            else if (dgvProductos.CurrentCell.ColumnIndex == 3)
            {
                e.Control.KeyPress -= new KeyPressEventHandler(CajaNumerosDecimales_KeyPress);
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(CajaNumerosDecimales_KeyPress);
                }
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.Rows.Count == 0)
            {
                MessageBox.Show("No se agregó ningún producto. La compra no puede ser realizada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtRecibido.Text == String.Empty)
            {
                txtRecibido.Text = "0.00";
            }

            if (Convert.ToDecimal(txtRecibido.Text) <= 0 && cboFormaPago.SelectedValue.ToString() == "CO")
            {
                MessageBox.Show("El monto recibido no puede estar en S/. 0.00.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRecibido.Select();
                return;
            }

            if (Convert.ToDecimal(txtVuelto.Text) < 0)
            {
                MessageBox.Show("El vuelto no debe ser negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRecibido.Select();
                return;
            }

            if (tipo_venta == "BO")
            {
                if (txtCliente.Text.Length == 0)
                {
                    var confirm = MessageBox.Show("¿Está seguro que desea realizar la venta sin cliente?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        txtCliente.Text = "SIN NOMBRE";
                        txtDireccion.Text = "SIN DIRECCIÓN";
                        txtDNI.Text = "00000000";
                    }
                    else
                    {
                        txtCliente.Focus();
                        return;
                    }
                }

                if (txtDireccion.Text.Length == 0)
                {
                    txtDireccion.Text = "SIN DIRECCIÓN";
                }

                if (txtDNI.Text.Length != 8)
                {
                    MessageBox.Show("Debe ingresar un DNI correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDNI.Focus();
                    return;
                }
            }
            else if (tipo_venta == "FA")
            {
                if (txtCliente.Text.Length == 0)
                {
                    MessageBox.Show("La Razón Social no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCliente.Focus();
                    return;
                }

                if (txtDNI.Text.Length == 0)
                {
                    MessageBox.Show("El RUC no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDNI.Focus();
                    return;
                }
                else if (txtDNI.Text.Length != 11)
                {
                    MessageBox.Show("El número RUC no es correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDNI.Focus();
                    return;
                }

                if (txtDireccion.Text.Length == 0)
                {
                    MessageBox.Show("La Dirección no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDireccion.Focus();
                    return;
                }
            }

            forma_pago = cboFormaPago.SelectedValue.ToString();
            procesarCompra();
        }

        private void procesarCompra()
        {
            Ent_Venta venta = new Ent_Venta();

            venta.nro_doc = int.Parse(correlativo);
            venta.cod_tienda = cod_tienda;
            venta.tipo_venta = tipo_venta;
            venta.forma_pago = forma_pago;
            venta.cantidad = sumarCantidad();
            venta.monto_total = total;
            venta.monto_recibido = double.Parse(txtRecibido.Text);
            venta.monto_vuelto = double.Parse(txtVuelto.Text);
            venta.cliente_doc = txtDNI.Text;
            venta.usuario = ent_usuario.username;

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                Ent_Productos prd = new Ent_Productos();
                prd.id = int.Parse(row.Cells["ID"].Value.ToString());
                prd.nombre = row.Cells["DESCRIPCION"].Value.ToString();
                prd.cantidad = int.Parse(row.Cells["CANTIDAD"].Value.ToString());
                prd.precio = float.Parse(row.Cells["PU"].Value.ToString());

                venta.lstProductos.Add(prd);
            }

            string result = BL_Ventas.procesarVenta(venta);

            if (result == "1")
            {
                MessageBox.Show("Venta Realizada con Éxito!.", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reiniciarVenta();
            }
            else
            {
                MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cambiarTipoVenta(string tipo_venta_des)
        {
            correlativo = BL_Ventas.getCorrelativo(tipo_venta);
            lblTipoVenta.Text = tipo_venta_des;
            lblSerie.Text = "N° 001-" + correlativo;

            if (tipo_venta == "FA")
            {
                lblCliente.Text = "Razón Social:";
                lblDNI.Text = "R.U.C.:";
            }
            else
            {
                lblCliente.Text = "Cliente:";
                lblDNI.Text = "DNI:";
            }

            log.Info("Cambio Tipo Venta: " + tipo_venta, System.Reflection.MethodBase.GetCurrentMethod().Name);
            log.Info("Serie " + lblSerie.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void menuAdmin()
        {
            if (ent_usuario.rango == "0")
            {
                sistemaToolStripMenuItem.Visible = false;
            }
        }

        private void txtRecibido_TextChanged(object sender, EventArgs e)
        {
            if (txtRecibido.Text.Length > 0)
            {
                txtVuelto.Text = (Convert.ToDecimal(txtRecibido.Text) - Convert.ToDecimal(txtTotal.Text)).ToString("#0.00");
            }
            else
            {
                txtVuelto.Text = "0.00";
            }
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos(cod_tienda, ent_usuario.username);
            frm.ShowDialog();
        }

        public void reiniciarVenta()
        {
            InicializarSistema();
            txtCliente.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            txtDNI.Text = String.Empty;
            dgvProductos.Rows.Clear();
            txtTotal.Text = "0.00";
            txtIGV.Text = "0.00";
            txtSubTotal.Text = "0.00";
            txtRecibido.Text = "0.00";
            txtVuelto.Text = "0.00";
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea reiniciar la venta?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                reiniciarVenta();
            }
        }

        private void CajaLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CajaNumerosEnteros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CajaNumerosDecimales_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRecibido_KeyPress(object sender, KeyPressEventArgs e)
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

        private void modificarEliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoProductos frm = new frmMantenimientoProductos(cod_tienda);
            frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea salir?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dgvProductos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                multiplicarxCantidad(dgvProductos.CurrentRow.Index);
            }
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void anularVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAnularVenta frm = new frmAnularVenta(cod_tienda, ent_usuario.username);
            frm.ShowDialog();
        }

        private void cboFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboFormaPago.SelectedValue.ToString() == "CR")
            {
                lblRecibido.Text = "Restante";
            } else
            {
                lblRecibido.Text = "Recibido";
            }
        }
    }
}
