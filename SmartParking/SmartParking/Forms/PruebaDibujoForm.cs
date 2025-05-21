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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace SmartParking
{
    public partial class PruebaDibujoForm : Form
    {
        static CGrafo grafo = new CGrafo();

        //Solución a la duplicación de  nodod:
        bool grafoInicializado = false;
        Floyd_Warshall floyd; //para llamar métodos de Floyd_Warshall

        public PruebaDibujoForm()
        {
            InitializeComponent();
            InicializarGrafo();
            panel1.Paint += panel1_Paint;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            InicializarGrafo();
            if (grafoInicializado) 
            {
              
            }

        }

        public void RutaMasCorta(string entrada, Graphics g)
        {
            floyd = new Floyd_Warshall(grafo.nodos, ObtenerMatrizAdyacencia());
            int distanciaAnt = int.MaxValue;
            int distancia;
            int IdMasCercano = -1;
            int IdCercano = -1;
            CVfila entradaIzquierda = grafo.nodos.Find(f => f.BloqueFila == "EntradaIzquierda");
            int indiceEntrada = grafo.nodos.IndexOf(entradaIzquierda);

            foreach (CVfila fila in grafo.nodos)
            {
                if (fila != entradaIzquierda)
                {
                    if (fila.HayDisponibles == true)
                    {
                        IdCercano = grafo.nodos.IndexOf(fila);
                        distancia = floyd.ObtenerDistancia(indiceEntrada, IdCercano);

                        if (distancia < distanciaAnt)
                        {
                            IdMasCercano = IdCercano;
                            distanciaAnt = distancia;
                        }
                    }
                }

            }



            List<CVfila> rutaMasCercano = floyd.ObtenerRuta(indiceEntrada, IdMasCercano);
            CVfila cercano = grafo.nodos[IdMasCercano];
            int numEstacionamiento = cercano.PosicionDisponibleCercano(entradaIzquierda.Coordenada);
            grafo.DibujarGrafoPrueba(g);
            grafo.DibujarCamino(g, rutaMasCercano, numEstacionamiento);
        }

       
        // Construye el bloque derecho (bloque C o D) del estacionamiento con 6 filas y 5 espacios por fila
        // Ajuste final del bloque derecho con más espacio entre filas intermedias e inferiores
        // Reconstrucción final del bloque derecho con nodo entrada conectado visualmente
        // Reconstrucción final del bloque derecho con UN solo nodo de entrada correctamente posicionado y conectado
        public static void InicializarGrafo()
        {
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

            grafo.AgregarCalle(f2d, f1d, 1);
            grafo.AgregarCalle(f3d, f2d, 0);
            grafo.AgregarCalle(f4d, f3d, 1);
            grafo.AgregarCalle(f5d, f4d, 0);
            grafo.AgregarCalle(f6d, f5d, 1);

            grafo.AgregarCalle(f2i, f1i, 1);
            grafo.AgregarCalle(f3i, f2i, 0);
            grafo.AgregarCalle(f4i, f3i, 1);
            grafo.AgregarCalle(f5i, f4i, 0);
            grafo.AgregarCalle(f6i, f5i, 1);

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

        public int[,] ObtenerMatrizAdyacencia()
        {

            int n = grafo.nodos.Count;
            int[,] matriz = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matriz[i, j] = 0; // Sin conexión
                }

                foreach (CAcalle arco in grafo.nodos[i].ListaAdyacencia)
                {
                    int j = grafo.nodos.IndexOf(arco.nDestino);
                    matriz[i, j] = arco.Peso;
                }
            }

            return matriz;
        }

        //Yo por aqui no paso...
    }
}
