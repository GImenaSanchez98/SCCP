using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Proyecto_Clinica
{
    public partial class FrmPacientes : Form
    {
        public FrmPacientes()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Cierra el formulario paciente y regresa la menu principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnregresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Load Carga todo los elemento y llamamos a la función limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        public void limpiar()
        {
            maskedTextBox1.Text = "";
            textBox2.Text = "";
        }
        private void FrmPacientes_Load(object sender, EventArgs e)
        {
            limpiar();
            maskedTextBox1.Focus();
        }
        /// <summary>
        /// Función limpiar se encarga de vaciar los textbox y inicializar los valores iniciales.
        /// </summary>
       

        /// <summary>
        /// Llama al procedimiento de guardar y almacena los datos en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "" || textBox2.Text == "")
                
            {
                MessageBox.Show("Debe de ingresar la identidad y nombres del paciente", "Control de pacientes", MessageBoxButtons.OK);
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Debe de seleccionar un genero", "Control de pacientes", MessageBoxButtons.OK);

            }
            else if(comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe de seleccionar un estado civil", "Control de pacientes", MessageBoxButtons.OK);
            }
            else
            {
                cargar_datos("sp_AgregarPaciente");
            }
        }
        /// <summary>
        /// Se encarga de cargar todos los datos de un paciente en el formulario si este existe en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            Clase_Conexion con = new Clase_Conexion();
            String m;
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_listarPaciente");
                Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", maskedTextBox1.Text));


                Comando.Parameters.Add("Nombre", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Apellido", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Direccion", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Genero", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Estado", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Correo", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Nace", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.ExecuteNonQuery();


                textBox2.Text = Comando.Parameters["Nombre"].Value.ToString();
                m = Comando.Parameters["msj"].Value.ToString();
                textBox3.Text = Comando.Parameters["Apellido"].Value.ToString();
                textBox4.Text = Comando.Parameters["Direccion"].Value.ToString();
                string es = Comando.Parameters["Genero"].Value.ToString();
                if (es == "M")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                comboBox1.SelectedItem = Comando.Parameters["Estado"].Value.ToString();
                textBox5.Text = Comando.Parameters["Correo"].Value.ToString();
                dateTimePicker1.Text = Comando.Parameters["Nace"].Value.ToString();
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
                    if (m != "El paciente no se encuetra registrado")
                    {
                        MessageBox.Show(m);
                        limpiar();
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

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            DialogResult s;
            s= MessageBox.Show("¿Está Seguro que desea guardar los datos?", "Control de pacientes", MessageBoxButtons.YesNo);
            if(s == DialogResult.Yes)
            {
                cargar_datos("sp_EditarPaciente");

            }
            else
            {
                limpiar();
            }


        }
        private void cargar_datos(string s)
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
                Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", maskedTextBox1.Text));
                Comando.Parameters.AddWithValue("Nombre", String.Format("{0}", textBox2.Text));
                Comando.Parameters.AddWithValue("Apellido", String.Format("{0}", textBox3.Text));
                Comando.Parameters.AddWithValue("Direccion", String.Format("{0}", textBox4.Text));
                if (radioButton1.Checked == true)
                {
                    Comando.Parameters.AddWithValue("Genero", String.Format("M"));
                }
                else
                {
                    Comando.Parameters.AddWithValue("Genero", String.Format("F"));
                }
                Comando.Parameters.AddWithValue("Estado", String.Format("{0}", comboBox1.SelectedItem.ToString()));
                Comando.Parameters.AddWithValue("Correo", String.Format("{0}", textBox5.Text));
                Comando.Parameters.AddWithValue("Nace", String.Format("{0}", dateTimePicker1.Value.Date.ToString()));

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


        private void btninhabilitar_Click(object sender, EventArgs e)
        {
            DialogResult s;
            s = MessageBox.Show("¿Está Seguro que desea inhabilitar al paciente?", "Control de pacientes", MessageBoxButtons.YesNo);
            if (s == DialogResult.Yes)
            {
                cargar_datos("sp_InhabilitarPaciente");

            }
            else
            {
                limpiar();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAntecedentesPaciente nuevo = new FrmAntecedentesPaciente();
            nuevo.ShowDialog();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
