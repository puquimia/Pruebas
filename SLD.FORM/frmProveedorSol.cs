using SLD.LIB.O.SOL.LO.Productos;
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
    public partial class frmProveedorSol : Form
    {
        public ProveedorProducto eProveedorProducto;
        public Producto eProducto;
        public frmProveedorSol(Producto eProducto)
        {
            InitializeComponent();
            this.eProveedorProducto = new ProveedorProducto();
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
            eProveedorProducto.CSku = eProducto.CSku;
            eProveedorProducto.CNmbProveedor = txbNombreProveedor.Text;
            eProveedorProducto.RegistrarProveedorProducto();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
