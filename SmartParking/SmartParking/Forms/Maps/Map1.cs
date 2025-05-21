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

        public char Entrada { get; set; }
        public char Zona { get; set; }

        public Map1()
        {
            InitializeComponent();

            // Configurar el Timer
            timer1.Interval = 1000; // 1 segundo
            timer1.Tick += timer1_Tick;
            timer1.Start();

            // Mostrar fecha y hora al cargar el formulario
            ActualizarFechaYHora();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ActualizarFechaYHora();
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
        }

        private void PictureBoxMap_Paint(object sender, PaintEventArgs e)
        {
            mapaParqueo.MapaCompleto(e.Graphics);

            //List<CVfila> caminoPrueba = new List<CVfila>();

            //mapaParqueo.Grafo.DibujarCamino(e.Graphics, mapaParqueo.CrearGrafoDePrueba(e.Graphics));
        }
    }
}
