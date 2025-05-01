using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartParking.Formularios
{
    public partial class Login : Form
    {
        // Para cargar fuentes desde recursos si es necesario
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        private Font interRegular;
        private Font interBold;

        public Login()
        {
            InitializeComponent();
            LoadCustomFont();            
        }

        private void LoadCustomFont()
        {
            try
            {
                // Intenta cargar la fuente Inter (debe estar instalada en el sistema)
                interRegular = new Font("Inter", 10f);
                interBold = new Font("Inter", 12f, FontStyle.Bold);
            }
            catch
            {
                // Fallback a fuentes estándar si Inter no está disponible
                interRegular = new Font("Arial", 10f);
                interBold = new Font("Arial", 12f, FontStyle.Bold);
                MessageBox.Show("La fuente 'Inter' no está instalada en el sistema. Se usará Arial como alternativa.",
                              "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        

    }
}
