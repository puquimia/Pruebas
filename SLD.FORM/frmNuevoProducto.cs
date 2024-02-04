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
    public partial class frmNuevoProducto : Form
    {
        public Producto eProducto;
        public frmNuevoProducto(Producto eProducto)
        {
            InitializeComponent();
            this.eProducto = eProducto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> lMensajes = new List<string>();
            if (string.IsNullOrEmpty(txbCodigo.Text))
            {
                lMensajes.Add(" - Debe especificar un codigo.");
            }
            if (string.IsNullOrEmpty(txbNombre.Text))
                lMensajes.Add(" - Debe especificar un nombre.");
            if (string.IsNullOrEmpty(txbCodigoFabricante.Text))
                lMensajes.Add(" - Debe especificar un codigo de fabricante.");
            if (string.IsNullOrEmpty(txbNombreFabricante.Text))
                lMensajes.Add(" - Debe especificar un nombre fabricante.");
            if (string.IsNullOrEmpty(txbPeso.Text))
                lMensajes.Add(" - Debe especificar un peso.");
            if (string.IsNullOrEmpty(txbCUM.Text))
                lMensajes.Add(" - Debe especificar un CUM.");
            if (string.IsNullOrEmpty(txbPrecio.Text))
                lMensajes.Add(" - Debe especificar un precio.");

            if(lMensajes.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, lMensajes), "Nuevo producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            eProducto.CSku = txbCodigo.Text;
            eProducto.CSku = txbCodigo.Text;
            eProducto.CNombre = txbNombre.Text;
            eProducto.CSkuFabricante = txbCodigoFabricante.Text;
            eProducto.CNmbFabricante = txbNombreFabricante.Text;
            eProducto.CNmbProveedor = txbNombreProveedor.Text;
            eProducto.NPeso = Convert.ToDecimal(txbPeso.Text);
            eProducto.CUM = txbCUM.Text;
            eProducto.NPrecioLista = Convert.ToDecimal(txbPrecio.Text);
            eProducto.CCodBarra = txbcodigoBarra.Text;
            eProducto.CSkuAlternante = "ADB";

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
