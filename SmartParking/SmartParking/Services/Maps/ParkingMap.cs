using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Services.Maps
{
    public class ParkingMap
    {

        public CGrafo grafo;

        private List<CVfila> listaEntradas;

        List<CVfila> rutaMasCercano;
        int numEstacionamiento;
        bool grafoInicializado = false;
        Floyd_Warshall floyd; //para llamar métodos de Floyd_Warshall

        public ParkingMap() {
            grafo= new CGrafo();
            listaEntradas = new List<CVfila>();
        }

        public CGrafo Grafo
        {
            get { return grafo; }
            set { grafo = value; }
        }

        public List<CVfila> CrearGrafoDePrueba(Graphics e)
        {
            // Crear el grafo
            
            // entrada
            
            CVfila entrada = new CVfila();

            grafo.AgregarFila(entrada);

            // Agregar filas (vértices)

            CVfila fila1 = grafo.Agregarfila("Fila1", new Point(80, 70), 'u', "A4");
            CVfila fila2 = grafo.Agregarfila("Fila2", new Point(80, 95), 'd', "A4");
            CVfila fila3 = grafo.Agregarfila("Fila3", new Point(80, 145), 'u', "A4");
            CVfila fila4 = grafo.Agregarfila("Fila4", new Point(80, 170), 'd', "A4");
            CVfila fila5 = grafo.Agregarfila("Fila5", new Point(80, 220), 'u', "A4");

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
            return caminoPrueba;

        }

        public void MapaCompleto(Graphics e)
        {
            // Crear el grafo para mapa completo
            
            // Definir entradas, o nodos de puntos de partidas
            CVfila entradaA_W = new CVfila(new Point(121, 315));
            CVfila entradaA_N = new CVfila(new Point(445, 95));

            grafo.AgregarFila(entradaA_W);
            grafo.AgregarFila(entradaA_N);

            CVfila entradaB_W = new CVfila(new Point(121, 367));
            CVfila entradaB_S = new CVfila(new Point(447, 624));
            grafo.AgregarFila(entradaB_W);
            grafo.AgregarFila(entradaB_S);

            CVfila entradaC_E = new CVfila(new Point(850, 317));
            CVfila entradaC_N = new CVfila(new Point(850, 317));
            grafo.AgregarFila(entradaC_E);
            grafo.AgregarFila(entradaC_N);

            CVfila entradaD_E = new CVfila(new Point(850, 367));
            CVfila entradaD_S = new CVfila(new Point(496, 624));
            grafo.AgregarFila(entradaD_E);
            grafo.AgregarFila(entradaD_S);


            // Definir las 12 filas

            // Zona A - B
            CVfila fila1 = grafo.Agregarfila("Fila1", new Point(177, 40), 'u', "A1", 6);
            CVfila fila2 = grafo.Agregarfila("Fila2", new Point(177, 138), 'd', "A2", 7);
            CVfila fila3 = grafo.Agregarfila("Fila3", new Point(177, 204), 'u', "A3", 7);
            CVfila fila4 = grafo.Agregarfila("Fila4", new Point(177, 301), 'd', "A4", 7);
            CVfila fila5 = grafo.Agregarfila("Fila5", new Point(177, 365), 'u', "B4", 7);
            CVfila fila6 = grafo.Agregarfila("Fila6", new Point(177, 462), 'u', "B3", 7);
            CVfila fila7 = grafo.Agregarfila("Fila7", new Point(177, 527), 'u', "B2", 7);
            CVfila fila8 = grafo.Agregarfila("Fila8", new Point(177, 623), 'u', "B1", 6);

            // Zona C - D

            CVfila fila9 = grafo.Agregarfila("Fila9", new Point(555, 40), 'u', "C1", 6);
            CVfila fila10 = grafo.Agregarfila("Fila10", new Point(512, 138), 'd', "C2", 7); // 514; 138
            CVfila fila11 = grafo.Agregarfila("Fila11", new Point(512, 204), 'u', "C3", 7); // 513; 204
            CVfila fila12 = grafo.Agregarfila("Fila12", new Point(512, 301), 'd', "C4", 7); // 513; 301
            CVfila fila13 = grafo.Agregarfila("Fila13", new Point(512, 365), 'u', "D4", 7);
            CVfila fila14 = grafo.Agregarfila("Fila14", new Point(512, 462), 'u', "D3", 7);
            CVfila fila15 = grafo.Agregarfila("Fila15", new Point(512, 527), 'u', "D2", 7);
            CVfila fila16 = grafo.Agregarfila("Fila16", new Point(555, 623), 'u', "D1", 6); // 557; 624


            grafo.DibujarGrafoPrueba(e);


        }

        public void RutaMasCorta(string entrada)
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



            rutaMasCercano = floyd.ObtenerRuta(indiceEntrada, IdMasCercano);
            CVfila cercano = grafo.nodos[IdMasCercano];
            numEstacionamiento = cercano.PosicionDisponibleCercano(entradaIzquierda.Coordenada);
            caminoDibujar = true;
            panel1.Refresh();
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
    }


}
