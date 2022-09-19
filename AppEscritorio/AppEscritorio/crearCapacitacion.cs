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
    public partial class crearCapacitacion : Form
    {
        public crearCapacitacion()
        {
            InitializeComponent();
        }
        OracleConnection conexion = new OracleConnection("DATA SOURCE = xe; PASSWORD=1234;USER ID = BDD_LOCAL");
        private void btnCapacitacion_Click(object sender, EventArgs e)
        {
            try
            {




                txtIDcapa.Text = txtIDcapa.Text.ToUpper();
                txtNom.Text = txtNom.Text.ToUpper();
                txtUbi.Text = txtUbi.Text.ToUpper();
                cbEstado.Text = cbEstado.Text.ToUpper();
                dtFechaVisi.Text = dtFechaVisi.Text.ToUpper();
                txtIDcontrato.Text = txtIDcontrato.Text.ToUpper();
                txtIDcomuna.Text = txtIDcomuna.Text.ToUpper();
                conexion.Open();
                OracleCommand comando = new OracleCommand("crearCapacitacion", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("id_capa", OracleType.Int32).Value = txtIDcapa.Text;
                comando.Parameters.Add("nom", OracleType.VarChar).Value = txtNom.Text;
                comando.Parameters.Add("ubi", OracleType.VarChar).Value = txtUbi.Text;
                comando.Parameters.Add("estado", OracleType.VarChar).Value = cbEstado.Text;
                comando.Parameters.Add("fecha", OracleType.DateTime).Value = dtFechaVisi.Text;
                comando.Parameters.Add("id_cont", OracleType.Int32).Value = txtIDcontrato.Text;
                comando.Parameters.Add("id_com", OracleType.Int32).Value = txtIDcomuna.Text;
                comando.ExecuteNonQuery();
                MessageBox.Show("Capacitacion creada");
                

               

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

        private void btnMail_Click(object sender, EventArgs e)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(txtMail.Text);
            msg.Subject = txtNom.Text;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = txtUbi.Text;
            //msg.Subject = "SSAP: Capacitacion Agendada USER: " + txtRutCLi.Text + ".";


            //msg.Body = "Capacitacion creada con fecha: " + dtFecha.Text + ".\nUsuario: " + txtRutCLi.Text + ".\nFecha de visita Capacitacion: " + dtFechaVisi.Text + ".";
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;

            msg.From = new System.Net.Mail.MailAddress("jav.jimenezs@duocuc.cl");

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();


            cliente.Credentials = new System.Net.NetworkCredential("jav.jimenezs@duocuc.cl","tequieromama1.");
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";
            try
            {
                cliente.Send(msg);
                MessageBox.Show("Se envio");
                


                //txtMail.Text = txtMail.Text.ToLower();
                //dtFecha.Text = dtFecha.Text.ToUpper();
                //OracleCommand comando1 = new OracleCommand("crearNotificacion", conexion);
                //comando1.CommandType = System.Data.CommandType.StoredProcedure;
                //comando1.Parameters.Add("id_noti", OracleType.Int32).Value = txtIDcapa.Text;
                //comando1.Parameters.Add("titulo", OracleType.VarChar).Value = "SSAP: Capacitacion Agendada USER: " + txtRutCLi.Text + ".";
                //comando1.Parameters.Add("descrip", OracleType.Clob).Value = "Capacitacion creada con fecha: " + dtFecha.Text + ".\nUsuario: " + txtRutCLi.Text + ".\nFecha de visita Capacitacion: " + dtFechaVisi.Text + "."; ;
                //comando1.Parameters.Add("fecha", OracleType.DateTime).Value = dtFecha.Text;
                //comando1.Parameters.Add("rutCli", OracleType.VarChar).Value = txtRutCLi.Text;
                //comando1.Parameters.Add("mail", OracleType.VarChar).Value = txtMail.Text;

                //comando1.ExecuteNonQuery();
                

                //MessageBox.Show("Notificacion Enviada");


            }
            catch (Exception)
            {

                MessageBox.Show("Error al enviar correo");
            }
        }
    }
}
