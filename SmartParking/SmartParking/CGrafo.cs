using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace SmartParking
{
    public class CGrafo
    {
        public List<CVfila> nodos;

        public CGrafo() 
        {
            nodos = new List<CVfila>();
        }

        public int getTotalFilas() { return 0; }

        public CVfila Agregarfila(string bloque, Point coordenadas,char posicionCalle)
        {
            CVfila nodo = new CVfila(bloque, coordenadas, posicionCalle);
            nodos.Add(nodo);
            return nodo;
        }
        public void AgregarFila(CVfila nuevafila) 
        {
            nodos.Add(nuevafila);
        }
        public void BuscarDisponible(CVfila entrada) { }

        public bool AgregarCalle(CVfila origen, CVfila nDestino, int peso) 
        {
            if (origen.ListaAdyacencia.Find(v => v.nDestino == nDestino) == null)
            {
                origen.ListaAdyacencia.Add(new CAcalle(nDestino, peso));
                return true;
            }
            return false;
        }

        public void DibujarCamino(Graphics g, List<CVfila> camino)
        {
            using (Pen lapiz = new Pen(Color.Black, 2))
            {
                Point destinoAnt=new Point(0,0);
                // Dibujamos las calles entre los vértices
                for (int i = 0; i < camino.Count - 1; i++)
                {
                    CVfila verticeOrigen = camino[i];
                    CVfila verticeDestino = camino[i + 1];
                   destinoAnt =  verticeOrigen.DibujarCalle(g, verticeOrigen, verticeDestino, destinoAnt);

                }
            }
        }


        public void DibujarGrafoPrueba(Graphics g) 
        { 
         foreach(CVfila fila in nodos)
            {
                fila.DibujarFila(g);
            }
        }

        public void ReestablecerColores(Graphics g) { }

        public void Desmarcar() { }
    }

   

}
