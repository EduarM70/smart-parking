using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using TheArtOfDevHtmlRenderer.Adapters;
using static System.Windows.Forms.AxHost;

namespace SmartParking.Services
{
    public class CVfila
    {

        public string BloqueFila;
        public int filaNumero;
        public bool HayDisponibles;
        public List<CAcalle> ListaAdyacencia;
        public CEspacioP[] espacios; //espacios de parqueo
        public int cantidadEspacios;
        public bool Visitado;
        public Point Coordenada;
        public string zona;
        public int[] numerosParqueos; // los numeros que deben llevar cada fila
        public char PosicionRelativaCalle;  //hace referencia a si la calle esta arriba de la fila o abajo, o ninguna en el caso de entradas
                                            // u: up (arriba) d: down (abajo), n : none(ninguno) (para entradas)

       static Random rnd = new Random();
        public CVfila(string bloqueFila, Point coordenada, char posicioncalle, string zonafila, int parqueos = 5) //el array de espacios esta llenado asi de forma provisional por motivos de prueba, no es asi en defecto
       {
            Coordenada = coordenada;
            BloqueFila = bloqueFila;

            ListaAdyacencia = new List<CAcalle>();

            cantidadEspacios = parqueos; // cantidad de parqueos que deben tener cada fila, para recorrer el arreglo

            espacios = new CEspacioP[cantidadEspacios];

            // asignar los numeros de los parqueos dependiendo de la fila y zona a la que perteneza

            // Extraer la letra (primer carácter)
            zona = zonafila[0].ToString(); // 'A'

            // Extraer el número (resto del string)
            string numeroStr = zonafila.Substring(1); // "1"

            int fila = int.Parse(numeroStr); // 1

            filaNumero = fila;

            switch (fila)
            {
                case 1:
                    numerosParqueos = new int[] { 1, 2, 3, 4, 5, 6 };
                    break;
                case 2:
                    numerosParqueos = new int[] { 7, 8, 9, 10, 11, 12, 13 };
                    break;
                case 3:
                    numerosParqueos = new int[] { 14, 15, 16, 17, 18, 19, 20 };
                    break;
                case 4:
                    numerosParqueos = new int[] { 21, 22, 23, 24, 25, 26, 27 };
                    break;
            }

            for (int i = 0; i < cantidadEspacios; i++)
            {

                espacios[i] = new CEspacioP()
                {
                    Disponible = random(),
                    EspacioEspecial = false,
                    CodigoParqueado = null,
                    numero = numerosParqueos[i]
                };
            }

            Visitado = false;
            PosicionRelativaCalle = posicioncalle;
            HayDisponibles = getHayDisponible();
       }

       //constructor de prueba
       public CVfila()
       {
           
            Coordenada = new Point(600, 130);
            PosicionRelativaCalle = 'n';
            ListaAdyacencia = new List<CAcalle>();
            zona = "n";

       }

        // Constructor para Entradas
        public CVfila(string bloquefila, Point coordenada)
        {
            BloqueFila = bloquefila;
            Coordenada = coordenada;
            PosicionRelativaCalle = 'n';
            ListaAdyacencia = new List<CAcalle>();
            zona = "n";
        }

        public void DibujarFila(Graphics g, Point origen)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color color = Color.Yellow; //amarillo signifca que algo de el codigo no esta funcionando
            int anchura = 15;
            int altura = 15;
            int espacio = 5;

            for (int i = 0; i < cantidadEspacios; i++)
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

            if (espacios!=null)
            {
                Color color = Color.Yellow; //amarillo signifca que algo de el codigo no esta funcionando
                int anchura = 24;
                int altura = 24;
                int espacio = 18; // Espacio entre rectángulos

                for (int i = 0; i < cantidadEspacios; i++)
                {
                    int x = (Coordenada.X + 8) + i * (anchura + espacio);
                    int y = Coordenada.Y + 14;

                    if (espacios[i].Disponible == true)
                        color = Color.Green;
                    else
                        color = Color.Red;

                    //using (SolidBrush brush = new SolidBrush(color))
                    //{
                    //    g.FillRectangle(brush, x, y, anchura, altura);
                    //}

                    Rectangle rect = new Rectangle(x, y, anchura, altura);
                    int borderRadius = 5;

                    using (GraphicsPath path = CreateRoundedRectangle(rect, borderRadius))
                    {
                        using (SolidBrush brush = new SolidBrush(color))
                        {
                            g.FillPath(brush, path);
                        }

                        using (Pen pen = new Pen(color))
                        {
                            g.DrawPath(pen, path);
                        }
                    }

                    // Dibujar el texto centrado
                    string number = espacios[i].numero.ToString();
                    Font font = new Font("Poppins", 7, FontStyle.Bold);
                    SizeF textSize = g.MeasureString(number, font);

                    // Calcular posición para centrar
                    float xtext = rect.Left + (rect.Width - textSize.Width) / 2;
                    float ytext = rect.Top + (rect.Height - textSize.Height) / 2;

                    g.DrawString(number, font, Brushes.White, xtext, ytext);

                }
            }
        }

        private GraphicsPath CreateRoundedRectangle(Rectangle rect, int borderRadius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, borderRadius, borderRadius, 180, 90);
            path.AddArc(rect.Right - borderRadius, rect.Y, borderRadius, borderRadius, 270, 90);
            path.AddArc(rect.Right - borderRadius, rect.Bottom - borderRadius, borderRadius, borderRadius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - borderRadius, borderRadius, borderRadius, 90, 90);

            path.CloseFigure();
            return path;
        }

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
                origenX = DestinoAnt.X;
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
                if(!ExisteAnt)
                {
                    origenX -= 15;
                }
                destinoX -= 15;
            }


            //revisa si la linea es vertical
            if (Math.Abs(origenX - destinoX) <= 15)
            {
                destinoX = origenX;
               
               destinoY -= 15;
            }

            //revisa si la linea es horizontal
            if (Math.Abs(origenY - destinoY) <= 15)
            {

                if (!ExisteAnt) //si se tomaron las coordenadas de ant no se necesita ajustar 
                
                    if (origen.PosicionRelativaCalle == 'd')
                        origenY = origenY + 35;
                    else if (origen.PosicionRelativaCalle == 'u')
                    {
                        origenY = origenY - 15;
                    }

                    
                    if (destino.PosicionRelativaCalle == 'd')
                        destinoY = destinoY + 35;
                    else if (destino.PosicionRelativaCalle == 'u')
                    {
                        destinoY = destinoY - 15;
                    }

                    origenY = destinoY;
                

            }
          /* if (DestinoAnt != new Point(0, 0))
            {
                origenX = DestinoAnt.X;
                origenY = DestinoAnt.Y;
                ExisteAnt = true;
            }
          */
            
            g.SmoothingMode = SmoothingMode.AntiAlias;
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(2, 2, true);
            bigArrow.BaseCap = LineCap.Triangle;
            g.DrawLine(new Pen(new SolidBrush(Color.Yellow), (float)4)
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
            g.DrawLine(new Pen(new SolidBrush(Color.Yellow), (float)4)
            {
                CustomEndCap = bigArrow,
                Alignment = PenAlignment.Center
            }, origen, destino);

        }

        public Point PuntoEnFila(int posicion) //obtiene el punto en el que se encuentra un espacio de parqueo en la fila
        {
            int espacio = 18; // Espacio entre rectángulos
            int anchura = 24;
            int x = 0, y = 0;

            x = (Coordenada.X + 8) + posicion * (anchura + espacio);
            y = Coordenada.Y + 14;

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
            for (int i = 0; i < cantidadEspacios; i++)
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
                    auxDistancia1 = auxDistancia2;
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


        public bool random ()
        {
           
           bool Disponible = rnd.Next(2) == 0;

            return Disponible;
        }
        //Yo por aqui no paso
    }
}
