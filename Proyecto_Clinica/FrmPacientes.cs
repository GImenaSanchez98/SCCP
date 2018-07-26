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

        private void btnregresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPacientes_Load(object sender, EventArgs e)
        {

        }

        private void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.SelectedIndex = -1;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox1.Focus();

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                
            {
                MessageBox.Show("Debe de ingresar la identidad y nombre del paciente", "Control de pacientes", MessageBoxButtons.OK);
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
                Clase_Conexion con = new Clase_Conexion();
                String m;
                con.Conectar();
                MySqlCommand Comando = con.Conexion.CreateCommand();
                Comando.Connection = con.Conexion;
                try
                {
                    //msj.ms_ok(ComDepartamento.SelectedValue.ToString());
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.CommandText = String.Format("sp_AgregarPaciente");
                    Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", textBox1.Text));
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
                    Comando.Parameters.AddWithValue("Estado", String.Format("{0}",comboBox1.SelectedItem.ToString()));
                    Comando.Parameters.AddWithValue("Correo", String.Format("{0}", textBox5.Text));
                    Comando.Parameters.AddWithValue("Nace", String.Format("{0}",dateTimePicker1.Value.Date));

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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
