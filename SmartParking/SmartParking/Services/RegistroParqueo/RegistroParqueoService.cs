using SmartParking.Data;
using SmartParking.Forms;
using SmartParking.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartParking.Services.RegistroParqueo
{
    public class RegistroParqueoService
    {

        ConexionDB conexionDB;

        public RegistroParqueoService()
        {
            conexionDB = new ConexionDB();
        }
        public Parqueo getRegistroParqueoByCodigo(string codigo)
        {
            string query = "SELECT * FROM Registro_ingreso WHERE codigo = @codigo";

            SqlCommand cmd = new SqlCommand(query, conexionDB.ConectarBase());

            cmd.Parameters.AddWithValue("@codigo", codigo);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Parqueo
                {
                    idIgreso = Convert.ToInt32(reader["idIngreso"]),
                    codigo = reader["codigo"].ToString(),
                    fechaIngreso = Convert.ToDateTime(reader["Fecha_ingreso"]),
                    zona = reader["zona"].ToString(),
                    fila = Convert.ToInt32(reader["fila"]),
                    parqueo = Convert.ToInt32(reader["estacionamiento"])
                };
            }

            return null;
        }

        public bool registrarEntrada(Parqueo nuevoParqueo)
        {
            try
            {
                string query = "INSERT INTO Registro_ingreso(codigo, Fecha_ingreso, zona, fila, estacionamiento)" +
                    "VALUES(@cod, @fechaIngreso, @zona, @fila, @estacionamiento)";

                SqlCommand cmd = new SqlCommand(query, conexionDB.ConectarBase());

                cmd.Parameters.AddWithValue("@cod", nuevoParqueo.codigo);
                cmd.Parameters.AddWithValue("@fechaIngreso", nuevoParqueo.fechaIngreso);
                cmd.Parameters.AddWithValue("@zona", nuevoParqueo.zona);
                cmd.Parameters.AddWithValue("@fila", nuevoParqueo.fila);
                cmd.Parameters.AddWithValue("@estacionamiento", nuevoParqueo.parqueo);

                int filasAfectadas = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en la DB");
            }
            return false;
        }

        public bool registrarSalida(Parqueo parqueoUdpated)
        {
            try
            {
                string query = "UPDATE Registro_ingreso SET Fecha_salida = @salida,Tiempo_estacionado = @tiempo," +
                    "Total_pagar = @cobro, Tarifa_aplicada = @cobro2 WHERE codigo = @cod";

                SqlCommand cmd = new SqlCommand(query, conexionDB.ConectarBase());

                cmd.Parameters.AddWithValue("@cod", parqueoUdpated.codigo);
                cmd.Parameters.AddWithValue("@salida", parqueoUdpated.fechaSalida);
                cmd.Parameters.AddWithValue("@tiempo", parqueoUdpated.tiempoEstacionado);
                cmd.Parameters.AddWithValue("@cobro", parqueoUdpated.totalPago);
                cmd.Parameters.AddWithValue("@cobro2", parqueoUdpated.tarifaAplicada);
                //cmd.Parameters.AddWithValue("@zona", parqueoUdpated.zona);
                //cmd.Parameters.AddWithValue("@fila", parqueoUdpated.fila);
                //cmd.Parameters.AddWithValue("@estacionamiento", parqueoUdpated.parqueo);

                int filasAfectadas = cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error en la DB");
            }

            return false;
        }

    }
}
