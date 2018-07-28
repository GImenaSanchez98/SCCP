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
    public partial class FrmMedicos : Form
    {
        public FrmMedicos()
        {
            InitializeComponent();
        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limpiar()
        {
            MtxtIdentidad.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            CmbEspecialidad.Text = "";


        }
        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (MtxtIdentidad.Text == "" || txtNombres.Text == "" || txtApellidos.Text == "" || txtDireccion.Text == "" || txtCorreo.Text == "" || CmbEspecialidad.Text == "")

            {
                MessageBox.Show("Se requiere que complete la informacion", "Control de Medicos", MessageBoxButtons.OK);
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
                    Comando.CommandText = String.Format("sp_AgregarMedico");
                    Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", MtxtIdentidad.Text));
                    Comando.Parameters.AddWithValue("Nombres", String.Format("{0}", txtNombres.Text));
                    Comando.Parameters.AddWithValue("Apellidos", String.Format("{0}", txtApellidos.Text));
                    Comando.Parameters.AddWithValue("Direccion", String.Format("{0}", txtDireccion.Text));
                    Comando.Parameters.AddWithValue("Correo", String.Format("{0}", txtCorreo.Text));
                    Comando.Parameters.AddWithValue("Especialidad", String.Format("{0}", CmbEspecialidad.Text));

                    //Comando.Parameters.AddWithValue("Especialidad", String.Format("{0}", textBox7.Text));

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
