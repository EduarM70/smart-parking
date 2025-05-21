using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SmartParking.Data;
using SmartParking.Models;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace SmartParking.Services.User
{
    public class AuthService
    {

        ConexionDB conexionDB = new ConexionDB();

        public bool Login(string user, string password)
        {
                        
            try
            {
                conexionDB.ConectarBase();

                string queryCliente = "SELECT COUNT(*) FROM Administrador WHERE usuario = @user AND Contrasena = @pass";

                SqlCommand cmdCliente = new SqlCommand(queryCliente, conexionDB.ConectarBase());

                cmdCliente.Parameters.AddWithValue("@user", user);
                cmdCliente.Parameters.AddWithValue("@pass", password);

                int esCliente = (int)cmdCliente.ExecuteScalar();

                if (esCliente > 0)
                {
                    MessageBox.Show($"Bienvenido usuario: {user}");                  

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error usuario no encontrado", ex.Message);
            }

            return false;
        }

        public SmartParking.Models.User ObtenerUsuario(string usuario)
        {
            string queryCliente = "SELECT id, usuario, nombre, email FROM Administrador WHERE usuario = @user";

            SqlCommand cmdCliente = new SqlCommand(queryCliente, conexionDB.ConectarBase());

            cmdCliente.Parameters.AddWithValue("@user", usuario);

            SqlDataReader reader = cmdCliente.ExecuteReader();

            if (reader.Read())
            {
                return new SmartParking.Models.User
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Usuario = reader["usuario"].ToString(),
                    Nombre = reader["nombre"].ToString(),
                    Email = reader["email"].ToString()
                };
            }
            return null;
        }
    }
}
