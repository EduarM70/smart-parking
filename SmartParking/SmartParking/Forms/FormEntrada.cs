using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SmartParking.Data;
using SmartParking.Services;
using SmartParking.Models;
using SmartParking.Services.User;
using System.Runtime.InteropServices;

namespace SmartParking.Forms
{
    public partial class FormEntrada : Form
    {
        public static DateTime horaEntrada;
        Password pass = new Password();
        ConexionDB conexionDB;

        // Para cargar fuentes desde recursos si es necesario
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        private Font interRegular;
        private Font interBold;
        public FormEntrada()
        {
            InitializeComponent();
            btnIngresar.Enabled = false;
            conexionDB = new ConexionDB();
        }
        private void LoadCustomFont()
        {
            try
            {
                // Intenta cargar la fuente Inter (debe estar instalada en el sistema)
                interRegular = new Font("Inter", 10f);
                interBold = new Font("Inter", 12f, FontStyle.Bold);
            }
            catch
            {
                // Fallback a fuentes estándar si Inter no está disponible
                interRegular = new Font("Arial", 10f);
                interBold = new Font("Arial", 12f, FontStyle.Bold);
                MessageBox.Show("La fuente 'Inter' no está instalada en el sistema. Se usará Arial como alternativa.",
                              "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            lbCod.Text = pass.GenerarPassword();
            btnIngresar.Enabled = true;
            btnGenerar.Enabled = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            

        }

private void guna2Button1_Click(object sender, EventArgs e)
        {
            lbCod.Text = pass.GenerarPassword();
            btnIngresar.Enabled = true;
            btnGenerar.Enabled = false;
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            horaEntrada = DateTime.Now;
            lbfechaentrada.Text = horaEntrada.ToString();
            MessageBox.Show("Bienvenido, a nuestro Estacionamiento");

            FormSalida salida = new FormSalida();
            salida.Show();
            this.Hide();



            // PARTE DE GUARDADO EN LA BASE DE DATOS

            string id = lbCod.Text;


            conexionDB.ConectarBase();
            try
            {
                string query = "INSERT INTO Registro_ingreso(codigo, Fecha_ingreso)" +
                    "VALUES(@cod, @fechaIngreso)";
                SqlCommand cmd = new SqlCommand(query, conexionDB.ConectarBase());
                cmd.Parameters.AddWithValue("@cod", id);
                cmd.Parameters.AddWithValue("@fechaIngreso", horaEntrada);
                int filasAfectadas = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en la DB");
            }
        }
    }
}
