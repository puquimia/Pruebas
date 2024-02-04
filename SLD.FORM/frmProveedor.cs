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
    public partial class frmProveedor : Form
    {
        public Producto eProducto;
        public frmProveedor(Producto eProducto)
        {
            InitializeComponent();
            this.eProducto = eProducto;
            lblNombreProducto.Text = eProducto.CNombre;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombreProveedor.Text))
            {
                MessageBox.Show(" - Debe especificar un proveedor", "Nuevo Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            eProducto.CNmbProveedor = txbNombreProveedor.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txbNombreProveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNombreProducto_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
