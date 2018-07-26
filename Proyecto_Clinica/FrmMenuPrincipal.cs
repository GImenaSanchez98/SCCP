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
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           DialogResult s =  MessageBox.Show("¿Está Seguro que desea salir del sistema?", "Confirmación", MessageBoxButtons.YesNoCancel);
            if (s == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ejecutarlimpieza();
            FrmPacientes nuevo = new FrmPacientes();
            nuevo.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ejecutarlimpieza();
            FrmExpedientes nuevo = new FrmExpedientes();
            nuevo.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ejecutarlimpieza();
            FrmInvetarioMedicina nuevo = new FrmInvetarioMedicina();
            nuevo.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ejecutarlimpieza();
            mostrarPersonal();
        }
        private void mostrarPersonal()
        {
            btnenfermeras.Visible = true;
            btnmedicos.Visible = true;
        }
        private void ocultarPersonal()
        {
            btnenfermeras.Visible = false;
            btnmedicos.Visible = false;
        }
        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            ocultarPersonal();
            ocultarMantenimiento();
        }

        private void btnmedicos_Click(object sender, EventArgs e)
        {
            ocultarPersonal();
            FrmMedicos nuevo = new FrmMedicos();
            nuevo.ShowDialog();
        }

        private void btnenfermeras_Click(object sender, EventArgs e)
        {
            ocultarPersonal();
            FrmPersonal nuevo = new FrmPersonal();
            nuevo.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ejecutarlimpieza();
            mostrarMantenimiento();
        }

        private void ocultarMantenimiento()
        {
            btncuentas.Visible = false;
            btnpresentacion.Visible = false;
            btnespecialidad.Visible = false;
            btnmedicamentos.Visible = false;
        }

        private void mostrarMantenimiento()
        {
            btncuentas.Visible = true;
            btnpresentacion.Visible = true;
            btnespecialidad.Visible = true;
            btnmedicamentos.Visible = true;
        }

        private void btnlaboratorios_Click(object sender, EventArgs e)
        {
            ocultarMantenimiento();
        }

        private void btnespecialidad_Click(object sender, EventArgs e)
        {
            ocultarMantenimiento();
            FrmEspecialidad nuevo = new FrmEspecialidad();
            nuevo.ShowDialog();

        }

        private void btncuentas_Click(object sender, EventArgs e)
        {
            ocultarMantenimiento();
        }

        private void btnpresentacion_Click(object sender, EventArgs e)
        {
            ejecutarlimpieza();
            FrmPresentacion nuevo = new FrmPresentacion();
            nuevo.ShowDialog();
        }

        private void ejecutarlimpieza()
        {
            ocultarPersonal();
            ocultarMantenimiento();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ejecutarlimpieza();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmAcercade nuevo = new FrmAcercade();
            nuevo.ShowDialog();
        }
    }
}
