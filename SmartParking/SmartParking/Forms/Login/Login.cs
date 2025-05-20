using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartParking.Data;


namespace SmartParking.Forms
{
    public partial class Login : Form
    {
        // Para cargar fuentes desde recursos si es necesario
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        private Font interRegular;
        private Font interBold;

        //llmar el metodo de conexion a la base de datos
        ConexionDB conexionDB = new ConexionDB();

        public Login()
        {
            InitializeComponent();
            LoadCustomFont();            
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string user = txtusuario.Text;
            string pass = txtPass.Text;

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("los campos o uno de los campos esta vacio.");
            }

            conexionDB.ConectarBase();
            try
            {


                string queryCliente = "SELECT COUNT(*) FROM Administrador WHERE usuario = @user AND Contrasena = @pass";
                SqlCommand cmdCliente = new SqlCommand(queryCliente, conexionDB.ConectarBase());
                cmdCliente.Parameters.AddWithValue("@user", user);
                cmdCliente.Parameters.AddWithValue("@pass", pass);

                int esCliente = (int)cmdCliente.ExecuteScalar();

                if (esCliente > 0)
                {
                    MessageBox.Show($"Bienvenido {user}");
                    this.Hide();
                    PruebaDibujoForm frm1 = new PruebaDibujoForm();
                    frm1.ShowDialog();
                    this.Close();
                    return;
                }
            }

           
            catch (Exception ex)
            {
                MessageBox.Show("error usuario no encontrado", ex.Message);
            }

        }
    }
}
