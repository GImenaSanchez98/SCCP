using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Proyecto_Clinica
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void limpiar()
        {
            MtxtIdentidad.Text = "";
            txtClave.Text = "";
            cmbNivelAcceso.Text = "";
            MtxtIdentidad.Focus();

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (MtxtIdentidad.Text == "" || txtClave.Text == "" || cmbNivelAcceso.Text == "")
            {
                MessageBox.Show("Debe de completar el registro", "Control de Usuarios", MessageBoxButtons.OK);

            }
            else
            {
                cargar_datos("sp_AgregarUsuario");
            }
        }

        public void cargar_datos(string s)
        {
            Clase_Conexion con = new Clase_Conexion();
            String m;
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format(s);
                Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", MtxtIdentidad.Text));
                Comando.Parameters.AddWithValue("Clave", String.Format("{0}", txtClave.Text));
                Comando.Parameters.AddWithValue("NivelAcceso", String.Format("{0}", cmbNivelAcceso.Text));
                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                m = Comando.Parameters["msj"].Value.ToString();
                Comando.Dispose();
                limpiar();
                btnguardar.Enabled = true;
            }
            catch (MySqlException ex)
            {
                m = "Excepcion de tipo " + ex.GetType().ToString() +
                        "\n" + ex.ToString() +
                        " fue encontrado al ejecutar consulta.";
            }
            MessageBox.Show(m);
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            DialogResult s;
            s = MessageBox.Show("¿Está Seguro que desea guardar los datos?", "Control de Especialidades", MessageBoxButtons.YesNo);
            if (s == DialogResult.Yes)
            {
                cargar_datos("sp_EditarUsuario");

            }
            else
            {
                limpiar();
            }
        }

        private void btninhabilitar_Click(object sender, EventArgs e)
        {
            DialogResult s;
            s = MessageBox.Show("¿Está Seguro que desea inhabilitar Usuario?", "Control de Usuarios", MessageBoxButtons.YesNo);
            if (s == DialogResult.Yes)
            {
                cargar_datos("sp_InhabilitarUsuario");

            }
            else
            {
                limpiar();
            }
        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
