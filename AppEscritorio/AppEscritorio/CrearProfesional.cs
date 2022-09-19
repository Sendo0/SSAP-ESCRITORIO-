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
    public partial class CrearProfesional : Form
    {
        public CrearProfesional()
        {
            InitializeComponent();
        }

        private void lblPass_Click(object sender, EventArgs e)
        {

        }
        OracleConnection conexion = new OracleConnection("DATA SOURCE = xe; PASSWORD=1234;USER ID = BDD_LOCAL");
        private void btnRegistrarUser_Click(object sender, EventArgs e)
        {
            try
            {
                txtId_user.Text = txtId_user.Text.ToUpper();
                txtRut.Text = txtRut.Text.ToUpper();
                txtNombreProf.Text = txtNombreProf.Text.ToUpper();
                txtEstado.Text = txtEstado.Text.ToUpper();
                
                conexion.Open();
                OracleCommand comando = new OracleCommand("insertarProfesional", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("id_usu", OracleType.Int32).Value = txtId_user.Text;
                comando.Parameters.Add("rutProf", OracleType.VarChar).Value = txtRut.Text;
                comando.Parameters.Add("nombre", OracleType.VarChar).Value = txtNombreProf.Text;
                comando.Parameters.Add("estado", OracleType.Int32).Value = txtEstado.Text;

                comando.ExecuteNonQuery();
                MessageBox.Show("Usuario Profesional Insertado");
                this.Hide();

            }
            catch (Exception)
            {
                MessageBox.Show("Algo Fallo...");
                ;
            }
            conexion.Close();
            Form crear = new Menu();
            crear.Show();
            this.Hide();

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Form crear = new Menu();
            crear.Show();
            this.Hide();
        }
    }
}
