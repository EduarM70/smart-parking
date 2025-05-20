using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartParking
{
    public partial class PruebaDibujoForm : Form
    {
        static CGrafo grafo = new CGrafo();

        //Solución a la duplicación de  nodod:
        bool grafoInicializado = false;

        bool entradaDerechaAgregada = false;




        public PruebaDibujoForm()
        {
            InitializeComponent();

            panel1.Paint += panel1_Paint;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (!grafoInicializado)
            {

                InicializarGrafo(grafo);
                grafoInicializado = true;


            }

            grafo.DibujarGrafoPrueba(e.Graphics);
            DibujarRutaEjemplo(grafo, e.Graphics);




        }


        //Metodo para el bloque derechO:
        // Construye el bloque derecho (bloque C o D) del estacionamiento con 6 filas y 5 espacios por fila
        // Ajuste final del bloque derecho con más espacio entre filas intermedias e inferiores
        // Reconstrucción final del bloque derecho con nodo entrada conectado visualmente
        // Reconstrucción final del bloque derecho con UN solo nodo de entrada correctamente posicionado y conectado
        public static void InicializarGrafo(CGrafo grafo)
        {

            // Nodo de entrada único ubicado frente al pasillo derecho
            //CVfila entrada = new CVfila("Entrada", new Point(510, 160), 'n');
            //grafo.AgregarFila(entrada);

            // Filas del bloque derecho
            CVfila f1d = grafo.Agregarfila("F1_D", new Point(390, 70), 'u');
            CVfila f2d = grafo.Agregarfila("F2_D", new Point(390, 95), 'd');
            CVfila f3d = grafo.Agregarfila("F3_D", new Point(390, 140), 'u');
            CVfila f4d = grafo.Agregarfila("F4_D", new Point(390, 170), 'd');
            CVfila f5d = grafo.Agregarfila("F5_D", new Point(390, 220), 'u');
            CVfila f6d = grafo.Agregarfila("F6_D", new Point(390, 250), 'd');

            //filas del bloque izquierdo
            CVfila f1i = grafo.Agregarfila("F1_I", new Point(80, 70), 'u');
            CVfila f2i = grafo.Agregarfila("F2_I", new Point(80, 95), 'd');
            CVfila f3i = grafo.Agregarfila("F3_I", new Point(80, 145), 'u');
            CVfila f4i = grafo.Agregarfila("F4_I", new Point(80, 170), 'd');
            CVfila f5i = grafo.Agregarfila("F5_I", new Point(80, 220), 'u');
            CVfila f6i = grafo.Agregarfila("F6_I", new Point(80, 245), 'd');

            // Conectar las filas con calles verticales
            grafo.AgregarCalle(f1d, f2d, 1);
            grafo.AgregarCalle(f2d, f3d, 0);
            grafo.AgregarCalle(f3d, f4d, 1);
            grafo.AgregarCalle(f4d, f5d, 0);
            grafo.AgregarCalle(f5d, f6d, 1);

            grafo.AgregarCalle(f1i, f2i, 1);
            grafo.AgregarCalle(f2i, f3i, 0);
            grafo.AgregarCalle(f3i, f4i, 1);
            grafo.AgregarCalle(f4i, f5i, 0);
            grafo.AgregarCalle(f5i, f6i, 1);

            //AGREGAR NODO DE LA ENTRADA DERECHA

            // Nodo de entrada visual al lado derecho (posición exacta)
            CVfila entradaD = new CVfila("Entrada", new Point(550, 120), 'n');

            entradaD.espacios = null;

            grafo.AgregarFila(entradaD);

            // Conectar con la fila 3 del bloque derecho

            grafo.AgregarCalle(entradaD, f3d, 1);


            //AGREGAR NODO DE LA ENTRADA IZQUIERDA

            // Coordenada ajustada para que encaje visualmente en el centro del pasillo izquierdo
            CVfila entradaI = new CVfila("EntradaIzquierda", new Point(15, 165), 'n');

            entradaI.espacios = null;

            grafo.AgregarFila(entradaI);

            // Conectar a la fila 3 del bloque izquierdo


            grafo.AgregarCalle(entradaI, f3i, 1);

            //conectar bloques

            grafo.AgregarCalle(f3i, f3d, 19);
            grafo.AgregarCalle(f5i, f5d, 10);
        }



        // // // // // // // // // //
        //PARTE DE CAMINOS Y RUTA MÁS CORTA:

        // Dibuja un camino desde una entrada hacia una fila destino por Dijkstra (simulado manualmente)
        public static void DibujarRutaEjemplo(CGrafo grafo, Graphics g)
        {
            // Buscar nodo de entrada izquierda
            CVfila entrada = grafo.nodos.Find(f => f.BloqueFila == "EntradaIzquierda");


            CVfila f3_izq = grafo.nodos.Find(f => f.BloqueFila == "F3_I");
            CVfila f3_der = grafo.nodos.Find(f => f.BloqueFila == "F3_D");
            CVfila f5_der = grafo.nodos.Find(f => f.BloqueFila == "F5_D");

            // Validar que todos existan, esperemos que si xd
            if (entrada != null && f3_izq != null && f3_der != null && f5_der != null)
            {
                List<CVfila> camino = new List<CVfila>
                 {
                     entrada,
                     f3_izq,
                     f3_der,
                     f5_der
                 };

                // Buscar la posición más cercana disponible en F5_D 
                //pipipipip
                int espacioFinal = f5_der.PosicionDisponibleCercano(entrada.Coordenada);

                if (espacioFinal == -1) espacioFinal = 1; // p


                grafo.DibujarCamino(g, camino, espacioFinal);
            }
        }



        private void PruebaDibujoForm_Load(object sender, EventArgs e)
        {

        }



        //Yo por aqui no paso...
    }
}
