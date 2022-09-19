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
    public partial class ActualizarUsuario : Form
    {
        public ActualizarUsuario()
        {
            InitializeComponent();
        }

        private void lblID_US_Click(object sender, EventArgs e)
        {

        }
        OracleConnection conexion = new OracleConnection("DATA SOURCE = xe; PASSWORD=1234;USER ID = BDD_LOCAL");
        private void btnRegistrarUser_Click(object sender, EventArgs e)
        {
            conexion.Open();
            OracleCommand comando = new OracleCommand("actualizarUsuario", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("idp", OracleType.Int32).Value = txtId_user.Text;
            comando.Parameters.Add("contraseña", OracleType.VarChar).Value = txtPass.Text;
            comando.Parameters.Add("tipo", OracleType.VarChar).Value = CbTipo_user.Text;
            comando.Parameters.Add("IdComuna", OracleType.Int32).Value = txtIdComu.Text;
            comando.Parameters.Add("direccion", OracleType.VarChar).Value = txtDireccion.Text;
            comando.ExecuteNonQuery();
            MessageBox.Show("Persona Actualizada");
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
