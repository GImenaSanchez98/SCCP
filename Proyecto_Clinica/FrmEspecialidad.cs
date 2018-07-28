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
            txtEspecialidad.Text = "";
            txtEspecialidad.Focus();

        }


        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (txtEspecialidad.Text == "")
            {
                MessageBox.Show("Debe de ingresar la Especialidad", "Control de Especialidades", MessageBoxButtons.OK);

            }
            else
            {
                cargar_datos("sp_AgregarEspecialidad");
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
                Comando.Parameters.AddWithValue("Especialidad", String.Format("{0}", txtEspecialidad.Text));
              
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
                cargar_datos("sp_EditarEspecialidad");

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
                cargar_datos("sp_InhabilitarEspecialidad");

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
