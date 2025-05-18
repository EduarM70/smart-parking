using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartParking
{
    internal class ConexionDB
    {
        //cadena de conexion a la base de datos
        public string Cadena = "Server=localhost;Database=SmartParkingDB;Trusted_Connection=True;TrustServerCertificate=True;";


        public SqlConnection ConectarBase()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Cadena);
                conexion.Open();  // Abre la conexión
                return conexion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
                return null;
            }



        }
        public void CerrarConexion(SqlConnection conexion)
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
