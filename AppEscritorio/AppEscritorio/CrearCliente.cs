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





                txtCosto.Text = txtCosto.Text.ToUpper();
                dtFirma.Text = dtFirma.Text.ToUpper();
                cbClientes.Text = cbClientes.Text.ToUpper();
                cbProfesionales.Text = cbProfesionales.Text.ToUpper();
                conexion.Open();
                OracleCommand comando1 = new OracleCommand("insertarUsuario", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.Add("costo", OracleType.Int32).Value = txtCosto.Text;
                comando.Parameters.Add("fecha", OracleType.VarChar).Value = dtFirma.Text;
                comando.Parameters.Add("rutCli", OracleType.VarChar).Value = cbClientes.Text;
                comando.Parameters.Add("rutPro", OracleType.VarChar).Value = cbProfesionales.Text;
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

        private void CrearCliente_Load(object sender, EventArgs e)
        {
            OracleCommand comando  = new OracleCommand("SELECT ID_USUARIO FROM USUARIO WHERE TIPO = 'CLIENTE'", conexion);
            conexion.Open();
            OracleDataReader registro = comando.ExecuteReader();
            while (registro.Read())
            {
                cbIdcliente.Items.Add(registro["ID_USUARIO"].ToString());

            }
            registro.Close();


            OracleCommand comando1 = new OracleCommand("SELECT RUT_PROFESIONAL FROM PROFESIONALES", conexion);
            conexion.Open();
            OracleDataReader registro1 = comando1.ExecuteReader();
            while (registro1.Read())
            {
                cbProfesionales.Items.Add(registro1["RUT_PROFESIONAL"].ToString());

            }
            registro1.Close();


            OracleCommand comando2 = new OracleCommand("SELECT RUT_CLIENTE FROM CLIENTES", conexion);
            conexion.Open();
            OracleDataReader registro2 = comando1.ExecuteReader();
            while (registro2.Read())
            {
                cbClientes.Items.Add(registro2["RUT_CLIENTE"].ToString());

            }
            registro2.Close();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Form crear = new Menu();
            crear.Show();
            this.Hide();
        }
    }
}
