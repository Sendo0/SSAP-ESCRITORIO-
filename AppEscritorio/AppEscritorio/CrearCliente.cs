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
    public partial class CrearCliente : Form
    {
        public CrearCliente()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        OracleConnection conexion = new OracleConnection("DATA SOURCE = xe; PASSWORD=1234;USER ID = BDD_LOCAL");
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                txtIdUsuario.Text = txtIdUsuario.Text.ToUpper();
                txtRutCliente.Text = txtRutCliente.Text.ToUpper();
                txtNomEmpresa.Text = txtNomEmpresa.Text.ToUpper();
                txtRubroEm.Text = txtRubroEm.Text.ToUpper();
                txtCantTra.Text = txtCantTra.Text.ToUpper();
                txtEstado.Text = txtEstado.Text.ToUpper();
                conexion.Open();
                OracleCommand comando = new OracleCommand("insertarCliente", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("id_usu", OracleType.Int32).Value = txtIdUsuario.Text;
                comando.Parameters.Add("rutCli", OracleType.VarChar).Value = txtRutCliente.Text;
                comando.Parameters.Add("nomEmpre", OracleType.VarChar).Value = txtNomEmpresa.Text;
                comando.Parameters.Add("rubroEmpre", OracleType.VarChar).Value = txtRubroEm.Text;
                comando.Parameters.Add("cant", OracleType.VarChar).Value = txtCantTra.Text;
                comando.Parameters.Add("estado", OracleType.Int32).Value = txtEstado.Text;
                comando.ExecuteNonQuery();
                MessageBox.Show("Usuario Cliente Insertado");
                this.Hide();

            }
            catch (Exception)
            {
                MessageBox.Show("Algo Fallo...");
                ;
            }
            conexion.Close();

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form crear = new Menu();
            crear.Show();
            this.Hide();
        }
    }
}
