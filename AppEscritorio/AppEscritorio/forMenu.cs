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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void limpiar()
        {
            dgvUsuarios.Columns[0].Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        OracleConnection conexion = new OracleConnection("DATA SOURCE = xe; PASSWORD=1234;USER ID = BDD_LOCAL");
        private void button2_Click(object sender, EventArgs e)
        {
            conexion.Open();
            OracleCommand comando = new OracleCommand("seleccionarUsuarios",conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registro", OracleType.Cursor).Direction = ParameterDirection.Output;


            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvUsuarios.DataSource = tabla;
            conexion.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            Form crear = new CrearUsuario();
            crear.Show();
            this.Hide();
                
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            conexion.Open();
            OracleCommand comando = new OracleCommand("seleccionarClientes", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registro", OracleType.Cursor).Direction = ParameterDirection.Output;


            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvUsuarios.DataSource = tabla;
            conexion.Close();
        }

        private void btnProfesionales_Click(object sender, EventArgs e)
        {
            conexion.Open();
            OracleCommand comando = new OracleCommand("seleccionarProfesionales", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registro", OracleType.Cursor).Direction = ParameterDirection.Output;


            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvUsuarios.DataSource = tabla;
            conexion.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

      

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.limpiar();
            if (e.ColumnIndex == dgvUsuarios.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell chkMarcar = (DataGridViewCheckBoxCell)dgvUsuarios.Rows[e.RowIndex].Cells["Seleccionar"];
                chkMarcar.Value = !Convert.ToBoolean(chkMarcar.Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            OracleCommand comando = new OracleCommand("eliminarUsuario", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("idp", OracleType.Number).Value = txtBuscar.Text;
            comando.ExecuteNonQuery();
            MessageBox.Show("Usuario Eliminado");
            conexion.Close();
         
        }

        private void btnCrearCliente_Click(object sender, EventArgs e)
        {
            Form crear = new CrearCliente();
            crear.Show();
            this.Hide();
        }

        private void btnCrearProfesional_Click(object sender, EventArgs e)
        {
            Form crear = new CrearProfesional();
            crear.Show();
            this.Hide();
        }

        private void btnActualizarUsuario_Click(object sender, EventArgs e)
        {
            Form crear = new ActualizarUsuario();
            crear.Show();
            this.Hide();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Form logout = new formLogin();
            logout.Show();
            this.Hide();

        }

        private void Usertxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            OracleCommand comando = new OracleCommand("buscarUsuario" , conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("idp", OracleType.Number).Value = txtBuscar.Text;
            comando.Parameters.Add("registro",OracleType.Cursor).Direction = ParameterDirection.Output;
            comando.ExecuteNonQuery();
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvUsuarios.DataSource = tabla;
            conexion.Close();

        }

        private void btnCrearContrato_Click(object sender, EventArgs e)
        {
            Form crearContrato = new crearContrato();
            crearContrato.Show();
            this.Hide();
        }

        private void btnCapacitacion_Click(object sender, EventArgs e)
        {
            Form crearCapa = new crearCapacitacion();
            crearCapa.Show();
            this.Hide();
        }
    }
}
