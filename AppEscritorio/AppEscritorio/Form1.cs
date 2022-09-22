using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Runtime.InteropServices;
namespace AppEscritorio
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void formLogin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelPass_Click(object sender, EventArgs e)
        {

        }

        OracleConnection conexion = new OracleConnection("DATA SOURCE = xe; PASSWORD=123456;USER ID = SSAP");
        private void btnLogin_Click(object sender, EventArgs e)
        {
            conexion.Open();
            OracleCommand comando = new OracleCommand("SELECT * FROM USUARIO WHERE ID_USUARIO = :ID_USUARIO AND CONTRASEÑA = :CONTRASEÑA AND TIPO = :TIPO", conexion);
            comando.Parameters.AddWithValue(":ID_USUARIO", txtUsuario.Text);
            comando.Parameters.AddWithValue(":CONTRASEÑA", txtPass.Text.ToUpper());
            comando.Parameters.AddWithValue(":TIPO", "ADMINISTRADOR");
            OracleDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                
                Form menu = new Menu();
                menu.Show();
                //formLogin formulario = new formLogin();
                conexion.Close();
                //formulario.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("No se encontro");
            }
            conexion.Close();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
 
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
                txtUsuario.Text = "ID Usuario";
            txtUsuario.ForeColor = Color.DarkGray;
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "ID Usuario")
                txtUsuario.Text = null;
            txtUsuario.ForeColor = Color.Black;
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
                txtPass.Text = "Contraseña";
            txtPass.ForeColor = Color.DarkGray;
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
                txtPass.Text = null;
            txtPass.ForeColor = Color.Black;
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            conexion.Open();
            OracleCommand comando = new OracleCommand("SELECT * FROM USUARIO WHERE ID_USUARIO = :ID_USUARIO AND CONTRASEÑA = :CONTRASEÑA AND TIPO = :TIPO", conexion);
            comando.Parameters.AddWithValue(":ID_USUARIO", txtUsuario.Text);
            comando.Parameters.AddWithValue(":CONTRASEÑA", txtPass.Text.ToUpper());
            comando.Parameters.AddWithValue(":TIPO", "ADMINISTRADOR");
            OracleDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {

                Form menu = new Menu();
                menu.Show();
                //formLogin formulario = new formLogin();
                conexion.Close();
                //formulario.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("No se encontro");
            }
            conexion.Close();
        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
