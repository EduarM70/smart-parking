﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Services
{
    public class CAcalle
    {
        public int Peso;
        public CVfila nDestino;

        public CAcalle(CVfila destino)
        {
           nDestino = destino;
        }

        public CAcalle(CVfila destino, int peso)
        {
            nDestino = destino;
            Peso = peso;
        }

    }
}
