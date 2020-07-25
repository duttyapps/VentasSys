using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;
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
    public partial class frmCotizacion : Form
    {
        private Ent_Configuracion ent_configuracion;
        private Ent_Tienda _ent_tienda;
        public double total;
        private string cod_tienda { get; set; }
        private string tipo_venta { get; set; }
        private string usuario { get; set; }
        private string alquiler { get; set; }
        private string correlativo { get; set; }
        private string adjunto { get; set; }

        public frmCotizacion(String tienda, String user, Ent_Tienda ent_tienda)
        {
            InitializeComponent();
            fillMonedas();
            _ent_tienda = ent_tienda;
            ent_configuracion = new Ent_Configuracion();
            ent_configuracion = BL_Configuracion.getConfiguracion();
            ent_tienda = BL_Tienda.getTienda(ent_configuracion.TIENDA);
            correlativo = BL_Mantenimiento.getCorrelativo();
            lblSerie.Text = "N° 001-" + correlativo.PadLeft(6, '0');
            tipo_venta = "FA";
            cod_tienda = tienda;
            usuario = user;
            Image logo = Image.FromFile("logo.png");
            pbLogo.Image = logo;
            adjunto = "";

            Dictionary<string, string> lista_tipo = new Dictionary<string, string>();
            lista_tipo.Add("CO", "COMPRA");
            lista_tipo.Add("AL", "ALQUILER");
            cboTipo.DataSource = new BindingSource(lista_tipo, null);
            cboTipo.DisplayMember = "Value";
            cboTipo.ValueMember = "Key";
            alquiler = "0";
            lbldias.Visible = false;
            txtDias.Visible = false;
            txtDias.Text = "1";
        }

        public void fillMonedas()
        {
            List<Object> items = new List<Object>();
            items.Add(new { id = "PEN", desc = "Soles" });
            items.Add(new { id = "USD", desc = "Dólares" });

            cboMoneda.DataSource = items;
            cboMoneda.ValueMember = "id";
            cboMoneda.DisplayMember = "desc";
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBuscarCliente frm = new frmBuscarCliente(String.Empty, "nombre");
            frm.ShowDialog();

            if (frm.ent_cliente != null)
            {
                txtDesCliente.Text = (frm.ent_cliente.nombres == null) ? "" : frm.ent_cliente.nombres + " " + frm.ent_cliente.apellidos;
                txtDesRuc.Text = (frm.ent_cliente.dni == null) ? "" : frm.ent_cliente.dni;
                txtEmail.Text = (frm.ent_cliente.email == null) ? "" : frm.ent_cliente.email;
            }
        }

        private void btnBuscarRuc_Click(object sender, EventArgs e)
        {
            frmBuscarCliente frm = new frmBuscarCliente(String.Empty, "dni");
            frm.ShowDialog();

            if (frm.ent_cliente != null)
            {
                txtDesCliente.Text = (frm.ent_cliente.nombres == null) ? "" : frm.ent_cliente.nombres;
                txtDesRuc.Text = (frm.ent_cliente.dni == null) ? "" : frm.ent_cliente.dni;
                txtEmail.Text = (frm.ent_cliente.email == null) ? "" : frm.ent_cliente.email;
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            frmBuscarProducto frm = new frmBuscarProducto(cod_tienda, alquiler);
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
                        dgvProductos.Rows.Add(frm.ent_producto.cod_producto, frm.ent_producto.nombre, "1", frm.ent_producto.precio.ToString("#0.00"), frm.ent_producto.precio.ToString("#0.00"), frm.ent_producto.id);
                    }
                }
                else
                {
                    dgvProductos.Rows.Add(frm.ent_producto.cod_producto, frm.ent_producto.nombre, "1", frm.ent_producto.precio.ToString("#0.00"), frm.ent_producto.precio.ToString("#0.00"), frm.ent_producto.id);
                }

            }

            sumarTotal();
        }

        private void sumarTotal()
        {
            try
            {
                total = Int32.Parse(txtDias.Text) * dgvProductos.Rows.Cast<DataGridViewRow>()
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
                }
                else
                {
                    btnAgregarProducto.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                //log.Error("Error al SUMAR TOTAL: " + ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                        if (confirm == DialogResult.Yes)
                        {
                            dgvProductos.Rows.RemoveAt(item.Index);
                            sumarTotal();
                            //log.Info("Producto removido: [" + item.Cells[0].Value + "] " + item.Cells[1].Value, System.Reflection.MethodBase.GetCurrentMethod().Name);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al quitar el producto. \n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //log.Error("Error al quitar el producto: " + ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            frmAgregarCliente frm = new frmAgregarCliente();
            frm.ShowDialog();
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

                if (txtDesRuc.Text.Length <= 0)
                {
                    MessageBox.Show("El DNI o RUC esta vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }

                if (txtDesCliente.Text.Length <= 0)
                {
                    MessageBox.Show("El nombre o razon social esta vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }

                if (txtEmail.Text.Length <= 0 && !isValidEmail(txtEmail.Text))
                {
                    MessageBox.Show("La dirección de email no es correcta, por favor verificar la información proporcionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }

                procesarCotizacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al procesar la compra.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void procesarCotizacion()
        {
            Ent_Venta venta = new Ent_Venta();

            venta.cod_tienda = cod_tienda;
            venta.tipo_venta = tipo_venta;
            venta.cantidad = sumarCantidad();
            venta.cliente_doc = txtDesRuc.Text;
            venta.emision = DateTime.Now.ToString("dd/MM/yyyy");
            venta.cliente = txtDesCliente.Text;
            venta.email = txtEmail.Text;
            venta.usuario = usuario;
            venta.tipo_cotizacion = cboTipo.SelectedValue.ToString();
            venta.dias_alquiler = int.Parse(txtDias.Text);
            venta.monto_subtotal = double.Parse(txtSubTotal.Text);
            venta.monto_igv = double.Parse(txtIGV.Text);
            venta.monto_total = total;
            venta.denominacion = txtDenominación.Text;
            venta.observacion = txtObservacion.Text;
            venta.moneda = cboMoneda.SelectedValue.ToString();

            bool existe_cliente = BL_Clientes.existeCliente(venta.cliente_doc);

            //save customer if doesnt exists
            if (!existe_cliente)
            {
                var confirm = MessageBox.Show("¿Desea guardar el cliente en el sistema?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    Ent_Clientes nuevo_cliente = new Ent_Clientes();
                    nuevo_cliente.dni = txtDesRuc.Text;
                    nuevo_cliente.nombres = txtDesCliente.Text;
                    nuevo_cliente.apellidos = "";
                    nuevo_cliente.direccion = "";
                    nuevo_cliente.telefono = "";
                    nuevo_cliente.email = txtEmail.Text;
                    nuevo_cliente.tipo = "P";
                    nuevo_cliente.posible = "1";

                    try
                    {
                        string _result = BL_Clientes.insertarCliente(nuevo_cliente);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al grabar al cliente, sin embargo, el proceso de compra continuará.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {

                }
            }

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                Ent_Productos prd = new Ent_Productos();
                prd.cod_producto = row.Cells["CODIGO"].Value.ToString();
                prd.id = int.Parse(row.Cells["ID"].Value.ToString());
                prd.nombre = row.Cells["DESCRIPCION"].Value.ToString();
                prd.cantidad = int.Parse(row.Cells["CANTIDAD"].Value.ToString());
                prd.precio = float.Parse(row.Cells["PU"].Value.ToString());
                prd.monto_total = float.Parse(row.Cells["IMPORTE"].Value.ToString());

                venta.lstProductos.Add(prd);
            }

            try
            {
                string id_cab = "";
                string result = BL_Ventas.procesarCotizacion(venta, out id_cab);

                venta.id_cab = Convert.ToInt32(id_cab);

                Email email = new Email();
                email.Send_Email(venta, _ent_tienda, ent_configuracion, txtObservacion.Text, adjunto);

                if (result == "1")
                {
                    MessageBox.Show("Cotización Realizada con Éxito!.", "Cotización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InvoicePDF pdf = new InvoicePDF();
                    pdf.createCotizacion(ent_configuracion, venta);
                    reiniciarVenta();
                }
                else
                {
                    MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el proceso de cotización.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                return 0;
            }
        }

        public void reiniciarVenta()
        {
            txtDesRuc.Text = String.Empty;
            txtDesCliente.Text = String.Empty;
            txtEmail.Text = String.Empty;
            dgvProductos.Rows.Clear();
            txtTotal.Text = "0.00";
            txtIGV.Text = "0.00";
            txtSubTotal.Text = "0.00";
            btnAgregarProducto.Enabled = true;
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

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedValue.ToString() == "CO")
            {
                alquiler = "0";
                lbldias.Visible = false;
                txtDias.Visible = false;
                txtDias.Text = "1";
            }
            else
            {
                alquiler = "1";
                lbldias.Visible = true;
                txtDias.Visible = true;
                txtDias.Text = "1";
            }
        }

        private void txtDias_TextChanged(object sender, EventArgs e)
        {
            sumarTotal();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            ofd.FileName = String.Empty;
            ofd.ShowDialog();
            if(ofd.CheckFileExists)
            {
                adjunto = ofd.FileName;
                txtAdjunto.Text = ofd.FileName;
            }
        }
    }
}
