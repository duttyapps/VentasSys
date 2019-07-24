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
    public partial class frmIngresoAlmacen : Form
    {
        private string cod_tienda { get; set; }
        private string usuario { get; set; }
        public frmIngresoAlmacen(string tienda, String user)
        {
            InitializeComponent();
            cod_tienda = tienda;
            usuario = user;
            txtFechaEmision.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Image logo = Image.FromFile("logo.png");
            pbLogo.Image = logo;

            Dictionary<string, string> lista_tipo = new Dictionary<string, string>();
            //lista_tipo.Add("V", "VENTA");
            lista_tipo.Add("M", "MANTENIMIENTO");
            lista_tipo.Add("T", "TALLER");
            cboTipo.DataSource = new BindingSource(lista_tipo, null);
            cboTipo.DisplayMember = "Value";
            cboTipo.ValueMember = "Key";

            //lblFechaSalida.Visible = false;
            //dtpFechaSalida.Visible = false;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            frmBuscarProducto frm = new frmBuscarProducto(cod_tienda, "0");
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
                            //log.Info("Producto removido: [" + item.Cells[0].Value + "] " + item.Cells[1].Value, System.Reflection.MethodBase.GetCurrentMethod().Name);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al quitar el producto. \n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedValue.ToString() == "V")
            {
                lblFechaSalida.Visible = false;
                dtpFechaSalida.Visible = false;
            }
            else
            {
                lblFechaSalida.Visible = true;
                dtpFechaSalida.Visible = true;
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
                
                procesarIngresarAlmacen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al procesar la compra.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void procesarIngresarAlmacen()
        {
            Ent_Venta venta = new Ent_Venta();

            venta.cod_tienda = cod_tienda;
            venta.cantidad = sumarCantidad();
            venta.usuario = usuario;
            venta.tipo_ingreso_almacen = cboTipo.SelectedValue.ToString();
            venta.fecha_fin = dtpFechaSalida.Value.ToString("dd/MM/yyyy");
            
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
                string result = BL_Ventas.procesarIngresoAlmacen(venta);

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
            catch (Exception ex)
            {
                MessageBox.Show("Error en el proceso de compra.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void reiniciarVenta()
        {
            dgvProductos.Rows.Clear();
            btnAgregarProducto.Enabled = true;
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


    }
}
