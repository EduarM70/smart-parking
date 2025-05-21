namespace SmartParking.Forms.Maps
{
    partial class Map1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Map1));
            this.Bienvenido = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblHora = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDate2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.PictureBoxMap = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblZona = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblEntraZona = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTotalEspacios = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ContainerControl1 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.guna2HtmlLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDisponibles = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ContainerControl2 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.guna2HtmlLabel11 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblOcupados = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMap)).BeginInit();
            this.guna2ContainerControl1.SuspendLayout();
            this.guna2ContainerControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Bienvenido
            // 
            this.Bienvenido.BackColor = System.Drawing.Color.Transparent;
            this.Bienvenido.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Bold);
            this.Bienvenido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(16)))), ((int)(((byte)(101)))));
            this.Bienvenido.Location = new System.Drawing.Point(40, 30);
            this.Bienvenido.Name = "Bienvenido";
            this.Bienvenido.Size = new System.Drawing.Size(115, 36);
            this.Bienvenido.TabIndex = 1;
            this.Bienvenido.Text = "Bienvenido";
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Poppins SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblDate.Location = new System.Drawing.Point(40, 57);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(183, 24);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "¡Es un gusto tenerte por aquí!";
            // 
            // lblHora
            // 
            this.lblHora.BackColor = System.Drawing.Color.Transparent;
            this.lblHora.Font = new System.Drawing.Font("Poppins", 65F);
            this.lblHora.Location = new System.Drawing.Point(40, 83);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(232, 156);
            this.lblHora.TabIndex = 3;
            this.lblHora.Text = "22:08";
            // 
            // lblDate2
            // 
            this.lblDate2.BackColor = System.Drawing.Color.Transparent;
            this.lblDate2.Font = new System.Drawing.Font("Poppins SemiBold", 11F, System.Drawing.FontStyle.Bold);
            this.lblDate2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblDate2.Location = new System.Drawing.Point(45, 199);
            this.lblDate2.Name = "lblDate2";
            this.lblDate2.Size = new System.Drawing.Size(254, 28);
            this.lblDate2.TabIndex = 4;
            this.lblDate2.Text = "Hoy es lunes 19 de mayo de 2025";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.PictureBoxMap);
            this.guna2Panel1.Location = new System.Drawing.Point(344, 12);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(987, 727);
            this.guna2Panel1.TabIndex = 5;
            // 
            // PictureBoxMap
            // 
            this.PictureBoxMap.Image = ((System.Drawing.Image)(resources.GetObject("PictureBoxMap.Image")));
            this.PictureBoxMap.ImageRotate = 0F;
            this.PictureBoxMap.Location = new System.Drawing.Point(3, 3);
            this.PictureBoxMap.Name = "PictureBoxMap";
            this.PictureBoxMap.Size = new System.Drawing.Size(984, 724);
            this.PictureBoxMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxMap.TabIndex = 0;
            this.PictureBoxMap.TabStop = false;
            this.PictureBoxMap.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxMap_Paint);
            // 
            // lblZona
            // 
            this.lblZona.BackColor = System.Drawing.Color.Transparent;
            this.lblZona.Font = new System.Drawing.Font("Poppins", 75F, System.Drawing.FontStyle.Bold);
            this.lblZona.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(16)))), ((int)(((byte)(101)))));
            this.lblZona.Location = new System.Drawing.Point(45, 211);
            this.lblZona.Name = "lblZona";
            this.lblZona.Size = new System.Drawing.Size(77, 179);
            this.lblZona.TabIndex = 6;
            this.lblZona.Text = "A";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(141, 248);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(59, 25);
            this.guna2HtmlLabel4.TabIndex = 7;
            this.guna2HtmlLabel4.Text = "Entrada:";
            // 
            // lblEntraZona
            // 
            this.lblEntraZona.BackColor = System.Drawing.Color.Transparent;
            this.lblEntraZona.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.lblEntraZona.ForeColor = System.Drawing.Color.Black;
            this.lblEntraZona.Location = new System.Drawing.Point(141, 269);
            this.lblEntraZona.Name = "lblEntraZona";
            this.lblEntraZona.Size = new System.Drawing.Size(131, 30);
            this.lblEntraZona.TabIndex = 8;
            this.lblEntraZona.Text = "Entrada Norte A";
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(16)))), ((int)(((byte)(101)))));
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(141, 305);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(86, 30);
            this.guna2HtmlLabel6.TabIndex = 9;
            this.guna2HtmlLabel6.Text = "ESPACIOS:";
            // 
            // lblTotalEspacios
            // 
            this.lblTotalEspacios.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalEspacios.Font = new System.Drawing.Font("Poppins SemiBold", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalEspacios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(16)))), ((int)(((byte)(101)))));
            this.lblTotalEspacios.Location = new System.Drawing.Point(242, 301);
            this.lblTotalEspacios.Name = "lblTotalEspacios";
            this.lblTotalEspacios.Size = new System.Drawing.Size(30, 39);
            this.lblTotalEspacios.TabIndex = 10;
            this.lblTotalEspacios.Text = "38";
            this.lblTotalEspacios.Click += new System.EventHandler(this.guna2HtmlLabel7_Click);
            // 
            // guna2ContainerControl1
            // 
            this.guna2ContainerControl1.BorderRadius = 10;
            this.guna2ContainerControl1.Controls.Add(this.guna2HtmlLabel10);
            this.guna2ContainerControl1.Controls.Add(this.lblDisponibles);
            this.guna2ContainerControl1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(16)))), ((int)(((byte)(101)))));
            this.guna2ContainerControl1.Location = new System.Drawing.Point(45, 355);
            this.guna2ContainerControl1.Name = "guna2ContainerControl1";
            this.guna2ContainerControl1.Size = new System.Drawing.Size(270, 70);
            this.guna2ContainerControl1.TabIndex = 11;
            this.guna2ContainerControl1.Text = "guna2ContainerControl1";
            // 
            // guna2HtmlLabel10
            // 
            this.guna2HtmlLabel10.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel10.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel10.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel10.Location = new System.Drawing.Point(92, 25);
            this.guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            this.guna2HtmlLabel10.Size = new System.Drawing.Size(143, 25);
            this.guna2HtmlLabel10.TabIndex = 13;
            this.guna2HtmlLabel10.Text = "Espacios Disponibles";
            // 
            // lblDisponibles
            // 
            this.lblDisponibles.BackColor = System.Drawing.Color.Transparent;
            this.lblDisponibles.Font = new System.Drawing.Font("Poppins", 20F, System.Drawing.FontStyle.Bold);
            this.lblDisponibles.ForeColor = System.Drawing.Color.White;
            this.lblDisponibles.Location = new System.Drawing.Point(36, 13);
            this.lblDisponibles.Name = "lblDisponibles";
            this.lblDisponibles.Size = new System.Drawing.Size(36, 50);
            this.lblDisponibles.TabIndex = 14;
            this.lblDisponibles.Text = "25";
            this.lblDisponibles.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2ContainerControl2
            // 
            this.guna2ContainerControl2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(16)))), ((int)(((byte)(101)))));
            this.guna2ContainerControl2.BorderRadius = 10;
            this.guna2ContainerControl2.BorderThickness = 2;
            this.guna2ContainerControl2.Controls.Add(this.guna2HtmlLabel11);
            this.guna2ContainerControl2.Controls.Add(this.lblOcupados);
            this.guna2ContainerControl2.Location = new System.Drawing.Point(45, 437);
            this.guna2ContainerControl2.Name = "guna2ContainerControl2";
            this.guna2ContainerControl2.Size = new System.Drawing.Size(269, 71);
            this.guna2ContainerControl2.TabIndex = 12;
            this.guna2ContainerControl2.Text = "guna2ContainerControl2";
            // 
            // guna2HtmlLabel11
            // 
            this.guna2HtmlLabel11.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel11.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(16)))), ((int)(((byte)(101)))));
            this.guna2HtmlLabel11.Location = new System.Drawing.Point(92, 25);
            this.guna2HtmlLabel11.Name = "guna2HtmlLabel11";
            this.guna2HtmlLabel11.Size = new System.Drawing.Size(134, 25);
            this.guna2HtmlLabel11.TabIndex = 15;
            this.guna2HtmlLabel11.Text = "Espacios Ocupados";
            // 
            // lblOcupados
            // 
            this.lblOcupados.BackColor = System.Drawing.Color.Transparent;
            this.lblOcupados.Font = new System.Drawing.Font("Poppins", 20F, System.Drawing.FontStyle.Bold);
            this.lblOcupados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(16)))), ((int)(((byte)(101)))));
            this.lblOcupados.Location = new System.Drawing.Point(45, 11);
            this.lblOcupados.Name = "lblOcupados";
            this.lblOcupados.Size = new System.Drawing.Size(18, 50);
            this.lblOcupados.TabIndex = 13;
            this.lblOcupados.Text = "2";
            this.lblOcupados.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOcupados.Click += new System.EventHandler(this.guna2HtmlLabel8_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderRadius = 10;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.guna2Button2.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button2.Image")));
            this.guna2Button2.Location = new System.Drawing.Point(44, 545);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(270, 45);
            this.guna2Button2.TabIndex = 31;
            this.guna2Button2.Text = "Marca Entrada";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.BorderThickness = 2;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.Location = new System.Drawing.Point(44, 600);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(270, 45);
            this.guna2Button1.TabIndex = 32;
            this.guna2Button1.Text = "Marcar Salida";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // guna2Button3
            // 
            this.guna2Button3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.guna2Button3.BorderRadius = 10;
            this.guna2Button3.BorderThickness = 2;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.FillColor = System.Drawing.Color.White;
            this.guna2Button3.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.guna2Button3.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button3.Image")));
            this.guna2Button3.Location = new System.Drawing.Point(45, 680);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(270, 45);
            this.guna2Button3.TabIndex = 33;
            this.guna2Button3.Text = "Regresar";
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // Map1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1343, 751);
            this.Controls.Add(this.guna2Button3);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.lblDate2);
            this.Controls.Add(this.guna2ContainerControl2);
            this.Controls.Add(this.guna2ContainerControl1);
            this.Controls.Add(this.lblTotalEspacios);
            this.Controls.Add(this.guna2HtmlLabel6);
            this.Controls.Add(this.lblEntraZona);
            this.Controls.Add(this.guna2HtmlLabel4);
            this.Controls.Add(this.lblZona);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.Bienvenido);
            this.Name = "Map1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mapa Completo";
            this.Load += new System.EventHandler(this.Map1_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMap)).EndInit();
            this.guna2ContainerControl1.ResumeLayout(false);
            this.guna2ContainerControl1.PerformLayout();
            this.guna2ContainerControl2.ResumeLayout(false);
            this.guna2ContainerControl2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel Bienvenido;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHora;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDate2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox PictureBoxMap;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblZona;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEntraZona;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalEspacios;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDisponibles;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblOcupados;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel10;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel11;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
    }
}