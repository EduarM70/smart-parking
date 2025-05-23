﻿namespace SmartParking.Forms
{
    partial class FormEntrada
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
            this.lbfechaentrada = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbCod = new System.Windows.Forms.Label();
            this.label3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerar = new Guna.UI2.WinForms.Guna2Button();
            this.btnIngresar = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cmbParqueos = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbfechaentrada
            // 
            this.lbfechaentrada.AutoSize = true;
            this.lbfechaentrada.BackColor = System.Drawing.Color.Transparent;
            this.lbfechaentrada.ForeColor = System.Drawing.Color.Black;
            this.lbfechaentrada.Location = new System.Drawing.Point(234, 81);
            this.lbfechaentrada.Name = "lbfechaentrada";
            this.lbfechaentrada.Size = new System.Drawing.Size(19, 22);
            this.lbfechaentrada.TabIndex = 4;
            this.lbfechaentrada.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(234, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 22);
            this.label5.TabIndex = 5;
            this.label5.Text = "Fecha de entrada:";
            // 
            // lbCod
            // 
            this.lbCod.AutoSize = true;
            this.lbCod.BackColor = System.Drawing.Color.Transparent;
            this.lbCod.ForeColor = System.Drawing.Color.Black;
            this.lbCod.Location = new System.Drawing.Point(28, 81);
            this.lbCod.Name = "lbCod";
            this.lbCod.Size = new System.Drawing.Size(19, 22);
            this.lbCod.TabIndex = 2;
            this.lbCod.Text = "...";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(31, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Codigo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Registro de Entrada";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Animated = true;
            this.btnGenerar.AutoRoundedCorners = true;
            this.btnGenerar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGenerar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGenerar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Location = new System.Drawing.Point(24, 348);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(179, 41);
            this.btnGenerar.TabIndex = 4;
            this.btnGenerar.Text = "Generar Codigo";
            this.btnGenerar.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.Animated = true;
            this.btnIngresar.AutoRoundedCorners = true;
            this.btnIngresar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIngresar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIngresar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIngresar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnIngresar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnIngresar.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(252, 348);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(187, 41);
            this.btnIngresar.TabIndex = 5;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click_1);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.BorderRadius = 10;
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2GroupBox1.Controls.Add(this.cmbParqueos);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.Controls.Add(this.lbfechaentrada);
            this.guna2GroupBox1.Controls.Add(this.label3);
            this.guna2GroupBox1.Controls.Add(this.lbCod);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(24, 79);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(415, 246);
            this.guna2GroupBox1.TabIndex = 6;
            this.guna2GroupBox1.Text = "Datos de Ingreso";
            // 
            // cmbParqueos
            // 
            this.cmbParqueos.BackColor = System.Drawing.Color.Transparent;
            this.cmbParqueos.BorderRadius = 10;
            this.cmbParqueos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbParqueos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParqueos.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbParqueos.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbParqueos.Font = new System.Drawing.Font("Poppins", 9.75F);
            this.cmbParqueos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbParqueos.ItemHeight = 30;
            this.cmbParqueos.Items.AddRange(new object[] {
            "Entrada Norte",
            "Entrada Este"});
            this.cmbParqueos.Location = new System.Drawing.Point(31, 158);
            this.cmbParqueos.Name = "cmbParqueos";
            this.cmbParqueos.Size = new System.Drawing.Size(357, 36);
            this.cmbParqueos.TabIndex = 21;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(31, 128);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(132, 24);
            this.guna2HtmlLabel1.TabIndex = 22;
            this.guna2HtmlLabel1.Text = "Seleccionar Parqueo:";
            // 
            // FormEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(464, 430);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.label1);
            this.Name = "FormEntrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro Entrada";
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbfechaentrada;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbCod;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2HtmlLabel label3;
        private Guna.UI2.WinForms.Guna2Button btnGenerar;
        private Guna.UI2.WinForms.Guna2Button btnIngresar;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbParqueos;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}