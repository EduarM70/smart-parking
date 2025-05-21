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
using SmartParking.Models;
using SmartParking.Services.Maps;
using SmartParking.Services.RegistroParqueo;

namespace SmartParking.Forms
{
    public partial class FormSalida : Form
    {
        double tiempototal;

        RegistroParqueoService registroParqueo;
        
        DateTime FechaEntrada;
        DateTime hora;
        TimeSpan HT;
        double TotalMin;

        private ParkingMap map;

        private PictureBox PictureBox;

        public FormSalida(ParkingMap mapaParqueo = null, PictureBox pintureBox = null)
        {
            InitializeComponent();

            registroParqueo = new RegistroParqueoService();

            lbsaludo.Visible = false;
            btnPagar.Enabled = false;
            btnSalir.Enabled = false;

            map = mapaParqueo;
            PictureBox = pintureBox;
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

                FechaEntrada = registroParqueo.getRegistroParqueoByCodigo(txtCod.Text).fechaIngreso;

                if (FechaEntrada != null)
                {
                    HT = hora - FechaEntrada;
                    TotalMin = Math.Round(HT.TotalMinutes, 2);
                }
                else
                {
                    MessageBox.Show("Codigo no encontrado", "Error en el registro de salida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message);
            }

            //CONSULTA A LA BASE

            try
            {
                Parqueo validateParqueo = registroParqueo.getRegistroParqueoByCodigo(txtCod.Text);

                if (validateParqueo != null)
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
                    MessageBox.Show("Codigo no encontrado", "Error en el registro de salida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la Base", ex.Message);
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            hora = DateTime.Now;
            TimeSpan total = hora - FechaEntrada;
            double minutos = total.TotalMinutes;

            Parqueo parqueoToUpdate = registroParqueo.getRegistroParqueoByCodigo(txtCod.Text);

            parqueoToUpdate.fechaSalida = hora;
            parqueoToUpdate.totalPago = TotPagar(minutos);
            parqueoToUpdate.tarifaAplicada = TotPagar(minutos);

            if (parqueoToUpdate != null)
            {
                registroParqueo.registrarSalida(parqueoToUpdate);

                map.CambiarEstadoParqueos(parqueoToUpdate, true);

                PictureBox?.Refresh();

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
