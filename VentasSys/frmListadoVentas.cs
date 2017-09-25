using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentasSys
{
    public partial class frmListadoVentas : Form
    {
        private string cod_tienda { get; set; }
        private string usuario { get; set; }
        public frmListadoVentas(string _cod_tienda, string _usuario)
        {
            InitializeComponent();
            cod_tienda = _cod_tienda;
            usuario = _usuario;
        }
    }
}
