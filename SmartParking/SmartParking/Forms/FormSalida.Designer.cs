namespace SmartParking.Forms
{
    partial class FormSalida
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
            this.lbsaludo = new System.Windows.Forms.Label();
            this.lbtotP = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbTimeTot = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbtiempoS = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbtiempoE = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConfirmar = new Guna.UI2.WinForms.Guna2Button();
            this.btnSalir = new Guna.UI2.WinForms.Guna2Button();
            this.btnPagar = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtCod = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPago = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbsaludo
            // 
            this.lbsaludo.AutoSize = true;
            this.lbsaludo.ForeColor = System.Drawing.Color.Black;
            this.lbsaludo.Location = new System.Drawing.Point(83, 255);
            this.lbsaludo.Name = "lbsaludo";
            this.lbsaludo.Size = new System.Drawing.Size(138, 44);
            this.lbsaludo.TabIndex = 8;
            this.lbsaludo.Text = "Gracias por visitarnos\r\n     !Ten un feliz día¡\r\n";
            // 
            // lbtotP
            // 
            this.lbtotP.AutoSize = true;
            this.lbtotP.ForeColor = System.Drawing.Color.Black;
            this.lbtotP.Location = new System.Drawing.Point(169, 195);
            this.lbtotP.Name = "lbtotP";
            this.lbtotP.Size = new System.Drawing.Size(19, 22);
            this.lbtotP.TabIndex = 7;
            this.lbtotP.Text = "...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(23, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 22);
            this.label8.TabIndex = 6;
            this.label8.Text = "Monto a pagar:";
            // 
            // lbTimeTot
            // 
            this.lbTimeTot.AutoSize = true;
            this.lbTimeTot.ForeColor = System.Drawing.Color.Black;
            this.lbTimeTot.Location = new System.Drawing.Point(169, 150);
            this.lbTimeTot.Name = "lbTimeTot";
            this.lbTimeTot.Size = new System.Drawing.Size(19, 22);
            this.lbTimeTot.TabIndex = 5;
            this.lbTimeTot.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(23, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 22);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tiempo estacionado:";
            // 
            // lbtiempoS
            // 
            this.lbtiempoS.AutoSize = true;
            this.lbtiempoS.ForeColor = System.Drawing.Color.Black;
            this.lbtiempoS.Location = new System.Drawing.Point(169, 110);
            this.lbtiempoS.Name = "lbtiempoS";
            this.lbtiempoS.Size = new System.Drawing.Size(19, 22);
            this.lbtiempoS.TabIndex = 3;
            this.lbtiempoS.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(23, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "Fecha de salida:";
            // 
            // lbtiempoE
            // 
            this.lbtiempoE.AutoSize = true;
            this.lbtiempoE.ForeColor = System.Drawing.Color.Black;
            this.lbtiempoE.Location = new System.Drawing.Point(169, 69);
            this.lbtiempoE.Name = "lbtiempoE";
            this.lbtiempoE.Size = new System.Drawing.Size(19, 22);
            this.lbtiempoE.TabIndex = 1;
            this.lbtiempoE.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(23, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha de entrada:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 42);
            this.label2.TabIndex = 2;
            this.label2.Text = "Salida";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(344, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ingrese su codigo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(344, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Monto a pagar";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Animated = true;
            this.btnConfirmar.BorderRadius = 10;
            this.btnConfirmar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirmar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirmar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnConfirmar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnConfirmar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnConfirmar.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(347, 130);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(168, 35);
            this.btnConfirmar.TabIndex = 9;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Animated = true;
            this.btnSalir.AutoRoundedCorners = true;
            this.btnSalir.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSalir.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSalir.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSalir.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSalir.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSalir.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(347, 345);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(167, 35);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
            // 
            // btnPagar
            // 
            this.btnPagar.Animated = true;
            this.btnPagar.AutoRoundedCorners = true;
            this.btnPagar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPagar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPagar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPagar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPagar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnPagar.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.ForeColor = System.Drawing.Color.White;
            this.btnPagar.Location = new System.Drawing.Point(347, 265);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(167, 35);
            this.btnPagar.TabIndex = 11;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.Click += new System.EventHandler(this.guna2Button1_Click_1);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Controls.Add(this.lbsaludo);
            this.guna2GroupBox1.Controls.Add(this.label1);
            this.guna2GroupBox1.Controls.Add(this.lbtiempoE);
            this.guna2GroupBox1.Controls.Add(this.lbtotP);
            this.guna2GroupBox1.Controls.Add(this.label4);
            this.guna2GroupBox1.Controls.Add(this.lbtiempoS);
            this.guna2GroupBox1.Controls.Add(this.label8);
            this.guna2GroupBox1.Controls.Add(this.label6);
            this.guna2GroupBox1.Controls.Add(this.lbTimeTot);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(24, 66);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(296, 314);
            this.guna2GroupBox1.TabIndex = 12;
            this.guna2GroupBox1.Text = "Datos importantes";
            // 
            // txtCod
            // 
            this.txtCod.Animated = true;
            this.txtCod.BorderRadius = 10;
            this.txtCod.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCod.DefaultText = "";
            this.txtCod.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCod.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCod.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCod.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCod.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCod.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCod.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCod.Location = new System.Drawing.Point(347, 88);
            this.txtCod.MaxLength = 5;
            this.txtCod.Name = "txtCod";
            this.txtCod.PlaceholderText = "CODIGO";
            this.txtCod.SelectedText = "";
            this.txtCod.Size = new System.Drawing.Size(168, 34);
            this.txtCod.TabIndex = 13;
            this.txtCod.TextChanged += new System.EventHandler(this.txtCod_TextChanged_1);
            // 
            // txtPago
            // 
            this.txtPago.Animated = true;
            this.txtPago.BorderRadius = 10;
            this.txtPago.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPago.DefaultText = "";
            this.txtPago.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPago.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPago.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPago.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPago.Enabled = false;
            this.txtPago.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPago.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPago.Location = new System.Drawing.Point(348, 223);
            this.txtPago.Name = "txtPago";
            this.txtPago.PlaceholderText = "";
            this.txtPago.SelectedText = "";
            this.txtPago.Size = new System.Drawing.Size(168, 34);
            this.txtPago.TabIndex = 14;
            // 
            // FormSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 427);
            this.Controls.Add(this.txtPago);
            this.Controls.Add(this.txtCod);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "FormSalida";
            this.Text = "FormSalida";
            this.Load += new System.EventHandler(this.FormSalida_Load);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbsaludo;
        private System.Windows.Forms.Label lbtotP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbTimeTot;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbtiempoS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbtiempoE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button btnConfirmar;
        private Guna.UI2.WinForms.Guna2Button btnSalir;
        private Guna.UI2.WinForms.Guna2Button btnPagar;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2TextBox txtCod;
        private Guna.UI2.WinForms.Guna2TextBox txtPago;
    }
}