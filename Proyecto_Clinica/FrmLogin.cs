using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Clinica
{
    public partial class FrmLogin : Form 
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void FrmLogin_MouseClick(object sender, MouseEventArgs e)
        {
            // solo con un click
                    }

        private void label1_Click(object sender, EventArgs e)
        {
            FrmSplash nuevos = new FrmSplash();
            FrmMenuPrincipal nuevo = new FrmMenuPrincipal();
            this.Hide();
            nuevo.Visible = true;
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
