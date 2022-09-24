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
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class CrearUsuario : MetroWindow
    {
        MenuPrincipal menu;
        public CrearUsuario(MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            menu = menuPrincipal;
            menu.IsEnabled = false;
            Closing += accionCerrar;
            llenarCombobox();
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
            if(cbxTipo.SelectedIndex == 0)
            {
                formCliente.Visibility = Visibility.Visible;
                formAdministrador.Visibility = Visibility.Hidden;
                formProfesional.Visibility = Visibility.Hidden;
            }
            if(cbxTipo.SelectedIndex == 1)
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

        private void llenarCombobox()
        {
            foreach (Profesional profesional in Profesional.todos())
            {
                cbxProfesional.Items.Add(profesional);
            }
        }

        //Back End

        private void crearUsuario(object sender, RoutedEventArgs e)
        {
            Usuario nuevoUsr = new Usuario {contraseña = txbPassword.Password, tipo = cbxTipo.Text, id_comuna=1 ,direccion = txbDireccion.Text};
            if (cbxTipo.SelectedIndex == 0)
            {
                Cliente nuevoCli = new Cliente {rut = txbRut.Text, nombre_empresa = txbNombreEmpresa.Text, rubro_empresa = txbRubroEmpresa.Text, cant_trabajadores = Int32.Parse(txbCantidadTrabajadores.Text)};
                Contrato nuevoCon = new Contrato { costo_base = Int32.Parse(txbCosto.Text), fecha_firma = dteFirma.DisplayDate, ultimo_pago = dteFirma.DisplayDate, CLIENTE_rut = nuevoCli.rut, PROFESIONAL_rut = cbxProfesional.SelectedValue.ToString()};
                Ctrl.crearUsuario(nuevoUsr, nuevoCli, nuevoCon);
            }
            else if(cbxTipo.SelectedIndex == 1)
            {
                Profesional nuevoPro = new Profesional { rut = txbRut.Text, nombre = txbNombreProfesional.Text};
                Ctrl.crearUsuario(nuevoUsr, nuevoPro);
            }
            else if(cbxTipo.SelectedIndex == 2)
            {
                Administrador nuevoAdm = new Administrador { rut = txbRut.Text, nombre = txbNombreAdministrador.Text};
                Ctrl.crearUsuario(nuevoUsr, nuevoAdm);
            }
            menu.txtMensaje.Text = Ctrl.mensaje;
            menu.IsEnabled = true;
            this.Close();
        }
    }
}
