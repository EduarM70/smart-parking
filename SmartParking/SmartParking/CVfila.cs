using System;
using System.Collections.Generic;
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
        public char PosicionRelativaCalle;  //hace referencia a si la calle esta arriba de la fila o abajo, o ninguna en el caso de entradas
                                            // u: up (arriba) d: down (abajo), n : none(ninguno)

       public CVfila(string bloqueFila, Point coordenada, char posicioncalle) //el array de espacios esta llenado asi de forma provisional por motivos de prueba, no es asi en defecto
        {
            Coordenada = coordenada;
            BloqueFila = bloqueFila;
            HayDisponibles = getHayDisponible();
            ListaAdyacencia = new List<CAcalle>();
            espacios = new CEspacioP[5];
            espacios[0] = new CEspacioP
            {
                Disponible = false,
                EspacioEspecial = false,
                CodigoParqueado = null
            };

            espacios[1] = new CEspacioP
            {
                Disponible = false,
                EspacioEspecial = true,
                CodigoParqueado = "ABC123"
            };

            espacios[2] = new CEspacioP
            {
                Disponible = true,
                EspacioEspecial = false,
                CodigoParqueado = null
            };

            espacios[3] = new CEspacioP
            {
                Disponible = false,
                EspacioEspecial = false,
                CodigoParqueado = "XYZ789"
            };

            espacios[4] = new CEspacioP
            {
                Disponible = true,
                EspacioEspecial = true,
                CodigoParqueado = null
            };
            Visitado = false;
            PosicionRelativaCalle = posicioncalle;

        }
       //constructor de prueba
       public CVfila()
        {
           
            Coordenada = new Point(600, 130);
            PosicionRelativaCalle = 'n';


        }

        public void DibujarFila(Graphics g, Point origen)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Color color = Color.Yellow; //amarillo signifca que algo de el codigo no esta funcionando
            int anchura = 15;
            int altura = 15;
            int espacio = 5; // Espacio entre rectángulos

            for (int i = 0; i < 5; i++)
            {
                int x = origen.X + i * (anchura + espacio);
                int y = origen.Y;

                if (espacios[i].Disponible == true)
                    color = Color.Green;
                else
                    color = Color.Red;

                using (SolidBrush brush = new SolidBrush(color))
                {
                    g.FillRectangle(brush, x, y, anchura, altura);
                }
               
            }
        }
            public void DibujarFila(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (espacios!=null)
            {
                Color color = Color.Yellow; //amarillo signifca que algo de el codigo no esta funcionando
                int anchura = 18;
                int altura = 18;
                int espacio = 10; // Espacio entre rectángulos

                for (int i = 0; i < 5; i++)
                {
                    int x = Coordenada.X + i * (anchura + espacio);
                    int y = Coordenada.Y;

                    if (espacios[i].Disponible == true)
                        color = Color.Green;
                    else
                        color = Color.Red;

                    using (SolidBrush brush = new SolidBrush(color))
                    {
                        g.FillRectangle(brush, x, y, anchura, altura);
                    }

                }
            }
            
        }

        public Point DibujarCalle(Graphics g, CVfila origen, CVfila destino, Point DestinoAnt)//dibuja arcos, conexion entre 2 vertices(filas de parqueo)
        { 
            int origenX=origen.Coordenada.X;                                  //si sdestino ant es 0,0 no lo toma, ese seria el valor por defecto
            int origenY = origen.Coordenada.Y;
            int destinoX = destino.Coordenada.X;
            int destinoY = destino.Coordenada.Y;
            bool ExisteAnt = false;
            //se asegura de conectar con la linea anterior si hubo
            if (DestinoAnt != new Point(0, 0))
            {
                origenX = DestinoAnt.X+5;
                origenY = DestinoAnt.Y;
                ExisteAnt= true;
            }

            //para ver a que lado de la fila conectar
            if (Math.Abs(destino.PuntoEnFila(5).X - origenX) < Math.Abs(destinoX - origenX))
            {
                destinoX = destino.PuntoEnFila(5).X+20;
               
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
            if (Math.Abs(origenX - destinoX)<15)
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
                    },new Point(origenX, origenY), new Point(destinoX,destinoY));
            return new Point(destinoX, destinoY);
        }

        public Point PuntoEnFila(int posicion) //obtiene el punto en el que se encuentra un espacio de parqueo en la fila
        {
            int espacio = 10; // Espacio entre rectángulos
            int anchura = 18;
            int x=0, y=0;
            for (int i = 0; i < posicion; i++)
            {
                x = Coordenada.X + i * (anchura + espacio);
                y = Coordenada.Y;
            }
            Point Espacio = new Point(x+15, y);
          
            return Espacio;
        }

        public bool getHayDisponible() { return false; }

        public int DisponibleCercano() { return 0; }

        public void CambiarEstado(string Codigo) { }


    }
}
