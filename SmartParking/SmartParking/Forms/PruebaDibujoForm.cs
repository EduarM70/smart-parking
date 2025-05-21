using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartParking.Services;
using SmartParking.Services.Maps;

namespace SmartParking
{
    public partial class PruebaDibujoForm : Form
    {
        public ParkingMap mapaParqueo = new ParkingMap();

        int numEstacionamiento;
        List<CVfila> rutaMasCercano;
        bool caminoDibujar = false;
        bool grafoInicializado = false;
 
        public PruebaDibujoForm()
        {
            InitializeComponent();

            panel1.Paint += panel1_Paint;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            mapaParqueo.CrearGrafoDePrueba(e.Graphics);

            List<CVfila> caminoPrueba = new List<CVfila>();
            

            if (!grafoInicializado)
            {
                mapaParqueo.grafo.DibujarGrafoPrueba(e.Graphics);
                grafoInicializado = true;
            }
            if (caminoDibujar)
            {
                mapaParqueo.grafo.DibujarCamino(e.Graphics, rutaMasCercano, numEstacionamiento);
                caminoDibujar = false;
            }

        }

      

       

    }
}
