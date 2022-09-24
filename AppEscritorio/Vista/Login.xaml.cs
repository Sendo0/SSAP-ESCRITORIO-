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
        public Login()
        {
            InitializeComponent();
            ThemeManager.Current.ChangeTheme(this, "Light.Purple");
        }

        private void funcion_loguear(object sender, RoutedEventArgs e)
        {
            Ctrl ctrl = Ctrl.login(tbxRut.Text, tbxPassword.Password);
            if(ctrl != null)
            {
                MenuPrincipal menuPrincipal = new MenuPrincipal(ctrl);
                menuPrincipal.Show();
                this.Close();
            }
            else
            {
                lblError.Content = "Usuario o Contraseña Incorrectos";
            }
        }
    }
}
