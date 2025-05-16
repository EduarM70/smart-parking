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

       public CVfila(string bloqueFila, Point coordenada) //el array de espacios esta llenado asi de forma provisional por motivos de prueba, no es asi en defecto
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
            PosicionRelativaCalle = 'u';

        }
       //constructor de prueba
       public CVfila()
        {
           
            Coordenada = new Point(5, 165);
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

        public void DibujarCalle(Graphics g, Point origen, Point destino)//dibuja arcos, conexion entre 2 vertices(filas de parqueo)
        { 
          //revisa si la linea es vertical
          if(Math.Abs(origen.X - destino.X)<=5)
            {
                origen.X = origen.X - 15;
                destino.X= origen.X;
            }

            //revisa si la linea es horizontal
            if (Math.Abs(origen.Y- destino.Y) <= 5)
            {
                if(PosicionRelativaCalle=='d')
                {
                    origen.Y = origen.Y + 15;
                    destino.Y = origen.Y;
                }
                else if(PosicionRelativaCalle =='u')
                {
                    origen.Y = origen.Y - 15;
                    destino.Y = origen.Y;
                }
                else
                {
                    destino.Y = origen.Y+10;
                   origen.Y = origen.Y+10;
                }

               
            }

            /*
            if(CalleAbajo==false && origen.X != destino.X)
            {
                origen = new Point(origen.X - 15, origen.Y -10 );
                destino = new Point(destino.X - 15, destino.Y - 10);

            }
            else if(origen.X != destino.X)
            {
                origen = new Point(origen.X - 15, origen.Y + 10);
                destino = new Point(destino.X - 15, destino.Y + 10);
            }

            if(Math.Abs(origen.Y- destino.Y)<= 10)
            {
                origen.Y = destino.Y;
                origen.X = origen.X + 15;
                destino.X = destino.X +15;

            }
            */


            g.SmoothingMode = SmoothingMode.AntiAlias;
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(2, 2, true);
            bigArrow.BaseCap = LineCap.Triangle;
            g.DrawLine(new Pen(new SolidBrush(Color.Gold), (float)8)
                    {
                        CustomEndCap = bigArrow,
                        Alignment = PenAlignment.Center
                    }, origen, destino);
           
        }

        public Point PuntoEnFila( int posicion) //obtiene el punto en el que se encuentra un espacio de parqueo en la fila
        {
            int espacio = 18; // Espacio entre rectángulos
            int anchura = 20;
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
