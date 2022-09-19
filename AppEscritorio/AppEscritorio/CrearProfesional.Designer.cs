
namespace AppEscritorio
{
    partial class CrearProfesional
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
            this.btnRegistrarUser = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblRut = new System.Windows.Forms.Label();
            this.lblID_US = new System.Windows.Forms.Label();
            this.txtNombreProf = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtRut = new System.Windows.Forms.TextBox();
            this.txtId_user = new System.Windows.Forms.TextBox();
            this.btnAtras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRegistrarUser
            // 
            this.btnRegistrarUser.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRegistrarUser.FlatAppearance.BorderSize = 0;
            this.btnRegistrarUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarUser.Location = new System.Drawing.Point(144, 322);
            this.btnRegistrarUser.Name = "btnRegistrarUser";
            this.btnRegistrarUser.Size = new System.Drawing.Size(208, 38);
            this.btnRegistrarUser.TabIndex = 23;
            this.btnRegistrarUser.Text = "Registrar";
            this.btnRegistrarUser.UseVisualStyleBackColor = false;
            this.btnRegistrarUser.Click += new System.EventHandler(this.btnRegistrarUser_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(144, 245);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 21;
            this.lblEstado.Text = "Estado";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(144, 189);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(137, 13);
            this.lblNombre.TabIndex = 20;
            this.lblNombre.Text = "Ingrese Nombre Profesional";
            // 
            // lblRut
            // 
            this.lblRut.AutoSize = true;
            this.lblRut.Location = new System.Drawing.Point(141, 133);
            this.lblRut.Name = "lblRut";
            this.lblRut.Size = new System.Drawing.Size(68, 13);
            this.lblRut.TabIndex = 18;
            this.lblRut.Text = "Ingrese RUT";
            this.lblRut.Click += new System.EventHandler(this.lblPass_Click);
            // 
            // lblID_US
            // 
            this.lblID_US.AutoSize = true;
            this.lblID_US.Location = new System.Drawing.Point(144, 68);
            this.lblID_US.Name = "lblID_US";
            this.lblID_US.Size = new System.Drawing.Size(111, 13);
            this.lblID_US.TabIndex = 17;
            this.lblID_US.Text = "Insertar ID Profesional";
            // 
            // txtNombreProf
            // 
            this.txtNombreProf.Location = new System.Drawing.Point(144, 209);
            this.txtNombreProf.Name = "txtNombreProf";
            this.txtNombreProf.Size = new System.Drawing.Size(208, 20);
            this.txtNombreProf.TabIndex = 16;
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(144, 261);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(208, 20);
            this.txtEstado.TabIndex = 15;
            // 
            // txtRut
            // 
            this.txtRut.Location = new System.Drawing.Point(144, 149);
            this.txtRut.Name = "txtRut";
            this.txtRut.Size = new System.Drawing.Size(208, 20);
            this.txtRut.TabIndex = 14;
            // 
            // txtId_user
            // 
            this.txtId_user.Location = new System.Drawing.Point(144, 99);
            this.txtId_user.Name = "txtId_user";
            this.txtId_user.Size = new System.Drawing.Size(208, 20);
            this.txtId_user.TabIndex = 13;
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(12, 12);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(75, 23);
            this.btnAtras.TabIndex = 24;
            this.btnAtras.Text = "Volver";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // CrearProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 450);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnRegistrarUser);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblRut);
            this.Controls.Add(this.lblID_US);
            this.Controls.Add(this.txtNombreProf);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtRut);
            this.Controls.Add(this.txtId_user);
            this.Name = "CrearProfesional";
            this.Text = "CrearProfesional";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegistrarUser;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblRut;
        private System.Windows.Forms.Label lblID_US;
        private System.Windows.Forms.TextBox txtNombreProf;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtRut;
        private System.Windows.Forms.TextBox txtId_user;
        private System.Windows.Forms.Button btnAtras;
    }
}