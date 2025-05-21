using SmartParking.Forms.Dashboard;
using SmartParking.Services;
using SmartParking.Services.Maps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartParking.Forms.Maps
{
    public partial class Map1 : Form
    {
        public ParkingMap mapaParqueo = new ParkingMap();

        public string Entrada { get; set; }
        public char Zona { get; set; }

        private DashboardForm formularioAnterior;

        private bool dibujarRuta = false;

        public Map1(DashboardForm formularioAnterior)
        {
            InitializeComponent();

            // Configurar el Timer
            timer1.Interval = 1000; // 1 segundo
            timer1.Tick += timer1_Tick;
            timer1.Start();

            // Mostrar fecha y hora al cargar el formulario
            ActualizarFechaYHora();

            mapaParqueo.MapaCompleto(); // solo crea el grafo pero no lo dibuja la inicio

            this.formularioAnterior = formularioAnterior;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ActualizarFechaYHora();

            ActualizarParqueos();
        }

        private void ActualizarFechaYHora()
        {
            DateTime ahora = DateTime.Now;

            // Formatear la hora: "12:45:30" (o el formato que prefieras)
            lblHora.Text = ahora.ToString("HH:mm");
        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel8_Click(object sender, EventArgs e)
        {

        }

        private void Map1_Load(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            CultureInfo cultura = new CultureInfo("es-ES");

            string nombreDia = cultura.DateTimeFormat.GetDayName(fechaActual.DayOfWeek).ToLower();
            string nombreMes = cultura.DateTimeFormat.GetMonthName(fechaActual.Month).ToLower();

            lblDate2.Text = $"Hoy {nombreDia} {fechaActual.Day} de {nombreMes} de {fechaActual.Year}";

            // Colocar información de las zonas y las entradas:

            lblZona.Text = Zona.ToString().ToUpper();
            lblEntraZona.Text = $"Entrada {Entrada} {Zona.ToString().ToUpper()}";

            ActualizarParqueos();
        }

        public void PictureBoxMap_Paint(object sender, PaintEventArgs e)
        {
            mapaParqueo.MapaCompleto(e.Graphics);

            if (dibujarRuta)
            {
                mapaParqueo.grafo.DibujarCamino(e.Graphics, mapaParqueo.rutaMasCercano, mapaParqueo.numEstacionamiento);

            }
        }

        public void ActualizarParqueos()
        {
            int totalEspacios = mapaParqueo.totZona(Zona.ToString().ToUpper());
            int totalDisponibles = mapaParqueo.totDisponiblesZona(Zona.ToString().ToUpper());
            int totalOcupados = mapaParqueo.totOcupadosZona(Zona.ToString().ToUpper());

            lblTotalEspacios.Text = totalEspacios.ToString();
            lblOcupados.Text = totalOcupados.ToString();
            lblDisponibles.Text = totalDisponibles.ToString();

        }


        private void guna2Button2_Click(object sender, EventArgs e) // Boton de registro de entrada
        {
            FormEntrada entrada = new FormEntrada(mapaParqueo, PictureBoxMap);

            entrada.ShowDialog();

        }

        private void guna2Button1_Click(object sender, EventArgs e) // Boton para registrar salida
        {
            FormSalida salida = new FormSalida(mapaParqueo, PictureBoxMap);

            salida.ShowDialog();
        }

        private void btnRecorrido_Click(object sender, EventArgs e)
        {
            string nombre_entrada = $"entrada{Zona.ToString().ToUpper()}_{Entrada}";

            MessageBox.Show(nombre_entrada);

            mapaParqueo.RutaMasCorta(nombre_entrada); // "entradaA_W"

            dibujarRuta = true;

            PictureBoxMap.Refresh();

            dibujarRuta = false;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();

            this.Hide();

            loginForm.ShowDialog(formularioAnterior);
        }
    }
}
