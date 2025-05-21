using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using SmartParking.Models;
using SmartParking.Forms.Maps;

namespace SmartParking.Forms.Dashboard
{
    public partial class DashboardForm : Form
    {
        public char zona;
        public char entrada;

        // Pantalla del MapaCompleto
        public Map1 mapaCompleto;

        public DashboardForm()
        {
            InitializeComponent();

            if (Session.CurrentUser.Id != 0)
            {
                welcomeUser.Text = $"Bienvenido {Session.CurrentUser.Nombre}";
                mapaCompleto = new Map1();
            }
            else
            {
                MessageBox.Show("Deber iniciar Sesión para contar el acceso", "No tienes acceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            CultureInfo cultura = new CultureInfo("es-ES");

            string nombreDia = cultura.DateTimeFormat.GetDayName(fechaActual.DayOfWeek).ToLower();
            string nombreMes = cultura.DateTimeFormat.GetMonthName(fechaActual.Month).ToLower();

            lblDate.Text = $"Hoy {nombreDia} {fechaActual.Day} de {nombreMes} de {fechaActual.Year}";
        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel18_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel19_Click(object sender, EventArgs e)
        {

        }

        private void guna2ContainerControl5_Click(object sender, EventArgs e)
        {

        }

        private void guna2ContainerControl6_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel28_Click(object sender, EventArgs e)
        {

        }

        private void btnZonaA_Click(object sender, EventArgs e)
        {
            zona = 'A';

            if (cmbEntradaZA.SelectedIndex != -1) // validar que el usuario seleccione una entrada
            {
                int entradaZona = cmbEntradaZA.SelectedIndex;

                switch (entradaZona)
                {
                    case 0:
                        entrada = 'N';
                        break;
                    case 1:
                        entrada = 'E';
                        break;
                }

                this.Hide(); // ocultar el formulario

                // mostrar nuevo formulario y pasar parametros

                mapaCompleto.Zona = zona;
                mapaCompleto.Entrada = entrada;

                mapaCompleto.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una entreda para identificar la posición del mapa");
            }

        }

        private void btnZonaB_Click(object sender, EventArgs e)
        {
            zona = 'B';

            if (cmbEntradaZB.SelectedIndex != -1) // validar que el usuario seleccione una entrada
            {
                int entradaZona = cmbEntradaZA.SelectedIndex;

                switch (entradaZona)
                {
                    case 0:
                        entrada = 'S';
                        break;
                    case 1:
                        entrada = 'E';
                        break;
                }

                this.Hide(); // ocultar el formulario

                // mostrar nuevo formulario y pasar parametros

                mapaCompleto.Zona = zona;
                mapaCompleto.Entrada = entrada;

                mapaCompleto.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una entreda para identificar la posición del mapa");
            }
        }

        private void btnZonaC_Click(object sender, EventArgs e)
        {
            zona = 'C';

            if (cmdEntradasZC.SelectedIndex != -1) // validar que el usuario seleccione una entrada
            {
                int entradaZona = cmbEntradaZA.SelectedIndex;

                switch (entradaZona)
                {
                    case 0:
                        entrada = 'N';
                        break;
                    case 1:
                        entrada = 'E';
                        break;
                }

                this.Hide(); // ocultar el formulario

                // mostrar nuevo formulario y pasar parametros

                mapaCompleto.Zona = zona;
                mapaCompleto.Entrada = entrada;

                mapaCompleto.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una entreda para identificar la posición del mapa");
            }
        }

        private void btnZonaD_Click(object sender, EventArgs e)
        {
            zona = 'D';

            if (cmbEntradaZD.SelectedIndex != -1) // validar que el usuario seleccione una entrada
            {
                int entradaZona = cmbEntradaZA.SelectedIndex;

                switch (entradaZona)
                {
                    case 0:
                        entrada = 'S';
                        break;
                    case 1:
                        entrada = 'E';
                        break;
                }

                this.Hide(); // ocultar el formulario

                // mostrar nuevo formulario y pasar parametros

                mapaCompleto.Zona = zona;
                mapaCompleto.Entrada = entrada;

                mapaCompleto.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una entreda para identificar la posición del mapa");
            }
        }
    }
}
