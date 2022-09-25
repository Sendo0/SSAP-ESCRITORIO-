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
        Administrador administrador;
        Profesional profesional;
        Cliente cliente;
        public ModificarUsuario(MenuPrincipal menu_princ, int id_usuario)
        {
            InitializeComponent();
            menu = menu_princ;
            menu.IsEnabled = false;
            usuario = Usuario.filtro_id(id_usuario);

            //Carga de datos
            txbDireccion.Text = usuario.direccion;
            if (usuario.tipo == "ADMINISTRADOR")
            {
                administrador = Administrador.filtro_id(id_usuario);
                txbRut.Text = administrador.rut;
                txbNombreAdministrador.Text = administrador.nombre;
                cbxTipo.SelectedIndex = 2;
            }
            if (usuario.tipo == "PROFESIONAL")
            {
                profesional = Profesional.filtro_id(id_usuario);
                txbRut.Text = profesional.rut;
                txbNombreProfesional.Text = profesional.nombre;
                cbxTipo.SelectedIndex = 1;
            }
            if (usuario.tipo == "CLIENTE")
            {
                cliente = Cliente.filtro_id(id_usuario);
                txbRut.Text = cliente.rut;
                txbNombreEmpresa.Text = cliente.nombre_empresa;
                txbRubroEmpresa.Text = cliente.rubro_empresa;
                txbCantidadTrabajadores.Text = cliente.cant_trabajadores.ToString();
                cbxTipo.SelectedIndex = 0;
            }

            //Estilos y Boton cerrar
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

        private void modificarUsuario(object sender, RoutedEventArgs e)
        {
            usuario.direccion = txbDireccion.Text;
            usuario.contraseña = txbPassword.Password;
            usuario.id_comuna = 1;
            if (cbxTipo.SelectedIndex == 0)
            {
                cliente.nombre_empresa = txbNombreEmpresa.Text;
                cliente.rubro_empresa = txbRubroEmpresa.Text;
                cliente.cant_trabajadores = Int32.Parse(txbCantidadTrabajadores.Text);
                Ctrl.modificarUsuario(usuario, cliente);
            }
            else if (cbxTipo.SelectedIndex == 1)
            {
                profesional.nombre = txbNombreProfesional.Text;
                Ctrl.modificarUsuario(usuario, profesional);
            }
            else if (cbxTipo.SelectedIndex == 2)
            {
                administrador.nombre = txbNombreAdministrador.Text;
                Ctrl.modificarUsuario(usuario, administrador);
            }
            menu.txtMensaje.Text = Ctrl.mensaje;
            menu.recargarTablaUsuarios();
            menu.IsEnabled = true;
            this.Close();
        }
    }
}
