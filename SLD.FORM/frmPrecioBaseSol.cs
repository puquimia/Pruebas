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
    public partial class frmPrecioBaseSol : Form
    {
        PrecioProducto ePrecioProducto;
        public Producto eProducto;
        public frmPrecioBaseSol(Producto eProducto)
        {
            InitializeComponent();
            lblNombreProducto.Text = eProducto.CNombre;
            lblPrecioActual.Text = eProducto.NPrecioLista.ToString("N2");
            ePrecioProducto = new PrecioProducto();
            this.eProducto = eProducto;
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

                ePrecioProducto.CSku = eProducto.CSku;
                ePrecioProducto.NPrecioLista = Convert.ToDecimal(txbPrecio.Text);
                ePrecioProducto.RegistrarPrecioBaseProducto();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
