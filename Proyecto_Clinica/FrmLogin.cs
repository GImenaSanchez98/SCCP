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
            FrmMenuPrincipal nuevo = new FrmMenuPrincipal();
            this.Hide();
            nuevo.Visible = true;
        }

        private void limpiar()
        {
            txtId.Text = "";
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            txtUsuario.Focus();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtUsuario.Text == "" || txtContrasena.Text == "")

            {
                MessageBox.Show("Debe de ingresar todos los datos solicitados", "Acceso", MessageBoxButtons.OK);
            }
            else
            {
                Clase_Conexion con = new Clase_Conexion();
                String m;
                con.Conectar();
                MySqlCommand Comando = con.Conexion.CreateCommand();
                Comando.Connection = con.Conexion;
                try
                {
                    //msj.ms_ok(ComDepartamento.SelectedValue.ToString());
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.CommandText = String.Format("sp_AgregarUsuario");
                    Comando.Parameters.AddWithValue("CodigoU", String.Format("{0}", txtUsuario.Text));
                    Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", txtUsuario.Text));
                    Comando.Parameters.AddWithValue("Clave", String.Format("{0}", txtContrasena.Text));

                    Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                    m = Comando.Parameters["msj"].Value.ToString();
                    Comando.Dispose();
                    limpiar();
                }
                catch (MySqlException ex)
                {
                    m = "Excepcion de tipo " + ex.GetType().ToString() +
                            "\n" + ex.ToString() +
                            " fue encontrado al ejecutar consulta.";
                }
                MessageBox.Show(m);
            }
        }

        private void btnAccesar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtUsuario.Text == "" || txtContrasena.Text == "")

            {
                MessageBox.Show("Debe de ingresar todos los datos solicitados", "Acceso", MessageBoxButtons.OK);
            }
            else
            {
                Clase_Conexion con = new Clase_Conexion();
                String m;
                con.Conectar();
                MySqlCommand Comando = con.Conexion.CreateCommand();
                Comando.Connection = con.Conexion;
                try
                {
                    //msj.ms_ok(ComDepartamento.SelectedValue.ToString());
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.CommandText = String.Format("sp_AccesoUsuario");
                    Comando.Parameters.AddWithValue("CodigoU", String.Format("{0}", txtUsuario.Text));
                    Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", txtUsuario.Text));
                    Comando.Parameters.AddWithValue("Clave", String.Format("{0}", txtContrasena.Text));

                    Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                    m = Comando.Parameters["msj"].Value.ToString();
                    Comando.Dispose();
                    limpiar();

                    FrmMenuPrincipal MP = new FrmMenuPrincipal();
                    MP.Show();
                }
                catch (MySqlException ex)
                {
                    m = "Excepcion de tipo " + ex.GetType().ToString() +
                            "\n" + ex.ToString() +
                            " fue encontrado al ejecutar consulta.";
                }
                MessageBox.Show(m);
            }
        }
    }
}
