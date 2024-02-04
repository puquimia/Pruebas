using SLD.LIB.O.PRO.LO;
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
    public partial class Form1 : Form
    {
        public LIB.O.PRO.LO.Producto eProducto  = null;
        #region Eventos
        public Form1()
        {
            InitializeComponent();
            eProducto = new LIB.O.PRO.LO.Producto();
            CargarProductosProblema();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmNuevoProducto frm = new frmNuevoProducto(eProducto))
                {
                    DialogResult resultado = frm.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        eProducto.RegistrarProducto();
                        CargarProductosProblema();
                        MessageBox.Show("Se registro el producto correctamente.", "Nuevo registro");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegistrarPrecioBase_Click(object sender, EventArgs e)
        {
            try
            {
                LIB.O.PRO.LO.Producto eProducto = (LIB.O.PRO.LO.Producto)this.dgvProductos.CurrentRow.DataBoundItem;
                using (frmPrecioBase frm = new frmPrecioBase(eProducto))
                {
                    DialogResult resultado = frm.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        eProducto.RegistrarPrecioBaseProducto();
                        CargarProductosProblema();
                        MessageBox.Show("Se registro el producto correctamente.", "Nuevo registro");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegistrarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                LIB.O.PRO.LO.Producto eProducto = (LIB.O.PRO.LO.Producto)this.dgvProductos.CurrentRow.DataBoundItem;
                using (frmProveedor frm = new frmProveedor(eProducto))
                {
                    DialogResult resultado = frm.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        eProducto.RegistrarProveedorProducto();
                        CargarProductosProblema();
                        MessageBox.Show("Se registro el producto correctamente.", "Nuevo registro");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Metodos
        void CargarProductosProblema()
        {
            dgvProductos.DataSource = eProducto.TraerProductos();
        }
        #endregion
    }
}
