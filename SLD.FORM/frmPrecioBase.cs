using SLD.LIB.O.PRO.LO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLD.FORM
{
    public partial class frmPrecioBase : Form
    {
        public Producto eProducto;
        public frmPrecioBase(Producto producto)
        {
            InitializeComponent();
            eProducto = producto;
            lblNombreProducto.Text = eProducto.CNombre;
            lblPrecioActual.Text = eProducto.NPrecioLista.ToString("N2");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txbPrecio.Text))
                {
                    MessageBox.Show(" - Debe especificar un precio", "Nuevo precio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                eProducto.NPrecioLista = Convert.ToDecimal(txbPrecio.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
