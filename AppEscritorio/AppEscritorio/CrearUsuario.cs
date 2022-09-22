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
        private bool AlgoritmoContraseñaSegura(string password)
        {
            mayuscula.Checked = false; minuscula.Checked = false;  numero.Checked = false; especial.Checked = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (password.Length >= 8)
                {
                    minimo.Checked = true;
                }
                if (Char.IsUpper(password, i))
                {
                    mayuscula.Checked = true;
                }
                else if (Char.IsLower(password, i))
                {
                    minuscula.Checked = true;
                }
                else if (Char.IsDigit(password, i))
                {
                    numero.Checked = true;
                }
                else
                {
                    especial.Checked = true;
                }
            }
            if (mayuscula.Checked && minuscula.Checked && numero.Checked && especial.Checked && password.Length >= 8)
            {
                return true;
            }
            return false;
        }
        

        OracleConnection conexion = new OracleConnection("DATA SOURCE = xe; PASSWORD=123456;USER ID = SSAP");
        private void btnRegistrarUser_Click(object sender, EventArgs e)
        {
           

                try
                {
                
                    txtPass.Text = txtPass.Text.ToUpper();
                    CbTipo_user.Text = CbTipo_user.Text.ToUpper();
                    cbComunas.Text = cbComunas.Text.ToUpper();
                    txtDireccion.Text = txtDireccion.Text.ToUpper();
                    conexion.Open();
                    OracleCommand comando = new OracleCommand("insertarUsuario", conexion);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                
                    comando.Parameters.Add("pass", OracleType.VarChar).Value = txtPass.Text;
                    comando.Parameters.Add("tipo", OracleType.VarChar).Value = CbTipo_user.Text;
                    comando.Parameters.Add("id_comu", OracleType.Int32).Value = cbComunas.SelectedIndex;
                    comando.Parameters.Add("direc", OracleType.VarChar).Value = txtDireccion.Text;
                    comando.ExecuteNonQuery();



                   
                    MessageBox.Show("Usuario");
                    this.Hide();
                
                }
                catch (Exception)
                {
                    MessageBox.Show("Algo Fallo...");
                    ;
                }
                conexion.Close();


        }


        
        private void CrearUsuario_Load(object sender, EventArgs e)
        {
            OracleCommand comando = new OracleCommand("SELECT ID_COMUNA FROM COMUNA", conexion);
            conexion.Open();
            OracleDataReader registro = comando.ExecuteReader();
            while (registro.Read())
            {
                cbComunas.Items.Add(registro["ID_COMUNA"].ToString()); 

            }
            registro.Close();
            


            OracleCommand comando1 = new OracleCommand("SELECT RUT_PROFESIONAL FROM PROFESIONALES", conexion);
            conexion.Open();
            OracleDataReader registro1 = comando.ExecuteReader();
            while (registro.Read())
            {

            }
            registro1.Close();


            OracleCommand comando2 = new OracleCommand("SELECT RUT_CLIENTE FROM CLIENTES", conexion);
            conexion.Open();
            OracleDataReader registro2 = comando.ExecuteReader();
            while (registro.Read())
            {

            }
            registro2.Close();

            conexion.Close();


        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if (AlgoritmoContraseñaSegura(txtPass.Text))
                btnRegistrarUser.Enabled = true;
            else btnRegistrarUser.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Form crear = new Menu();
            crear.Show();
            this.Hide();
        }
    }
}

