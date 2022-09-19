
namespace AppEscritorio
{
    partial class CrearUsuario
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
            this.lblCrearUsuario = new System.Windows.Forms.Label();
            this.txtId_user = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtIdComu = new System.Windows.Forms.TextBox();
            this.lblID_US = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblTipo_user = new System.Windows.Forms.Label();
            this.lblComuna = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.CbTipo_user = new System.Windows.Forms.ComboBox();
            this.btnRegistrarUser = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCrearUsuario
            // 
            this.lblCrearUsuario.AutoSize = true;
            this.lblCrearUsuario.Location = new System.Drawing.Point(77, 26);
            this.lblCrearUsuario.Name = "lblCrearUsuario";
            this.lblCrearUsuario.Size = new System.Drawing.Size(103, 13);
            this.lblCrearUsuario.TabIndex = 0;
            this.lblCrearUsuario.Text = "Creacion de Usuario";
            this.lblCrearUsuario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtId_user
            // 
            this.txtId_user.Location = new System.Drawing.Point(80, 113);
            this.txtId_user.Name = "txtId_user";
            this.txtId_user.Size = new System.Drawing.Size(208, 20);
            this.txtId_user.TabIndex = 1;
            this.txtId_user.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(80, 163);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(208, 20);
            this.txtPass.TabIndex = 2;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(80, 315);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(208, 20);
            this.txtDireccion.TabIndex = 4;
            // 
            // txtIdComu
            // 
            this.txtIdComu.Location = new System.Drawing.Point(80, 263);
            this.txtIdComu.Name = "txtIdComu";
            this.txtIdComu.Size = new System.Drawing.Size(208, 20);
            this.txtIdComu.TabIndex = 5;
            // 
            // lblID_US
            // 
            this.lblID_US.AutoSize = true;
            this.lblID_US.Location = new System.Drawing.Point(80, 82);
            this.lblID_US.Name = "lblID_US";
            this.lblID_US.Size = new System.Drawing.Size(88, 13);
            this.lblID_US.TabIndex = 6;
            this.lblID_US.Text = "Crear ID_Usuario";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(77, 147);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(99, 13);
            this.lblPass.TabIndex = 7;
            this.lblPass.Text = "Ingrese Contraseña";
            // 
            // lblTipo_user
            // 
            this.lblTipo_user.AutoSize = true;
            this.lblTipo_user.Location = new System.Drawing.Point(80, 196);
            this.lblTipo_user.Name = "lblTipo_user";
            this.lblTipo_user.Size = new System.Drawing.Size(109, 13);
            this.lblTipo_user.TabIndex = 8;
            this.lblTipo_user.Text = "Seleccione Tipo User";
            // 
            // lblComuna
            // 
            this.lblComuna.AutoSize = true;
            this.lblComuna.Location = new System.Drawing.Point(80, 243);
            this.lblComuna.Name = "lblComuna";
            this.lblComuna.Size = new System.Drawing.Size(155, 13);
            this.lblComuna.TabIndex = 9;
            this.lblComuna.Text = "Ingresar Codigo Postal Comuna";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(80, 299);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(90, 13);
            this.lblDireccion.TabIndex = 10;
            this.lblDireccion.Text = "Ingrese Direccion";
            // 
            // CbTipo_user
            // 
            this.CbTipo_user.FormattingEnabled = true;
            this.CbTipo_user.Items.AddRange(new object[] {
            "Administrador",
            "Profesional",
            "Cliente"});
            this.CbTipo_user.Location = new System.Drawing.Point(80, 212);
            this.CbTipo_user.Name = "CbTipo_user";
            this.CbTipo_user.Size = new System.Drawing.Size(208, 21);
            this.CbTipo_user.TabIndex = 11;
            // 
            // btnRegistrarUser
            // 
            this.btnRegistrarUser.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRegistrarUser.FlatAppearance.BorderSize = 0;
            this.btnRegistrarUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarUser.Location = new System.Drawing.Point(80, 358);
            this.btnRegistrarUser.Name = "btnRegistrarUser";
            this.btnRegistrarUser.Size = new System.Drawing.Size(208, 38);
            this.btnRegistrarUser.TabIndex = 12;
            this.btnRegistrarUser.Text = "Registrar";
            this.btnRegistrarUser.UseVisualStyleBackColor = false;
            this.btnRegistrarUser.Click += new System.EventHandler(this.btnRegistrarUser_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(114, 415);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(143, 23);
            this.btnVolver.TabIndex = 13;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.button1_Click);
            // 
            // CrearUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 450);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnRegistrarUser);
            this.Controls.Add(this.CbTipo_user);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblComuna);
            this.Controls.Add(this.lblTipo_user);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblID_US);
            this.Controls.Add(this.txtIdComu);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtId_user);
            this.Controls.Add(this.lblCrearUsuario);
            this.Name = "CrearUsuario";
            this.Text = "CrearUsuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCrearUsuario;
        private System.Windows.Forms.TextBox txtId_user;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtIdComu;
        private System.Windows.Forms.Label lblID_US;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblTipo_user;
        private System.Windows.Forms.Label lblComuna;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.ComboBox CbTipo_user;
        private System.Windows.Forms.Button btnRegistrarUser;
        private System.Windows.Forms.Button btnVolver;
    }
}