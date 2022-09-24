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
using System.Windows.Shapes;
using ControlzEx.Theming;
using Modelo;
using Controlador;
using MahApps.Metro.Controls;
using System.Diagnostics;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para ModificarUsuario.xaml
    /// </summary>
    public partial class ModificarUsuario : MetroWindow
    {
        MenuPrincipal menu;
        Usuario usuario;
        public ModificarUsuario(MenuPrincipal menu_princ, int id_usuario)
        {
            InitializeComponent();
            menu = menu_princ;
            menu.IsEnabled = false;
            usuario = Usuario.filtro_id(id_usuario);
            Closing += accionCerrar;
            ThemeManager.Current.ChangeTheme(this, "Light.Purple");
        }

        //Front End
        private void accionCerrar(object sender, System.ComponentModel.CancelEventArgs e)
        {
            menu.IsEnabled = true;
        }

        private void accionCerrar(object sender, RoutedEventArgs e)
        {
            menu.IsEnabled = true;
            this.Close();
        }

        private void cambioTipo(object sender, SelectionChangedEventArgs e)
        {
            if (cbxTipo.SelectedIndex == 0)
            {
                formCliente.Visibility = Visibility.Visible;
                formAdministrador.Visibility = Visibility.Hidden;
                formProfesional.Visibility = Visibility.Hidden;
            }
            if (cbxTipo.SelectedIndex == 1)
            {
                formCliente.Visibility = Visibility.Hidden;
                formAdministrador.Visibility = Visibility.Hidden;
                formProfesional.Visibility = Visibility.Visible;
            }
            if (cbxTipo.SelectedIndex == 2)
            {
                formCliente.Visibility = Visibility.Hidden;
                formAdministrador.Visibility = Visibility.Visible;
                formProfesional.Visibility = Visibility.Hidden;
            }
        }

        //Back end
    }
}
