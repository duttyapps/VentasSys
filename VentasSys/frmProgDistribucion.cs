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
    public partial class frmProgDistribucion : Form
    {
        public frmProgDistribucion()
        {
            InitializeComponent();
        }

        private void btnProgramar_Click(object sender, EventArgs e)
        {
            setDistribucion();
        }

        private void setDistribucion()
        {
            Ent_Distribucion ent = new Ent_Distribucion();
            ent.fecha = dtFecha.Value.ToShortDateString();
            ent.hora = dtHora.Value.ToShortTimeString();
            ent.destino = txtDestino.Text;
            ent.encargado = txtEncargado.Text;
            ent.detalle = txtDetalle.Text;

            
            string result = BL_Programacion.setDistribucion(ent);
            if (result == "1")
            {
                MessageBox.Show("¡Distribución programada exitosamente!", "Programar Distribución", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("¡Ocurrió un error al programar distribución!\n" + result, "Programar Distribución", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
