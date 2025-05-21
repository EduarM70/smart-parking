using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartParking.Data;

namespace SmartParking.Forms
{
    public partial class FormSalida : Form
    {
        double tiempototal;
        ConexionDB conexionDB;
        DateTime FechaEntrada;
        DateTime hora;
        TimeSpan HT;
        double TotalMin;
        
        public FormSalida()
        {
            InitializeComponent();

            conexionDB = new ConexionDB();

            lbsaludo.Visible = false;
            btnPagar.Enabled = false;
            btnSalir.Enabled = false;
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {

           


        }
        public double TotPagar(double lbTiempo)
        {
            double Tarifa = 0;

            double Thetime = lbTiempo;

            if (Thetime < 01.00 && Thetime > 00.00)
            {
                lbtotP.Text = "$0.00";
                txtPago.Text = lbtotP.Text;
                btnPagar.Enabled = true;
                Tarifa = 0.00;

            }
            if (Thetime > 01.00 && Thetime < 02.00)
            {

                lbtotP.Text = "$5.00";
                txtPago.Text = lbtotP.Text;
                btnPagar.Enabled = true;
                Tarifa = 5.00;
            }
            if (Thetime > 02.00)
            {
                Tarifa = 10.00;
                lbtotP.Text = "$10.00";
                txtPago.Text = lbtotP.Text;
                btnPagar.Enabled = true;

            }
            return Tarifa;
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            
        }

        private void FormSalida_Load(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                conexionDB.ConectarBase();
                string query = "SELECT Fecha_ingreso FROM Registro_ingreso WHERE codigo = @codigo";

                SqlCommand cmd = new SqlCommand(query, conexionDB.ConectarBase());
                cmd.Parameters.AddWithValue("@codigo", txtCod.Text);
                object resultado = cmd.ExecuteScalar();
                FechaEntrada = Convert.ToDateTime(resultado);
                HT = hora - FechaEntrada;
                TotalMin = Math.Round(HT.TotalMinutes, 2);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message);
            }

            //CONSULTA A LA BASE

            try
            {
                string queryCliente = "SELECT COUNT(*) FROM Registro_ingreso WHERE codigo = @cod";
                SqlCommand cmdCliente = new SqlCommand(queryCliente, conexionDB.ConectarBase());
                cmdCliente.Parameters.AddWithValue("@cod", txtCod.Text);

                int esCliente = (int)cmdCliente.ExecuteScalar();

                if (esCliente > 0)
                {

                    DateTime horaSalida = DateTime.Now;
                    TimeSpan HoraTotal = horaSalida - FechaEntrada;
                    double TiempoTotal = Math.Round(HoraTotal.TotalMinutes, 2);

                    lbtiempoE.Text = FechaEntrada.ToString();
                    lbtiempoS.Text = horaSalida.ToString();
                    lbTimeTot.Text = TiempoTotal.ToString() + " minutos";

                    TotPagar(TiempoTotal);
                    txtCod.Enabled = false;
                    btnConfirmar.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("Codigo no encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la Base", ex.Message);
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            hora = DateTime.Now;
            TimeSpan total = hora - FechaEntrada;
            double minutos = total.TotalMinutes;

            conexionDB.ConectarBase();
            try
            {
                string query = "UPDATE Registro_ingreso SET Fecha_salida = @salida,Tiempo_estacionado = @tiempo," +
                    "Total_pagar = @cobro, Tarifa_aplicada = @cobro2 WHERE codigo = @cod";
                SqlCommand cmd = new SqlCommand(query, conexionDB.ConectarBase());
                cmd.Parameters.AddWithValue("@cod", txtCod.Text);
                cmd.Parameters.AddWithValue("@salida", hora);
                cmd.Parameters.AddWithValue("@tiempo", total);
                cmd.Parameters.AddWithValue("@cobro", TotPagar(minutos));
                cmd.Parameters.AddWithValue("@cobro2", TotPagar(minutos));

                int filasAfectadas = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en la DB");
            }

            lbsaludo.Visible = true;
            btnSalir.Enabled = true;
            btnPagar.Enabled = false;
        }

        private void txtCod_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCod_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtPago_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
