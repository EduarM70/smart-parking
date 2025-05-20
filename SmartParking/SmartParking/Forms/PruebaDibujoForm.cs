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

namespace SmartParking
{
    public partial class PruebaDibujoForm : Form
    {
         static CGrafo grafo = new CGrafo();
        public PruebaDibujoForm()
        {
            InitializeComponent();
           
            panel1.Paint += panel1_Paint;
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            CrearGrafoDePrueba(e.Graphics);
            List<CVfila> caminoPrueba = new List<CVfila>();
            grafo.DibujarCamino(e.Graphics, CrearGrafoDePrueba(e.Graphics));
           
            
        }

        public static List<CVfila> CrearGrafoDePrueba(Graphics e)
        {
            // Crear el grafo
            //entrada
            CVfila entrada = new CVfila();
            grafo.AgregarFila(entrada);
            // Agregar filas (vértices)

            CVfila fila1 = grafo.Agregarfila("Fila1", new Point(80, 70), 'u');
            CVfila fila2 = grafo.Agregarfila("Fila2", new Point(80, 95),'d');
            CVfila fila3 = grafo.Agregarfila("Fila3", new Point(80, 145),'u');
            CVfila fila4 = grafo.Agregarfila("Fila4", new Point(80, 170),'d');
            CVfila fila5 = grafo.Agregarfila("Fila5", new Point(80, 220),'u');
            // Agregar calles entre las filas (vértices)
            grafo.AgregarCalle(fila1, fila2, 10);     // Calle de fila1 a fila2
            grafo.AgregarCalle(fila2, fila3, 20);    // Calle de fila2 a fila3
            grafo.AgregarCalle(fila3, fila4, 30);   // Calle de fila3 a fila4
            grafo.AgregarCalle(fila4, fila5, 40);  // Calle de fila4 a fila5

            grafo.DibujarGrafoPrueba(e);
            List<CVfila> caminoPrueba = new List<CVfila>();
           caminoPrueba.Add(entrada);
            caminoPrueba.Add(fila3);
            caminoPrueba.Add(fila4);
      //      caminoPrueba.Add(fila1);
       //     caminoPrueba.Add(fila1);
            return  caminoPrueba;

        }
    }
}
