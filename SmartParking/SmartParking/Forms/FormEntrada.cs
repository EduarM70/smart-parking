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

namespace SmartParking.Forms
{
    public partial class FormEntrada : Form
    {
        public static DateTime horaEntrada;
        Password pass = new Password();
        ConexionDB conexionDB;
        public FormEntrada()
        {
            InitializeComponent();
            btnIngresar.Enabled = false;
            conexionDB = new ConexionDB();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            lbCod.Text = pass.GenerarPassword();
            btnIngresar.Enabled = true;
            btnGenerar.Enabled = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            horaEntrada = DateTime.Now;
            lbfechaentrada.Text = horaEntrada.ToString();
            MessageBox.Show("Bienvenido, al mandado va");

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
