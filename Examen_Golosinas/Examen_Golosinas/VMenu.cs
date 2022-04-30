using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Examen_Golosinas
{
    public partial class VMenu : Syncfusion.Windows.Forms.Office2010Form
    {
        public VMenu()
        {
            InitializeComponent();
        }

        VUsuarios vus = null;
        VProducto vpr = null;
        private void tsbUsuarios_Click(object sender, EventArgs e)
        {
            if (vus == null)
            {
                vus = new VUsuarios();
                vus.MdiParent = this;
                vus.Show();
            }
            else
            {
                vus.Activate();
            }
        }

        private void tsbProductos_Click(object sender, EventArgs e)
        {
            if (vpr == null)
            {
                vpr = new VProducto();
                vpr.MdiParent = this;
                vpr.Show();
            }
        }
    }
}
