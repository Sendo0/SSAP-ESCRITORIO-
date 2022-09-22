
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearUsuario));
            this.lblCrearUsuario = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblTipo_user = new System.Windows.Forms.Label();
            this.lblComuna = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.CbTipo_user = new System.Windows.Forms.ComboBox();
            this.btnRegistrarUser = new System.Windows.Forms.Button();
            this.cbComunas = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnRestaurar = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.minimo = new System.Windows.Forms.CheckBox();
            this.minuscula = new System.Windows.Forms.CheckBox();
            this.mayuscula = new System.Windows.Forms.CheckBox();
            this.numero = new System.Windows.Forms.CheckBox();
            this.especial = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtras)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCrearUsuario
            // 
            this.lblCrearUsuario.AutoSize = true;
            this.lblCrearUsuario.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrearUsuario.Location = new System.Drawing.Point(78, 9);
            this.lblCrearUsuario.Name = "lblCrearUsuario";
            this.lblCrearUsuario.Size = new System.Drawing.Size(76, 21);
            this.lblCrearUsuario.TabIndex = 0;
            this.lblCrearUsuario.Text = "Registrar";
            this.lblCrearUsuario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(258, 173);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(247, 20);
            this.txtPass.TabIndex = 2;
            this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(260, 480);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(247, 20);
            this.txtDireccion.TabIndex = 4;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(257, 157);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(99, 13);
            this.lblPass.TabIndex = 7;
            this.lblPass.Text = "Ingrese Contraseña";
            // 
            // lblTipo_user
            // 
            this.lblTipo_user.AutoSize = true;
            this.lblTipo_user.Location = new System.Drawing.Point(257, 339);
            this.lblTipo_user.Name = "lblTipo_user";
            this.lblTipo_user.Size = new System.Drawing.Size(126, 13);
            this.lblTipo_user.TabIndex = 8;
            this.lblTipo_user.Text = "Seleccione Tipo Usuario ";
            // 
            // lblComuna
            // 
            this.lblComuna.AutoSize = true;
            this.lblComuna.Location = new System.Drawing.Point(257, 402);
            this.lblComuna.Name = "lblComuna";
            this.lblComuna.Size = new System.Drawing.Size(101, 13);
            this.lblComuna.TabIndex = 9;
            this.lblComuna.Text = "Seleccione comuna";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(257, 464);
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
            this.CbTipo_user.Location = new System.Drawing.Point(258, 355);
            this.CbTipo_user.Name = "CbTipo_user";
            this.CbTipo_user.Size = new System.Drawing.Size(249, 21);
            this.CbTipo_user.TabIndex = 11;
            // 
            // btnRegistrarUser
            // 
            this.btnRegistrarUser.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRegistrarUser.FlatAppearance.BorderSize = 0;
            this.btnRegistrarUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarUser.Location = new System.Drawing.Point(277, 601);
            this.btnRegistrarUser.Name = "btnRegistrarUser";
            this.btnRegistrarUser.Size = new System.Drawing.Size(208, 38);
            this.btnRegistrarUser.TabIndex = 12;
            this.btnRegistrarUser.Text = "Registrar";
            this.btnRegistrarUser.UseVisualStyleBackColor = false;
            this.btnRegistrarUser.Click += new System.EventHandler(this.btnRegistrarUser_Click);
            // 
            // cbComunas
            // 
            this.cbComunas.BackColor = System.Drawing.SystemColors.Window;
            this.cbComunas.FormattingEnabled = true;
            this.cbComunas.Location = new System.Drawing.Point(258, 418);
            this.cbComunas.Name = "cbComunas";
            this.cbComunas.Size = new System.Drawing.Size(249, 21);
            this.cbComunas.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Linen;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnMaximizar);
            this.panel1.Controls.Add(this.btnRestaurar);
            this.panel1.Controls.Add(this.btnMinimizar);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.lblCrearUsuario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(581, 42);
            this.panel1.TabIndex = 15;
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.Location = new System.Drawing.Point(435, 3);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(72, 34);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximizar.TabIndex = 11;
            this.btnMaximizar.TabStop = false;
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurar.Image = ((System.Drawing.Image)(resources.GetObject("btnRestaurar.Image")));
            this.btnRestaurar.Location = new System.Drawing.Point(435, 2);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(72, 34);
            this.btnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRestaurar.TabIndex = 10;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Visible = false;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(361, 2);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(80, 36);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 9;
            this.btnMinimizar.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(513, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(65, 36);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btnAtras);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 622);
            this.panel2.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // minimo
            // 
            this.minimo.AutoSize = true;
            this.minimo.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimo.Location = new System.Drawing.Point(260, 209);
            this.minimo.Name = "minimo";
            this.minimo.Size = new System.Drawing.Size(149, 19);
            this.minimo.TabIndex = 17;
            this.minimo.Text = "Minimo 8 Caracteres";
            this.minimo.UseVisualStyleBackColor = true;
            // 
            // minuscula
            // 
            this.minuscula.AutoSize = true;
            this.minuscula.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minuscula.Location = new System.Drawing.Point(260, 232);
            this.minuscula.Name = "minuscula";
            this.minuscula.Size = new System.Drawing.Size(173, 19);
            this.minuscula.TabIndex = 18;
            this.minuscula.Text = "Al menos una minuscula";
            this.minuscula.UseVisualStyleBackColor = true;
            // 
            // mayuscula
            // 
            this.mayuscula.AutoSize = true;
            this.mayuscula.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mayuscula.Location = new System.Drawing.Point(260, 255);
            this.mayuscula.Name = "mayuscula";
            this.mayuscula.Size = new System.Drawing.Size(174, 19);
            this.mayuscula.TabIndex = 19;
            this.mayuscula.Text = "Al menos una mayuscula";
            this.mayuscula.UseVisualStyleBackColor = true;
            // 
            // numero
            // 
            this.numero.AutoSize = true;
            this.numero.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numero.Location = new System.Drawing.Point(260, 278);
            this.numero.Name = "numero";
            this.numero.Size = new System.Drawing.Size(151, 19);
            this.numero.TabIndex = 20;
            this.numero.Text = "Al menos un numero";
            this.numero.UseVisualStyleBackColor = true;
            // 
            // especial
            // 
            this.especial.AutoSize = true;
            this.especial.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.especial.Location = new System.Drawing.Point(260, 301);
            this.especial.Name = "especial";
            this.especial.Size = new System.Drawing.Size(206, 19);
            this.especial.TabIndex = 21;
            this.especial.Text = "Al menos un caracter especial";
            this.especial.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(571, 42);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(10, 622);
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(330, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 30);
            this.label1.TabIndex = 24;
            this.label1.Text = "USUARIO";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.Transparent;
            this.btnAtras.Image = ((System.Drawing.Image)(resources.GetObject("btnAtras.Image")));
            this.btnAtras.Location = new System.Drawing.Point(28, 514);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(126, 67);
            this.btnAtras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAtras.TabIndex = 14;
            this.btnAtras.TabStop = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label7.Location = new System.Drawing.Point(27, 584);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "VOLVER ATRAS";
            // 
            // CrearUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(581, 664);
            this.Controls.Add(this.btnRegistrarUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.especial);
            this.Controls.Add(this.numero);
            this.Controls.Add(this.mayuscula);
            this.Controls.Add(this.minuscula);
            this.Controls.Add(this.minimo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbComunas);
            this.Controls.Add(this.CbTipo_user);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblComuna);
            this.Controls.Add(this.lblTipo_user);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CrearUsuario";
            this.Text = "CrearUsuario";
            this.Load += new System.EventHandler(this.CrearUsuario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCrearUsuario;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblTipo_user;
        private System.Windows.Forms.Label lblComuna;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.ComboBox CbTipo_user;
        private System.Windows.Forms.Button btnRegistrarUser;
        private System.Windows.Forms.ComboBox cbComunas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox btnRestaurar;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox minimo;
        private System.Windows.Forms.CheckBox minuscula;
        private System.Windows.Forms.CheckBox mayuscula;
        private System.Windows.Forms.CheckBox numero;
        private System.Windows.Forms.CheckBox especial;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnAtras;
        private System.Windows.Forms.Label label7;
    }
}