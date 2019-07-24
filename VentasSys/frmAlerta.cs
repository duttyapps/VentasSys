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
    public partial class frmAlerta : Form
    {
        string cod_tienda { get; set; }

        public frmAlerta(string tienda)
        {
            InitializeComponent();
            cod_tienda = tienda;

            fillTrx();
            fillProduct();
        }

        void fillTrx() {

            List<Ent_Venta> lista = BL_Ventas.get_CotizacionAlerta();
            foreach(Ent_Venta venta in lista){
                dgvCotizacion.Rows.Add(venta.emision, venta.cliente_doc, venta.cliente, venta.telefono, venta.tipo_cotizacion, venta.dias_alquiler, venta.cantidad, venta.monto_total);
            }
        }

        void fillProduct()
        {
            List<Ent_Productos> lista = BL_Productos.get_ProductoAlerta();
            foreach (Ent_Productos prod in lista)
            {
                dgvProducto.Rows.Add(prod.id, prod.nombre, prod.costo, prod.precio, prod.stock);
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
