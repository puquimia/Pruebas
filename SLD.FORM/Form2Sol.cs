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
    public partial class Form2Sol : Form
    {
        Producto eProducto;
        public Form2Sol()
        {
            InitializeComponent();
            eProducto = new Producto();
            CargarProductos();
        }

        void CargarProductos()
        {
            dgvProductos.DataSource = eProducto.Listar();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            using (frmNuevoProductoSol frm = new frmNuevoProductoSol(eProducto))
            {
                DialogResult resultado = frm.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    eProducto.Registrar();
                    CargarProductos();
                    MessageBox.Show("Se registro el producto correctamente.", "Nuevo registro");
                }
            }
        }

        private void btnRegistrarPrecioBase_Click(object sender, EventArgs e)
        {
            try
            {
                Producto eProducto = (Producto)this.dgvProductos.CurrentRow.DataBoundItem;
                using (frmPrecioBaseSol frm = new frmPrecioBaseSol(eProducto))
                {
                    DialogResult resultado = frm.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        CargarProductos();
                        MessageBox.Show("Se registro el precio correctamente.", "Precio de producto");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegistrarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                Producto eProducto = (Producto)this.dgvProductos.CurrentRow.DataBoundItem;
                using (frmProveedorSol frm = new frmProveedorSol(eProducto))
                {
                    DialogResult resultado = frm.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        CargarProductos();
                        MessageBox.Show("Se registro el proveedor correctamente.", "Proveedor");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
