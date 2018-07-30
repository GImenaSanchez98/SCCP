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
                Comando.Parameters.AddWithValue("Nombres", String.Format("{0}", txtNombres.Text));
                Comando.Parameters.AddWithValue("Apellidos", String.Format("{0}", txtApellidos.Text));
                Comando.Parameters.AddWithValue("Direccion", String.Format("{0}", txtDireccion.Text));
                Comando.Parameters.AddWithValue("Correo", String.Format("{0}", txtCorreo.Text));
                Comando.Parameters.AddWithValue("Especialidad", String.Format("{0}", CmbEspecialidad.Text));

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
            s = MessageBox.Show("¿Está Seguro que desea guardar los datos?", "Control de pacientes", MessageBoxButtons.YesNo);
            if (s == DialogResult.Yes)
            {
                cargar_datos("sp_EditarMedico");

            }
            else
            {
                limpiar();
            }
        }

        private void btninhabilitar_Click(object sender, EventArgs e)
        {
            DialogResult s;
            s = MessageBox.Show("¿Está Seguro que desea inhabilitar Especialidad?", "Control de Especialidades", MessageBoxButtons.YesNo);
            if (s == DialogResult.Yes)
            {
                cargar_datos("sp_InhabilitarMedico");

            }
            else
            {
                limpiar();
            }
        }

        private void MtxtIdentidad_Leave(object sender, EventArgs e)
        {
            Clase_Conexion con = new Clase_Conexion();
            String m;
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_ListarMedico");
                Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", MtxtIdentidad.Text));


                Comando.Parameters.Add("Nombres", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Apellidos", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Direccion", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Correo", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Especialidad", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Msj", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.ExecuteNonQuery();

                m = Comando.Parameters["msj"].Value.ToString();
                txtNombres.Text = Comando.Parameters["Nombres"].Value.ToString();
                txtApellidos.Text = Comando.Parameters["Apellidos"].Value.ToString();
                txtDireccion.Text = Comando.Parameters["Direccion"].Value.ToString();
                txtCorreo.Text = Comando.Parameters["Correo"].Value.ToString();
                CmbEspecialidad.Text = Comando.Parameters["Especialidad"].Value.ToString();


                Comando.Dispose();
                // Evaluamos si el paciente existe
                // m == null -- si existe
                // m != null ---no existe
                if (m == null || m == "")
                {

                    btnguardar.Enabled = false;
                    btnactualizar.Enabled = true;
                    btninhabilitar.Enabled = true;
                }
                else
                {
                    if (m != "El medico no se encuetra registrado")
                    {
                        MessageBox.Show(m);
                    }
                    else
                    {
                        btnguardar.Enabled = true;
                        btnactualizar.Enabled = false;
                        btninhabilitar.Enabled = false;
                    }


                }

            }
            catch (MySqlException ex)
            {
                m = "Excepcion de tipo " + ex.GetType().ToString() +
                        "\n" + ex.ToString() +
                        " fue encontrado al ejecutar consulta.";
            }
        }
    }
}
