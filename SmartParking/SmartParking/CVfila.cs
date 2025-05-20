using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace SmartParking
{
    public class CVfila
    {

        public string BloqueFila;
        public bool HayDisponibles;
        public List<CAcalle> ListaAdyacencia;
        public CEspacioP[] espacios;
        public bool Visitado;
        public Point Coordenada;
        public char PosicionRelativaCalle;

        public CVfila(string bloqueFila, Point coordenada, char posicioncalle)
        {
            Coordenada = coordenada;
            BloqueFila = bloqueFila;
            ListaAdyacencia = new List<CAcalle>();
            espacios = new CEspacioP[5];
            for (int i = 0; i < 5; i++)
            {
                espacios[i] = new CEspacioP { Disponible = false };
            }
            espacios[3].Disponible = true; // Por defecto activa uno en el centro
            Visitado = false;
            PosicionRelativaCalle = posicioncalle;
            HayDisponibles = getHayDisponible();
        }

        public CVfila()
        {
            Coordenada = new Point(600, 130);
            PosicionRelativaCalle = 'n';
            ListaAdyacencia = new List<CAcalle>();
            espacios = new CEspacioP[5];
            for (int i = 0; i < 5; i++)
            {
                espacios[i] = new CEspacioP { Disponible = false };
            }
            HayDisponibles = getHayDisponible();
        }

        public void DibujarFila(Graphics g, Point origen)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Color color = Color.Yellow;
            int anchura = 15;
            int altura = 15;
            int espacio = 5;

            for (int i = 0; i < espacios.Count(); i++)
            {
                int x = origen.X + i * (anchura + espacio);
                int y = origen.Y;
                color = espacios[i].Disponible ? Color.Green : Color.Red;

                using (SolidBrush brush = new SolidBrush(color))
                {
                    g.FillRectangle(brush, x, y, anchura, altura);
                }
            }
        }

        public void DibujarFila(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (espacios != null)
            {
                Color color = Color.Yellow;
                int anchura = 18;
                int altura = 18;
                int espacio = 10;

                for (int i = 0; i < espacios.Count(); i++)
                {
                    int x = Coordenada.X + i * (anchura + espacio);
                    int y = Coordenada.Y;
                    color = espacios[i].Disponible ? Color.Green : Color.Red;

                    using (SolidBrush brush = new SolidBrush(color))
                    {
                        g.FillRectangle(brush, x, y, anchura, altura);
                    }
                }
            }
        }

        // ... (el resto del código permanece igual)
        public Point DibujarCalle(Graphics g, CVfila origen, CVfila destino, Point DestinoAnt)//dibuja arcos, conexion entre 2 vertices(filas de parqueo)
        {
            int origenX = origen.Coordenada.X;                                  //si sdestino ant es 0,0 no lo toma, ese seria el valor por defecto
            int origenY = origen.Coordenada.Y;
            int destinoX = destino.Coordenada.X;
            int destinoY = destino.Coordenada.Y;
            bool ExisteAnt = false;
            //se asegura de conectar con la linea anterior si hubo
            if (DestinoAnt != new Point(0, 0))
            {
                origenX = DestinoAnt.X + 5;
                origenY = DestinoAnt.Y;
                ExisteAnt = true;
            }

            //para ver a que lado de la fila conectar
            if (Math.Abs(destino.PuntoEnFila(5).X - origenX) < Math.Abs(destinoX - origenX))
            {
                destinoX = destino.PuntoEnFila(5).X + 20;

            }
            else
            {
                origenX -= 15;
                destinoX -= 15;
            }

            //ubica las coordenadas sobre la calle
            if (destino.PosicionRelativaCalle == 'd')
                destinoY = destinoY + 35;
            else if (destino.PosicionRelativaCalle == 'u')
            {
                destinoY = destinoY - 15;
            }

            if (!ExisteAnt) //si se tomaron las coordenadas de ant no se necesita ajustar 
            {
                if (origen.PosicionRelativaCalle == 'd')
                    origenY = origenY + 35;
                else if (origen.PosicionRelativaCalle == 'u')
                {
                    origenY = origenY - 15;
                }
            }


            //revisa si la linea es vertical
            if (Math.Abs(origenX - destinoX) < 15)
            {
                destinoX = origenX;
            }

            //revisa si la linea es horizontal
            if (Math.Abs(origenY - destinoY) <= 5)
            {
                origenY = destinoY;
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(2, 2, true);
            bigArrow.BaseCap = LineCap.Triangle;
            g.DrawLine(new Pen(new SolidBrush(Color.Gold), (float)8)
            {
                CustomEndCap = bigArrow,
                Alignment = PenAlignment.Center
            }, new Point(origenX, origenY), new Point(destinoX, destinoY));
            return new Point(destinoX, destinoY);
        }

        //sobrecarga de dibujar calle que solo toma como argumento coordenadas, usar para dibujar la linea final hasta estacionamiento
        public void DibujarCalle(Graphics g, Point origen, Point destino)
        {

            g.SmoothingMode = SmoothingMode.AntiAlias;
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(2, 2, true);
            bigArrow.BaseCap = LineCap.Triangle;
            g.DrawLine(new Pen(new SolidBrush(Color.Gold), (float)8)
            {
                CustomEndCap = bigArrow,
                Alignment = PenAlignment.Center
            }, origen, destino);

        }

        public Point PuntoEnFila(int posicion) //obtiene el punto en el que se encuentra un espacio de parqueo en la fila
        {
            int espacio = 10; // Espacio entre rectángulos
            int anchura = 18;
            int x = 0, y = 0;
            for (int i = 0; i < posicion; i++)
            {
                x = Coordenada.X + i * (anchura + espacio);
                y = Coordenada.Y;
            }
            Point Espacio = new Point(x + 15, y);

            return Espacio;
        }

        public bool getHayDisponible()
        {
            bool aux = false;
            for (int i = 0; i < 5; i++)
            {
                if (espacios[i].Disponible == true)
                {
                    aux = true;
                    break;
                }
            }
            return aux;
        }

        public int PosicionDisponibleCercano(Point origen) //si devuelve -1 es que no hay disponible cercano
        {
            int auxDistancia1 = int.MaxValue;
            int auxDistancia2 = 0;
            int auxNum = -1;
            List<int> disponibles = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                if (espacios[i].Disponible == true)
                {
                    disponibles.Add(i);

                }

            }

            foreach (int numeroEspacio in disponibles)
            {
                auxDistancia2 = Math.Abs(PuntoEnFila(numeroEspacio).X - origen.X);

                if (auxDistancia2 < auxDistancia1)
                {
                    auxDistancia2 = auxDistancia1;
                    auxNum = numeroEspacio;
                }
            }

            return auxNum;
        }

        public void CambiarEstado(int posicion)
        {
            if (espacios[posicion].Disponible == true)
                espacios[posicion].Disponible = false;
            else
            {
                espacios[posicion].Disponible = true;
            }
        }

        //Yo por aqui no paso
    }
}
