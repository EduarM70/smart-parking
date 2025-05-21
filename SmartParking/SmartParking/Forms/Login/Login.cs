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
using SmartParking.Forms.Dashboard;
using SmartParking.Forms.Maps;
using SmartParking.Models;
using SmartParking.Services.User;


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

        // clase de autentificacion
        AuthService authService = new AuthService();

        // anterior Dashboard
        private DashboardForm formularioAnteriorDash;

        public Login(DashboardForm formularioAnteriorDash = null)
        {
            InitializeComponent();
            LoadCustomFont();
            
            this.formularioAnteriorDash = formularioAnteriorDash;
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

            if (authService.Login(user, pass))
            {
                User authUser = authService.ObtenerUsuario(user);

                Session.CurrentUser = authUser; // usuario autentificado

                // abrir pantalla de dashboard
                this.Hide();

                

                if (formularioAnteriorDash != null)
                {
                    formularioAnteriorDash.ShowDialog();
                }
                else
                {
                    DashboardForm dashboard = new DashboardForm();
                    dashboard.ShowDialog();
                }                

                this.Close();

                return;
            }

            MessageBox.Show("El usuario o la contraseña son incorrectas", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
