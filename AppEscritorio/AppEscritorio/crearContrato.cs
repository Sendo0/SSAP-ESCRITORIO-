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
    public partial class crearContrato : Form
    {
        public crearContrato()
        {
            InitializeComponent();
        }
        OracleConnection conexion = new OracleConnection("DATA SOURCE = xe; PASSWORD=1234;USER ID = BDD_LOCAL");
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Form crear = new Menu();
            crear.Show();
            this.Hide();
        }

        private void btnContrato_Click(object sender, EventArgs e)
        {
            try
            {
                txtID.Text = txtID.Text.ToUpper();
                txtValor.Text = txtValor.Text.ToUpper();
                dtFecha.Text = dtFecha.Text.ToUpper();
                dtUltimoPago.Text = dtUltimoPago.Text.ToUpper();
                txtRutCli.Text = txtRutCli.Text.ToUpper();
                txtRutProf.Text = txtRutProf.Text.ToUpper();
                conexion.Open();
                OracleCommand comando = new OracleCommand("crearContrato", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("id_cont", OracleType.Int32).Value = txtID.Text;
                comando.Parameters.Add("costo", OracleType.Int32).Value = txtValor.Text;
                comando.Parameters.Add("fecha", OracleType.DateTime).Value = dtFecha.Text;
                comando.Parameters.Add("pago", OracleType.DateTime).Value = dtUltimoPago.Text;
                comando.Parameters.Add("rutCli", OracleType.VarChar).Value = txtRutCli.Text;
                comando.Parameters.Add("rutProf", OracleType.VarChar).Value = txtRutProf.Text;
                comando.ExecuteNonQuery();
                MessageBox.Show("Contrato registrado");
                
                Form crear = new Menu();
                crear.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo Fallo...");
                ;
            }
            conexion.Close();
          

        }
    }
}
