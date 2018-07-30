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
    public partial class FrmSplash : Form
    {
        public FrmSplash()
        {
            InitializeComponent();
        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {
            Clase_Conexion con = new Clase_Conexion();
            con.Conectar();
            if(con.Estado_Conexion == 0)
            {
                MessageBox.Show("No se ha establecido la conexión con el servidor", "Conexión con el servidor", MessageBoxButtons.OK);
            }
            else
            {
               
            }
        }

        private void FrmSplash_MouseClick(object sender, MouseEventArgs e)
        {
   
            FrmLogin contrasenia = new FrmLogin();
            contrasenia.Visible = true;
        }
    }
}
