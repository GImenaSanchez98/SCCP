namespace Proyecto_Clinica
{
    partial class FrmReceta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtcodigoreceta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btneliminar = new System.Windows.Forms.Button();
            this.btnagregar = new System.Windows.Forms.Button();
            this.txtprescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericcabtidad = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnbuscarmedicamento = new System.Windows.Forms.Button();
            this.txtnombremedicamento = new System.Windows.Forms.TextBox();
            this.txtcodigomedicamento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnactualizarreceta = new System.Windows.Forms.Button();
            this.btnregresar = new System.Windows.Forms.Button();
            this.btnguardar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnactualizar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericcabtidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtcodigoreceta
            // 
            this.txtcodigoreceta.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodigoreceta.Location = new System.Drawing.Point(153, 67);
            this.txtcodigoreceta.Name = "txtcodigoreceta";
            this.txtcodigoreceta.Size = new System.Drawing.Size(152, 28);
            this.txtcodigoreceta.TabIndex = 62;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 18);
            this.label2.TabIndex = 61;
            this.label2.Text = "Codigo de Receta:\r\n";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnactualizar);
            this.groupBox1.Controls.Add(this.btneliminar);
            this.groupBox1.Controls.Add(this.btnagregar);
            this.groupBox1.Controls.Add(this.txtprescripcion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericcabtidad);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnbuscarmedicamento);
            this.groupBox1.Controls.Add(this.txtnombremedicamento);
            this.groupBox1.Controls.Add(this.txtcodigomedicamento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 205);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle Receta";
            // 
            // btneliminar
            // 
            this.btneliminar.Location = new System.Drawing.Point(512, 164);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(73, 30);
            this.btneliminar.TabIndex = 72;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.UseVisualStyleBackColor = true;
            // 
            // btnagregar
            // 
            this.btnagregar.Location = new System.Drawing.Point(339, 164);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(73, 30);
            this.btnagregar.TabIndex = 71;
            this.btnagregar.Text = "Agregar";
            this.btnagregar.UseVisualStyleBackColor = true;
            // 
            // txtprescripcion
            // 
            this.txtprescripcion.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprescripcion.Location = new System.Drawing.Point(118, 89);
            this.txtprescripcion.Multiline = true;
            this.txtprescripcion.Name = "txtprescripcion";
            this.txtprescripcion.Size = new System.Drawing.Size(388, 69);
            this.txtprescripcion.TabIndex = 70;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 18);
            this.label4.TabIndex = 69;
            this.label4.Text = "Prescripción";
            // 
            // numericcabtidad
            // 
            this.numericcabtidad.Location = new System.Drawing.Point(118, 58);
            this.numericcabtidad.Name = "numericcabtidad";
            this.numericcabtidad.Size = new System.Drawing.Size(68, 25);
            this.numericcabtidad.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 18);
            this.label3.TabIndex = 67;
            this.label3.Text = "Cantidad:";
            // 
            // btnbuscarmedicamento
            // 
            this.btnbuscarmedicamento.Location = new System.Drawing.Point(512, 24);
            this.btnbuscarmedicamento.Name = "btnbuscarmedicamento";
            this.btnbuscarmedicamento.Size = new System.Drawing.Size(73, 28);
            this.btnbuscarmedicamento.TabIndex = 66;
            this.btnbuscarmedicamento.Text = "Buscar";
            this.btnbuscarmedicamento.UseVisualStyleBackColor = true;
            // 
            // txtnombremedicamento
            // 
            this.txtnombremedicamento.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombremedicamento.Location = new System.Drawing.Point(262, 24);
            this.txtnombremedicamento.Name = "txtnombremedicamento";
            this.txtnombremedicamento.Size = new System.Drawing.Size(244, 28);
            this.txtnombremedicamento.TabIndex = 65;
            // 
            // txtcodigomedicamento
            // 
            this.txtcodigomedicamento.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodigomedicamento.Location = new System.Drawing.Point(118, 24);
            this.txtcodigomedicamento.Name = "txtcodigomedicamento";
            this.txtcodigomedicamento.Size = new System.Drawing.Size(138, 28);
            this.txtcodigomedicamento.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 63;
            this.label1.Text = "Medicamento:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 321);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(598, 96);
            this.dataGridView1.TabIndex = 64;
            // 
            // btnactualizarreceta
            // 
            this.btnactualizarreceta.Location = new System.Drawing.Point(279, 437);
            this.btnactualizarreceta.Name = "btnactualizarreceta";
            this.btnactualizarreceta.Size = new System.Drawing.Size(92, 44);
            this.btnactualizarreceta.TabIndex = 76;
            this.btnactualizarreceta.Text = "Actualizar";
            this.btnactualizarreceta.UseVisualStyleBackColor = true;
            // 
            // btnregresar
            // 
            this.btnregresar.Location = new System.Drawing.Point(535, 437);
            this.btnregresar.Name = "btnregresar";
            this.btnregresar.Size = new System.Drawing.Size(73, 44);
            this.btnregresar.TabIndex = 75;
            this.btnregresar.Text = "Regresar";
            this.btnregresar.UseVisualStyleBackColor = true;
            this.btnregresar.Click += new System.EventHandler(this.btnregresar_Click);
            // 
            // btnguardar
            // 
            this.btnguardar.Location = new System.Drawing.Point(181, 436);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(92, 44);
            this.btnguardar.TabIndex = 74;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(235, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 18);
            this.label5.TabIndex = 77;
            this.label5.Text = "Control de recetas";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(438, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(152, 28);
            this.textBox1.TabIndex = 79;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(348, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 18);
            this.label6.TabIndex = 78;
            this.label6.Text = "Expediente:";
            // 
            // btnactualizar
            // 
            this.btnactualizar.Location = new System.Drawing.Point(418, 164);
            this.btnactualizar.Name = "btnactualizar";
            this.btnactualizar.Size = new System.Drawing.Size(88, 30);
            this.btnactualizar.TabIndex = 73;
            this.btnactualizar.Text = "Modificar";
            this.btnactualizar.UseVisualStyleBackColor = true;
            // 
            // FrmReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 493);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnactualizarreceta);
            this.Controls.Add(this.btnregresar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtcodigoreceta);
            this.Controls.Add(this.label2);
            this.Name = "FrmReceta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de control de archivos clinicos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericcabtidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtcodigoreceta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.TextBox txtprescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericcabtidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnbuscarmedicamento;
        private System.Windows.Forms.TextBox txtnombremedicamento;
        private System.Windows.Forms.TextBox txtcodigomedicamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnactualizarreceta;
        private System.Windows.Forms.Button btnregresar;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnactualizar;
    }
}