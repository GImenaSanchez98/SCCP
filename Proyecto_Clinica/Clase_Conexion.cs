﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Proyecto_Clinica
{
   public class Clase_Conexion
    {

        private MySqlConnection conexion;
        private String base_datos;
        private String servidor;
        private String usuario;
        private String contrasena;
        private int estado;
        private DataTable tabla;
        private DataSet dataset;
        private MySqlCommand comando;
        private MySqlDataAdapter adaptador;

        public Clase_Conexion()
        {
            conexion = new MySqlConnection();
            tabla = new DataTable();
            dataset = new DataSet();
            adaptador = new MySqlDataAdapter();
            base_datos = "sccp";
            servidor = "localhost";
            usuario = "programacion";
            contrasena = "gmn98";
            Conectar();
        }
        public Clase_Conexion(String bd, String ser, String usu, String pws)
        {
            conexion = new MySqlConnection();
            tabla = new DataTable();
            dataset = new DataSet();
            adaptador = new MySqlDataAdapter();
            base_datos = bd;
            servidor = ser;
            usuario = usu;
            contrasena = pws;
            Conectar();
        }

        ~Clase_Conexion()
        {
            conexion.Close();
            conexion.Dispose();
            tabla.Dispose();
            dataset.Dispose();
            adaptador.Dispose();
        }

        public MySqlConnection Conexion
        {
            get
            {
                Conectar();
                return conexion;
            }
            set
            {
            }
        }

        public DataTable Tabla_sql(String sql)
        {
            tabla.Reset();
            Conectar();
            if (Estado_Conexion == 1)
            {
                comando = conexion.CreateCommand();
                adaptador = new MySqlDataAdapter();
                try
                {
                    comando.Connection = conexion;
                    comando.CommandText = sql;
                    adaptador.SelectCommand = comando;
                    adaptador.Fill(tabla);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Excepcion de tipo " + ex.GetType().ToString() +
                        "\n" + ex.ToString() +
                        " fue encontrado al ejecutar consulta.");
                }
            }

            return tabla;
        }

        public DataSet Dataset_sql(String sql)
        {
            tabla.Reset();
            Conectar();
            comando = conexion.CreateCommand();
            try
            {
                comando.Connection = conexion;
                comando.CommandText = sql;
                adaptador.SelectCommand = comando;
                adaptador.Fill(dataset);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Excepcion de tipo " + ex.GetType().ToString() + "\n" + ex.ToString() + " fue encontrado al ejecutar consulta.");
            }
            return dataset;
        }

        public void Conectar()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
                conexion.ConnectionString = String.Format("Database={0};Server={1}; Uid={2};Pwd={3}; SslMode=none", base_datos, servidor, usuario, contrasena);
                conexion.Open();
                estado = 1;
            }
            catch (Exception ex)
            {
                estado = 0;
                MessageBox.Show("Excepcion de tipo " + ex.GetType().ToString() +
                        "\n" + ex.ToString() +
                        " fue encontrado al ejecutar consulta.");
            }
        }

        public int Estado_Conexion
        {
            get
            {
                return estado;
            }
        }

        public void Actualizar_Dataset()
        {
            dataset.Clear();
            adaptador.Fill(dataset);
        }
    }
}
