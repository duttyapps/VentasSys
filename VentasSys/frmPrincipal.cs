using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
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
            lblRango.Text = (ent_usuario.rango == "1") ? "(Administrador)" : "(Cajero)";
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
            frmBuscarCliente frm = new frmBuscarCliente(txtNombres.Text, "nombre", tipo_venta);
            frm.ShowDialog();

            if (frm.ent_cliente != null)
            {
                txtNombres.Text = (frm.ent_cliente.nombres == null) ? "" : frm.ent_cliente.nombres;
                txtApellidos.Text = (frm.ent_cliente.apellidos == null) ? "" : frm.ent_cliente.apellidos;
                txtDireccion.Text = (frm.ent_cliente.direccion == null) ? "" : frm.ent_cliente.direccion;
                txtDNI.Text = (frm.ent_cliente.dni == null) ? "" : frm.ent_cliente.dni;
                txtTelefono.Text = (frm.ent_cliente.telefono == null) ? "" : frm.ent_cliente.telefono;
                txtEmail.Text = (frm.ent_cliente.email == null) ? "" : frm.ent_cliente.email;

                log.Info("Cliente seleccionado: [" + frm.ent_cliente.dni + "] " + txtNombres.Text + " " + txtApellidos.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnBuscarDNI_Click(object sender, EventArgs e)
        {
            frmBuscarCliente frm = new frmBuscarCliente(txtDNI.Text, "dni", tipo_venta);
            frm.ShowDialog();

            if (frm.ent_cliente != null)
            {
                txtNombres.Text = (frm.ent_cliente.nombres == null) ? "" : frm.ent_cliente.nombres;
                txtApellidos.Text = (frm.ent_cliente.apellidos == null) ? "" : frm.ent_cliente.apellidos;
                txtDireccion.Text = (frm.ent_cliente.direccion == null) ? "" : frm.ent_cliente.direccion;
                txtDNI.Text = (frm.ent_cliente.dni == null) ? "" : frm.ent_cliente.dni;
                txtTelefono.Text = (frm.ent_cliente.telefono == null) ? "" : frm.ent_cliente.telefono;
                txtEmail.Text = (frm.ent_cliente.email == null) ? "" : frm.ent_cliente.email;

                log.Info("Cliente seleccionado: [" + frm.ent_cliente.dni + "] " + txtNombres.Text + " " + txtApellidos.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                        dgvProductos.Rows.Add(BL_Productos.generarCodigoProducto(cod_tienda, frm.ent_producto.id, frm.ent_producto.id_cat), frm.ent_producto.nombre, "1", frm.ent_producto.precio.ToString("#0.00"), frm.ent_producto.precio.ToString("#0.00"), frm.ent_producto.id);
                    }
                }
                else
                {
                    dgvProductos.Rows.Add(BL_Productos.generarCodigoProducto(cod_tienda, frm.ent_producto.id, frm.ent_producto.id_cat), frm.ent_producto.nombre, "1", frm.ent_producto.precio.ToString("#0.00"), frm.ent_producto.precio.ToString("#0.00"), frm.ent_producto.id);
                }

                log.Info("Producto agregado: [" + BL_Productos.generarCodigoProducto(cod_tienda, frm.ent_producto.id, frm.ent_producto.id_cat) + "] " + frm.ent_producto.nombre, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            sumarTotal();
        }

        private void sumarTotal()
        {
            try
            {
                total = dgvProductos.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDouble(t.Cells["IMPORTE"].Value));

                if (tipo_venta == "FA")
                {
                    txtSubTotal.Text = Convert.ToDouble(total / (ent_configuracion.IGV + 1)).ToString("#0.00");
                    txtIGV.Text = (total - Convert.ToDouble(txtSubTotal.Text)).ToString("#0.00");
                }
                else
                {
                    txtSubTotal.Text = "0.00";
                    txtIGV.Text = "0.00";
                }

                txtTotal.Text = total.ToString("#0.00");

                if (dgvProductos.Rows.Count == 10)
                {
                    btnAgregarProducto.Enabled = false;
                } else
                {
                    btnAgregarProducto.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error al SUMAR TOTAL: " + ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private int sumarCantidad()
        {
            try
            {
                int total = dgvProductos.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToInt32(t.Cells["CANTIDAD"].Value));
                return total;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al sumar la cantidad. \n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Error al SUMAR TOTAL: " + ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return 0;
            }
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
                MessageBox.Show("Error al calcular precio por cantidad. \n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Error al calcular precio por cantidad. \n\n" + ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in dgvProductos.SelectedRows)
                {
                    if (item.Index > -1)
                    {
                        var confirm = MessageBox.Show("¿Está seguro que desea el producto " + item.Cells[1].Value.ToString().ToUpper() + "?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(confirm == DialogResult.Yes)
                        {
                            dgvProductos.Rows.RemoveAt(item.Index);
                            sumarTotal();
                            log.Info("Producto removido: [" + item.Cells[0].Value + "] " + item.Cells[1].Value, System.Reflection.MethodBase.GetCurrentMethod().Name);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al quitar el producto. \n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Error al quitar el producto: " + ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
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
            try
            {
                if (dgvProductos.Rows.Count == 0)
                {
                    MessageBox.Show("No se agregó ningún producto. La compra no puede ser realizada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtRecibido.Text == String.Empty)
                {
                    txtRecibido.Text = "0.00";
                }

                if (cboFormaPago.SelectedValue.ToString() == "CO")
                {
                    if (Convert.ToDecimal(txtRecibido.Text) <= 0)
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
                } else
                {
                    if (Convert.ToDecimal(txtRecibido.Text) >= Convert.ToDecimal(txtTotal.Text))
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
                }

                if (tipo_venta == "BO")
                {
                    if (txtDNI.Text.Length == 0)
                    {
                        var confirm = MessageBox.Show("¿Está seguro que desea realizar la venta sin cliente?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (confirm == DialogResult.Yes)
                        {
                            txtNombres.Text = "SIN NOMBRE";
                            txtApellidos.Text = "SIN APELLIDOS";
                            txtDireccion.Text = "SIN DIRECCIÓN";
                            txtDNI.Text = "00000000";
                            txtTelefono.Text = "1111111";
                            txtEmail.Text = "sincorreo@email.com";
                        }
                        else
                        {
                            txtNombres.Focus();
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
                    if (txtNombres.Text.Length == 0)
                    {
                        MessageBox.Show("La Razón Social no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNombres.Focus();
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

                if (txtEmail.Text.Length > 0 && !isValidEmail(txtEmail.Text))
                {
                    MessageBox.Show("La dirección de email no es correcta, por favor verificar la información proporcionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }

                procesarCompra();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al procesar la compra.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Error al procesar la compra: " + ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void procesarCompra()
        {
            forma_pago = cboFormaPago.SelectedValue.ToString();

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

            bool existe_cliente = BL_Clientes.existeCliente(venta.cliente_doc);

            //save customer if doesnt exists
            if (!existe_cliente)
            {
                log.Info("Cliente " + txtDNI.Text + " no existe en la base de datos.", System.Reflection.MethodBase.GetCurrentMethod().Name);

                var confirm = MessageBox.Show("¿Desea guardar el cliente en el sistema?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    Ent_Clientes nuevo_cliente = new Ent_Clientes();
                    nuevo_cliente.dni = txtDNI.Text;
                    nuevo_cliente.nombres = txtNombres.Text;
                    nuevo_cliente.apellidos = txtApellidos.Text;
                    nuevo_cliente.direccion = txtDireccion.Text;
                    nuevo_cliente.telefono = txtTelefono.Text;
                    nuevo_cliente.email = txtEmail.Text;
                    nuevo_cliente.tipo = (tipo_venta == "FA") ? "E" : "N";

                    try
                    {
                        string _result = BL_Clientes.insertarCliente(nuevo_cliente);

                        if (_result == "1")
                        {
                            log.Info("Cliente " + nuevo_cliente.dni + " grabado con éxito.", System.Reflection.MethodBase.GetCurrentMethod().Name);
                        }
                        else
                        {
                            log.Error("Error al grabar cliente: " + _result, System.Reflection.MethodBase.GetCurrentMethod().Name);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al grabar al cliente, sin embargo, el proceso de compra continuará.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        log.Error("Error al grabar cliente: " + ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                }
                else
                {
                    log.Info("Cliente " + txtDNI.Text + " no se guardará en la base de datos.", System.Reflection.MethodBase.GetCurrentMethod().Name);
                }
            }

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                Ent_Productos prd = new Ent_Productos();
                prd.id = int.Parse(row.Cells["ID"].Value.ToString());
                prd.nombre = row.Cells["DESCRIPCION"].Value.ToString();
                prd.cantidad = int.Parse(row.Cells["CANTIDAD"].Value.ToString());
                prd.precio = float.Parse(row.Cells["PU"].Value.ToString());

                venta.lstProductos.Add(prd);
            }

            try
            {
                string result = BL_Ventas.procesarVenta(venta);

                if (result == "1")
                {
                    MessageBox.Show("Venta Realizada con Éxito!.", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    log.Info("Venta " + lblSerie.Text + " realizada con éxito.", System.Reflection.MethodBase.GetCurrentMethod().Name);
                    string resumen = 
                        "\n-----------------------------------\n" +
                        "Resumen Venta:\n" +
                        "Serie: " + lblSerie.Text + "\n" +
                        "Tipo Venta: " + tipo_venta + "\n" +
                        "Forma de Pago: " + cboFormaPago.Text + "\n" +
                        "Cliente: " + txtDNI.Text + "\n" +
                        "Productos:\n";
                    foreach (DataGridViewRow item in dgvProductos.Rows)
                    {
                        resumen += "  - " + item.Cells["CODIGO"].Value.ToString() + " | " +
                            item.Cells["DESCRIPCION"].Value.ToString() + " | " +
                            item.Cells["CANTIDAD"].Value.ToString() + " | " +
                            item.Cells["PU"].Value.ToString() + " | " +
                            item.Cells["IMPORTE"].Value.ToString() + "\n";
                    }
                    resumen += 
                        "Subtotal: " + txtSubTotal.Text + "\n" +
                        "IGV: " + txtIGV.Text + "\n" +
                        "TOTAL: " + txtTotal.Text + "\n" +
                        "Recibido: " + txtRecibido.Text + "\n" +
                        "Vuelto: " + txtVuelto.Text + "\n" +
                        "-----------------------------------\n\n";
                    log.Info(resumen, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    reiniciarVenta();
                }
                else
                {
                    MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el proceso de compra.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Error en el proceso de compra: " + ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void cambiarTipoVenta(string tipo_venta_des)
        {
            try
            {
                correlativo = BL_Ventas.getCorrelativo(tipo_venta);
                lblTipoVenta.Text = tipo_venta_des;
                lblSerie.Text = "N° 001-" + correlativo;
            } catch(Exception ex)
            {
                log.Error("Error al obtener correlativo: " + ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            if (tipo_venta == "FA")
            {
                lblCliente.Text = "Razón Social:";
                lblDNI.Text = "R.U.C.:";

                txtApellidos.Visible = false;
                lblApellidos.Visible = false;
                txtNombres.Width = 328;
            }
            else
            {
                lblCliente.Text = "Cliente:";
                lblDNI.Text = "DNI:";

                txtApellidos.Visible = true;
                lblApellidos.Visible = true;
                txtNombres.Width = 122;
            }

            txtNombres.Text = String.Empty;
            txtDNI.Text = String.Empty;
            txtDireccion.Text = String.Empty;

            sumarTotal();

            log.Info("Cambio Tipo Venta: " + tipo_venta, System.Reflection.MethodBase.GetCurrentMethod().Name);
            log.Info("Serie " + lblSerie.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void menuAdmin()
        {
            if (ent_usuario.rango == "0")
            {
                sistemaToolStripMenuItem.Visible = false;
                menuTienda.Visible = false;
            }
        }

        private void txtRecibido_TextChanged(object sender, EventArgs e)
        {
            if (txtRecibido.Text.Length > 0)
            {
                if(forma_pago == "CR")
                {
                    txtVuelto.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtRecibido.Text)).ToString("#0.00");
                } else
                {
                    txtVuelto.Text = (Convert.ToDecimal(txtRecibido.Text) - Convert.ToDecimal(txtTotal.Text)).ToString("#0.00");
                }
            }
            else
            {
                txtVuelto.Text = "0.00";
            }
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarProducto frm = new frmAgregarProducto(cod_tienda, ent_usuario.username);
            frm.ShowDialog();
        }

        public void reiniciarVenta()
        {
            InicializarSistema();
            txtNombres.Text = String.Empty;
            txtApellidos.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            txtDNI.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            txtEmail.Text = String.Empty;
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
            frmMantenimientoProductos frm = new frmMantenimientoProductos(cod_tienda, ent_usuario.username);
            frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea salir?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                log.Info("Aplicación cerrada.", System.Reflection.MethodBase.GetCurrentMethod().Name);
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
            if (cboFormaPago.SelectedValue.ToString() == "CR")
            {
                lblRecibido.Text = "Restante";
                lblVuelto.Text = "Saldo";
                forma_pago = "CR";
            }
            else
            {
                lblRecibido.Text = "Recibido";
                lblVuelto.Text = "Vuelto";
                forma_pago = "CO";
            }

            txtRecibido_TextChanged(null, EventArgs.Empty);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static bool isValidEmail(string email)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, sFormato))
            {
                if (Regex.Replace(email, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void créditosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCreditos frm = new frmCreditos(cod_tienda, ent_usuario.username);
            frm.ShowDialog();
        }

        private void listadoDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListadoVentas frm = new frmListadoVentas(cod_tienda, ent_usuario.username);
            frm.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = new frmUsuarios();
            frm.ShowDialog();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPagoProveedores frm = new frmPagoProveedores(ent_usuario.username);
            frm.ShowDialog();
        }

        private void dptosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepositoCta frm = new frmDepositoCta(ent_usuario.username);
            frm.ShowDialog();
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoCategorias frm = new frmMantenimientoCategorias();
            frm.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoCliente frm = new frmMantenimientoCliente();
            frm.ShowDialog();
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaVentas frm = new frmConsultaVentas(cod_tienda);
            frm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSalir_Click(null, EventArgs.Empty);
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaVentaCliente frm = new frmConsultaVentaCliente();
            frm.ShowDialog();
        }

        private void stockDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteStockProducto frm = new frmReporteStockProducto();
            frm.ShowDialog();
        }
    }
}
