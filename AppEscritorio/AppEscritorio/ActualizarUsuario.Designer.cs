
namespace AppEscritorio
{
    partial class ActualizarUsuario
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnRegistrarUser = new System.Windows.Forms.Button();
            this.CbTipo_user = new System.Windows.Forms.ComboBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblComuna = new System.Windows.Forms.Label();
            this.lblTipo_user = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblID_US = new System.Windows.Forms.Label();
            this.txtIdComu = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtId_user = new System.Windows.Forms.TextBox();
            this.lblCrearUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(91, 405);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(143, 23);
            this.btnVolver.TabIndex = 26;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnRegistrarUser
            // 
            this.btnRegistrarUser.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRegistrarUser.FlatAppearance.BorderSize = 0;
            this.btnRegistrarUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarUser.Location = new System.Drawing.Point(57, 348);
            this.btnRegistrarUser.Name = "btnRegistrarUser";
            this.btnRegistrarUser.Size = new System.Drawing.Size(208, 38);
            this.btnRegistrarUser.TabIndex = 25;
            this.btnRegistrarUser.Text = "Actualizar";
            this.btnRegistrarUser.UseVisualStyleBackColor = false;
            this.btnRegistrarUser.Click += new System.EventHandler(this.btnRegistrarUser_Click);
            // 
            // CbTipo_user
            // 
            this.CbTipo_user.FormattingEnabled = true;
            this.CbTipo_user.Items.AddRange(new object[] {
            "Administrador",
            "Profesional",
            "Cliente"});
            this.CbTipo_user.Location = new System.Drawing.Point(57, 202);
            this.CbTipo_user.Name = "CbTipo_user";
            this.CbTipo_user.Size = new System.Drawing.Size(208, 21);
            this.CbTipo_user.TabIndex = 24;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(57, 289);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(125, 13);
            this.lblDireccion.TabIndex = 23;
            this.lblDireccion.Text = "Ingrese Nueva Direccion";
            // 
            // lblComuna
            // 
            this.lblComuna.AutoSize = true;
            this.lblComuna.Location = new System.Drawing.Point(57, 233);
            this.lblComuna.Name = "lblComuna";
            this.lblComuna.Size = new System.Drawing.Size(190, 13);
            this.lblComuna.TabIndex = 22;
            this.lblComuna.Text = "Ingresar Nuevo Codigo Postal Comuna";
            // 
            // lblTipo_user
            // 
            this.lblTipo_user.AutoSize = true;
            this.lblTipo_user.Location = new System.Drawing.Point(57, 186);
            this.lblTipo_user.Name = "lblTipo_user";
            this.lblTipo_user.Size = new System.Drawing.Size(109, 13);
            this.lblTipo_user.TabIndex = 21;
            this.lblTipo_user.Text = "Seleccione Tipo User";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(54, 137);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(134, 13);
            this.lblPass.TabIndex = 20;
            this.lblPass.Text = "Ingrese Nueva Contraseña";
            // 
            // lblID_US
            // 
            this.lblID_US.AutoSize = true;
            this.lblID_US.Location = new System.Drawing.Point(57, 72);
            this.lblID_US.Name = "lblID_US";
            this.lblID_US.Size = new System.Drawing.Size(101, 13);
            this.lblID_US.TabIndex = 19;
            this.lblID_US.Text = "Ingresar ID_Usuario";
            this.lblID_US.Click += new System.EventHandler(this.lblID_US_Click);
            // 
            // txtIdComu
            // 
            this.txtIdComu.Location = new System.Drawing.Point(57, 253);
            this.txtIdComu.Name = "txtIdComu";
            this.txtIdComu.Size = new System.Drawing.Size(208, 20);
            this.txtIdComu.TabIndex = 18;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(57, 305);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(208, 20);
            this.txtDireccion.TabIndex = 17;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(57, 153);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(208, 20);
            this.txtPass.TabIndex = 16;
            // 
            // txtId_user
            // 
            this.txtId_user.Location = new System.Drawing.Point(57, 103);
            this.txtId_user.Name = "txtId_user";
            this.txtId_user.Size = new System.Drawing.Size(208, 20);
            this.txtId_user.TabIndex = 15;
            // 
            // lblCrearUsuario
            // 
            this.lblCrearUsuario.AutoSize = true;
            this.lblCrearUsuario.Location = new System.Drawing.Point(54, 16);
            this.lblCrearUsuario.Name = "lblCrearUsuario";
            this.lblCrearUsuario.Size = new System.Drawing.Size(103, 13);
            this.lblCrearUsuario.TabIndex = 14;
            this.lblCrearUsuario.Text = "Creacion de Usuario";
            this.lblCrearUsuario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ActualizarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 450);
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
            this.Name = "ActualizarUsuario";
            this.Text = "ActualizarUsuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnRegistrarUser;
        private System.Windows.Forms.ComboBox CbTipo_user;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblComuna;
        private System.Windows.Forms.Label lblTipo_user;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblID_US;
        private System.Windows.Forms.TextBox txtIdComu;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtId_user;
        private System.Windows.Forms.Label lblCrearUsuario;
    }
}