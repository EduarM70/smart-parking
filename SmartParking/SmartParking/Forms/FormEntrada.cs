using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SmartParking.Data;
using SmartParking.Services;
using SmartParking.Models;
using SmartParking.Services.User;
using System.Runtime.InteropServices;
using SmartParking.Services.Maps;
using System.Text.RegularExpressions;
using SmartParking.Services.RegistroParqueo;

namespace SmartParking.Forms
{
    public partial class FormEntrada : Form
    {
        public static DateTime horaEntrada;
        Password pass = new Password();
        
        RegistroParqueoService registroParqueoService;

        // Para cargar fuentes desde recursos si es necesario
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        private Font interRegular;
        private Font interBold;

        private ParkingMap map;
        private PictureBox PictureBox;

        public FormEntrada(ParkingMap mapaParqueo =  null, PictureBox pintureBox = null)
        {
            InitializeComponent();
            btnIngresar.Enabled = false;

            registroParqueoService = new RegistroParqueoService();

            map = mapaParqueo;
            PictureBox = pintureBox;

            if (map != null)
            {
                List<CVfila> listaParqueos = mapaParqueo.ParqueosDisponibles();

                foreach (CVfila parqueo in listaParqueos)
                {
                    for (int i = 0; i < parqueo.cantidadEspacios; i++)
                    {
                        if (parqueo.espacios[i].Disponible)
                        {
                            string nombre_parqueo = $"Zona: {parqueo.zona}, Fila: {parqueo.filaNumero} - {parqueo.espacios[i].numero}";
                            cmbParqueos.Items.Add(nombre_parqueo);
                        }
                    }                    
                }
            }

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            lbCod.Text = pass.GenerarPassword();
            btnIngresar.Enabled = true;
            btnGenerar.Enabled = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            lbCod.Text = pass.GenerarPassword();
            btnIngresar.Enabled = true;
            btnGenerar.Enabled = false;
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            horaEntrada = DateTime.Now;
            lbfechaentrada.Text = horaEntrada.ToString();
            MessageBox.Show("Bienvenido, a nuestro Estacionamiento");

            //FormSalida salida = new FormSalida();
            //salida.Show();

            // PARTE DE GUARDADO EN LA BASE DE DATOS

            string id = lbCod.Text;

            try
            {
                if (cmbParqueos.SelectedIndex != -1)
                {
                    string parqueoSeleccionado = cmbParqueos.SelectedItem.ToString();

                    // Patrón regex para capturar los componentes
                    Match match = Regex.Match(parqueoSeleccionado, @"Zona:\s*([A-Za-z]),\s*Fila:\s*(\d+)\s*-\s*(\d+)");

                    if (match.Success)
                    {
                        string zona = match.Groups[1].Value;    // "A"
                        int filaInicio = int.Parse(match.Groups[2].Value); // 4
                        int parqueo = int.Parse(match.Groups[3].Value);    // 7

                        Parqueo parqueo1 = new Parqueo()
                        {
                            codigo = id,
                            fechaIngreso = horaEntrada,
                            zona = zona,
                            fila = filaInicio,
                            parqueo = parqueo
                        };

                        registroParqueoService.registrarEntrada(parqueo1);

                        map.CambiarEstadoParqueos(zona, filaInicio, parqueo);

                        PictureBox?.Refresh();

                    }
                }
                else
                {
                    MessageBox.Show("Selecciona el parqueo al que deseas acceder", "Seleciona un parqueo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en la DB");
            }

            this.Close();

        }
    }
}
