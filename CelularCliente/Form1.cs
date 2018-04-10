using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CelularCliente
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente tt = new frmCliente();
            tt.MdiParent = this;
            tt.Show();
        }

        private void celularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCelular tt = new frmCelular();
            tt.MdiParent = this;
            tt.Show();
        }

        private void clienteCelularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClienteCelular tt = new ClienteCelular();
            tt.MdiParent = this;
            tt.Show();
        }
    }
}
