using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking
{
    internal class Password
    {
        private int longitud;
        private string ID;

        // Constructor
        public Password()
        {
            this.longitud = 5;
            this.ID = "12345678";
        }


        public int GetLongitud()
        {
            return longitud;
        }

        public void SetLongitud(int longitud)
        {
            this.longitud = longitud;
        }


        public string GetContraseña()
        {
            return ID;
        }

        public void SetContraseña(string contraseña)
        {
            this.ID = contraseña;
        }


        // Método para generar una contraseña aleatoria
        public string GenerarPassword()
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder nuevaContraseña = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < longitud; i++)
            {
                int index = random.Next(caracteres.Length);
                nuevaContraseña.Append(caracteres[index]);
            }

            this.ID = nuevaContraseña.ToString();

            return ID.ToString();
        }
    }
}
