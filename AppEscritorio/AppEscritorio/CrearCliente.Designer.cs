
namespace AppEscritorio
{
    partial class CrearCliente
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
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.txtRubroEm = new System.Windows.Forms.TextBox();
            this.txtCantTra = new System.Windows.Forms.TextBox();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.txtRutCliente = new System.Windows.Forms.TextBox();
            this.txtNomEmpresa = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRutCliente = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Location = new System.Drawing.Point(75, 356);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(238, 29);
            this.btnRegistrar.TabIndex = 0;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // txtRubroEm
            // 
            this.txtRubroEm.Location = new System.Drawing.Point(99, 201);
            this.txtRubroEm.Name = "txtRubroEm";
            this.txtRubroEm.Size = new System.Drawing.Size(191, 20);
            this.txtRubroEm.TabIndex = 1;
            // 
            // txtCantTra
            // 
            this.txtCantTra.Location = new System.Drawing.Point(99, 246);
            this.txtCantTra.Name = "txtCantTra";
            this.txtCantTra.Size = new System.Drawing.Size(191, 20);
            this.txtCantTra.TabIndex = 2;
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Location = new System.Drawing.Point(99, 60);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(191, 20);
            this.txtIdUsuario.TabIndex = 3;
            // 
            // txtRutCliente
            // 
            this.txtRutCliente.Location = new System.Drawing.Point(99, 110);
            this.txtRutCliente.Name = "txtRutCliente";
            this.txtRutCliente.Size = new System.Drawing.Size(191, 20);
            this.txtRutCliente.TabIndex = 4;
            // 
            // txtNomEmpresa
            // 
            this.txtNomEmpresa.Location = new System.Drawing.Point(99, 154);
            this.txtNomEmpresa.Name = "txtNomEmpresa";
            this.txtNomEmpresa.Size = new System.Drawing.Size(191, 20);
            this.txtNomEmpresa.TabIndex = 5;
            this.txtNomEmpresa.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(99, 290);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(191, 20);
            this.txtEstado.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Id usuario";
            // 
            // lblRutCliente
            // 
            this.lblRutCliente.AutoSize = true;
            this.lblRutCliente.Location = new System.Drawing.Point(99, 94);
            this.lblRutCliente.Name = "lblRutCliente";
            this.lblRutCliente.Size = new System.Drawing.Size(59, 13);
            this.lblRutCliente.TabIndex = 8;
            this.lblRutCliente.Text = "Rut Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nombre Empresa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Rubro Empresa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cantidad Trabajadores";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Estado";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(154, 404);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 13;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // CrearCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 450);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRutCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtNomEmpresa);
            this.Controls.Add(this.txtRutCliente);
            this.Controls.Add(this.txtIdUsuario);
            this.Controls.Add(this.txtCantTra);
            this.Controls.Add(this.txtRubroEm);
            this.Controls.Add(this.btnRegistrar);
            this.Name = "CrearCliente";
            this.Text = "        ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.TextBox txtRubroEm;
        private System.Windows.Forms.TextBox txtCantTra;
        private System.Windows.Forms.TextBox txtIdUsuario;
        private System.Windows.Forms.TextBox txtRutCliente;
        private System.Windows.Forms.TextBox txtNomEmpresa;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRutCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnVolver;
    }
}