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

namespace SmartParking.Formularios
{
    public partial class FormSalida : Form
    {
        double tiempototal;
        ConexionDB conexionDB = new ConexionDB();
        FormEntrada entrada = new FormEntrada();
        public FormSalida()
        {
            InitializeComponent();
            lbsaludo.Visible = false;
            btnPagar.Enabled = false;
            btnSalir.Enabled = false;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //CONSULTA A LA BASE
            conexionDB.ConectarBase();
            try
            {
                string queryCliente = "SELECT COUNT(*) FROM Registro_ingreso WHERE codigo = @cod";
                SqlCommand cmdCliente = new SqlCommand(queryCliente, conexionDB.ConectarBase());
                cmdCliente.Parameters.AddWithValue("@cod", txtCod.Text);

                int esCliente = (int)cmdCliente.ExecuteScalar();

                if (esCliente > 0)
                {

                    DateTime horaSalida = DateTime.Now;
                    TimeSpan HoraTotal = horaSalida - FormEntrada.horaEntrada;
                    double TiempoTotal = Math.Round(HoraTotal.TotalMinutes, 2);

                    lbtiempoE.Text = FormEntrada.horaEntrada.ToString();
                    lbtiempoS.Text = horaSalida.ToString();
                    lbTimeTot.Text = Math.Round(HoraTotal.TotalMinutes, 2).ToString() + " minutos";

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

            }
            return Tarifa;
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            DateTime hora = DateTime.Now;
            TimeSpan total = hora - FormEntrada.horaEntrada;
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
