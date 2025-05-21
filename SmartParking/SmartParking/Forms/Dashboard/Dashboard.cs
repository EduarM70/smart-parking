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
        public string entrada;

        // Pantalla del MapaCompleto
        public Map1 mapaCompleto;

        // 

        public DashboardForm()
        {
            InitializeComponent();

            if (Session.CurrentUser != null && Session.CurrentUser.Id != 0)
            {
                welcomeUser.Text = $"Bienvenido {Session.CurrentUser.Nombre}";

                mapaCompleto = new Map1(this);

                // Configurar el Timer
                timer1.Interval = 5000; // cada 5 segundo
                timer1.Tick += timer1_Tick;
                timer1.Start();

                // barras de progreso
                progressBarLibres.Minimum = 0;
                progressBarLibres.Maximum = 100;
                progressBarLibres.Value = 0;
                progressBarLibres.Increment(1);

                progressBarOcupados.Minimum = 0;
                progressBarOcupados.Maximum = 100;
                progressBarOcupados.Value = 0;
                progressBarOcupados.Increment(1);
            }
            else
            {
                MessageBox.Show("Deber iniciar Sesión para contar el acceso", "No tienes acceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }

            
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            CultureInfo cultura = new CultureInfo("es-ES");

            string nombreDia = cultura.DateTimeFormat.GetDayName(fechaActual.DayOfWeek).ToLower();
            string nombreMes = cultura.DateTimeFormat.GetMonthName(fechaActual.Month).ToLower();

            lblDate.Text = $"Hoy {nombreDia} {fechaActual.Day} de {nombreMes} de {fechaActual.Year}";

            // otbnener las cantidades actualizadas de un 
            if (mapaCompleto != null)
            {
                actualizarEstadoZonas();
            }

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
                        entrada = "Norte";
                        break;
                    case 1:
                        entrada = "Oeste";
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
                int entradaZona = cmbEntradaZB.SelectedIndex;

                switch (entradaZona)
                {
                    case 0:
                        entrada = "Sur";
                        break;
                    case 1:
                        entrada = "Oeste";
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
                int entradaZona = cmdEntradasZC.SelectedIndex;

                switch (entradaZona)
                {
                    case 0:
                        entrada = "Norte";
                        break;
                    case 1:
                        entrada = "Este";
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
                int entradaZona = cmbEntradaZD.SelectedIndex;

                switch (entradaZona)
                {
                    case 0:
                        entrada = "Sur";
                        break;
                    case 1:
                        entrada = "Este";
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

        private void actualizarEstadoZonas()
        {
            // Para zona A
            int totalZonaA = mapaCompleto.mapaParqueo.totZona("A");
            txtZonaATotal.Text = totalZonaA.ToString();

            int espaciosDisponiblesA = mapaCompleto.mapaParqueo.totDisponiblesZona("A");
            txtZADisponibles.Text = espaciosDisponiblesA.ToString();

            int ocupadosA = mapaCompleto.mapaParqueo.totOcupadosZona("A");
            txtOcupadosA.Text = ocupadosA.ToString();

            // Para zona B
            int totalZonaB = mapaCompleto.mapaParqueo.totZona("B");
            txtZonaBTotal.Text = totalZonaB.ToString();

            int espaciosDisponiblesB = mapaCompleto.mapaParqueo.totDisponiblesZona("B");
            txtZBDisponibles.Text = espaciosDisponiblesB.ToString();

            int ocupadosB = mapaCompleto.mapaParqueo.totOcupadosZona("B");
            txtOcupadosB.Text = ocupadosB.ToString();

            // Para zona C
            int totalZonaC = mapaCompleto.mapaParqueo.totZona("C");
            txtZonaCTotal.Text = totalZonaC.ToString();

            int espaciosDisponiblesC = mapaCompleto.mapaParqueo.totDisponiblesZona("C");
            txtZCDisponibles.Text = espaciosDisponiblesC.ToString();

            int ocupadosC = mapaCompleto.mapaParqueo.totOcupadosZona("C");
            txtOcupadosC.Text = ocupadosC.ToString();

            // Para zona D
            int totalZonaD = mapaCompleto.mapaParqueo.totZona("D");
            txtZonaDTotal.Text = totalZonaD.ToString();

            int espaciosDisponiblesD = mapaCompleto.mapaParqueo.totDisponiblesZona("D");
            txtZDDisponibles.Text = espaciosDisponiblesD.ToString();

            int ocupadosD = mapaCompleto.mapaParqueo.totOcupadosZona("D");
            txtOcupadosD.Text = ocupadosD.ToString();


            // totalizar estacionamientos

            int totalEstacionamientos = totalZonaA + totalZonaB + totalZonaC + totalZonaD;
            int totalLibres = espaciosDisponiblesA + espaciosDisponiblesB + espaciosDisponiblesC + espaciosDisponiblesD;
            int totalOcupados = ocupadosA + ocupadosB + ocupadosC + ocupadosD;

            lblTotalParqueos.Text = totalEstacionamientos.ToString();
            lblTotalCarros.Text = totalOcupados.ToString();
            lblTotalLibres.Text = totalLibres.ToString();
            lblTotalOcupados.Text = totalOcupados.ToString();

            // actualizar las barras de estado
            int barIncrementeLibres = (100 * totalLibres) / totalEstacionamientos;
            int barIncrementeOcupados = (100 * totalOcupados) / totalEstacionamientos;

            progressBarLibres.Value = barIncrementeLibres;
            progressBarOcupados.Value = barIncrementeOcupados;

            // Actualizar labels

            lblPorcentajeDisponible.Text = $"Libres {barIncrementeLibres.ToString()}% del estacionamiento";
            lblPorcentajeOcupa.Text = $"Ocupados {barIncrementeOcupados.ToString()}% del estacionamiento";

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            actualizarEstadoZonas();
        }
    }
}
