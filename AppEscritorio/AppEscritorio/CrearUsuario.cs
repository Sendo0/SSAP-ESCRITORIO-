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


namespace AppEscritorio
{
    public partial class CrearUsuario : Form
    {
        public CrearUsuario()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        OracleConnection conexion = new OracleConnection("DATA SOURCE = xe; PASSWORD=1234;USER ID = BDD_LOCAL");
        private void btnRegistrarUser_Click(object sender, EventArgs e)
        {

            try
            {
                txtId_user.Text = txtId_user.Text.ToUpper();
                txtPass.Text = txtPass.Text.ToUpper();
                CbTipo_user.Text = CbTipo_user.Text.ToUpper();
                txtIdComu.Text = txtIdComu.Text.ToUpper();
                txtDireccion.Text = txtDireccion.Text.ToUpper();
                conexion.Open();
                OracleCommand comando = new OracleCommand("insertar", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("id_usu", OracleType.Int32).Value = txtId_user.Text;
                comando.Parameters.Add("pass", OracleType.VarChar).Value = txtPass.Text;
                comando.Parameters.Add("tipo", OracleType.VarChar).Value = CbTipo_user.Text;
                comando.Parameters.Add("id_comu", OracleType.Int32).Value = txtIdComu.Text;
                comando.Parameters.Add("direc", OracleType.VarChar).Value = txtDireccion.Text;
                comando.ExecuteNonQuery();
                MessageBox.Show("Usuario Insertado");
                this.Hide();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Algo Fallo...");
                ;
            }
            conexion.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form crear = new Menu();
            crear.Show();
            this.Hide();
        }
    }
}

