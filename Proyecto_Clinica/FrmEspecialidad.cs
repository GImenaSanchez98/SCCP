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
    public partial class FrmEspecialidad : Form
    {
        public FrmEspecialidad()
        {
            InitializeComponent();
        }


        private void limpiar()
        {
            txtCodigo.Text = "";
            txtEspecialidad.Text = "";
            txtCodigo.Focus();

        }



        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "" || txtEspecialidad.Text == "")

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
                    Comando.CommandText = String.Format("sp_AgregarEspecialidad");
                    Comando.Parameters.AddWithValue("Codigo", String.Format("{0}", txtCodigo.Text));
                    Comando.Parameters.AddWithValue("Especialidad", String.Format("{0}", txtEspecialidad.Text));

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

        private void btnactualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
