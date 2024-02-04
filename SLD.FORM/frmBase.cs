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
    public partial class frmBase : Form
    {
        public frmBase()
        {
            InitializeComponent();
        }

        private void btnEjemploProblema_Click(object sender, EventArgs e)
        {
            using (Form1 frm = new Form1())
            {
                frm.ShowDialog();
            }
        }

        private void btnEjemploSolucion_Click(object sender, EventArgs e)
        {
            using (Form2Sol frm = new Form2Sol())
            {
                frm.ShowDialog();
            }
        }
    }
}
