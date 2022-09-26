using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using ControlzEx.Theming;
using System.Diagnostics;
using Controlador;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {

        private bool valRut { get; set; }
        private bool valPass { get; set; }
        public Login()
        {
            InitializeComponent();
            valRut = false;
            valPass = false;
            ThemeManager.Current.ChangeTheme(this, "Light.Purple");
        }

        //Trigger login

        private void funcion_loguear(object sender, RoutedEventArgs e)
        {
            Ctrl ctrl = Ctrl.login(tbxRut.Text, tbxPassword.Password);
            if (!valPass || !valRut)
            {
                lblError.Text = "Error de formulario";
            }
            else if (ctrl != null)
            {
                MenuPrincipal menuPrincipal = new MenuPrincipal(ctrl);
                menuPrincipal.Show();
                this.Close();
            }
            else
            {
                lblError.Text = "Error: Usuario o contraseña incorrecto";
            }
        }


        //Validaciones

        private void textoCambiado(object sender, TextChangedEventArgs e)
        {
            String rut = tbxRut.Text;
            if (Validar.noVacio(rut) && Validar.minLength(rut, 12) && Validar.maxLength(rut,12) && Validar.rutValido(rut))
            {
                errorRut.Content = Validar.mensaje;
                valRut = true;
            }
            else
            {
                errorRut.Content = Validar.mensaje;
                valRut = false;
            }
        }

        private void contraseñaCambiada(object sender, RoutedEventArgs e)
        {
            String pass = tbxPassword.Password;
            if (Validar.noVacio(pass) && Validar.minLength(pass, 4) && Validar.maxLength(pass, 30))
            {
                errorPassword.Content = Validar.mensaje;
                valPass = true;
            }
            else
            {
                errorPassword.Content = Validar.mensaje;
                valPass = false;
            }
        }
    }
}
