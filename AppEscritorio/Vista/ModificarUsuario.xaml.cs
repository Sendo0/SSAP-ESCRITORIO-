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
        private bool valPass = false, valRepPass = false, valDireccion = true,
            valNombreEmpresa = true, valRubroEmpresa = true, valCantTr = true,
            valNombreProfesional = true, valNombreAdministrador = true;
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

        private void secuenciaCerrar()
        {
            menu.txtMensaje.Text = Ctrl.mensaje;
            menu.recargarTablaUsuarios();
            menu.IsEnabled = true;
            this.Close();
        }

        private void modificarUsuario(object sender, RoutedEventArgs e)
        {
            if(valPass && valRepPass && valDireccion)
            {
                usuario.direccion = txbDireccion.Text;
                usuario.contraseña = txbPassword.Password;
                usuario.id_comuna = Int32.Parse(cbxComuna.SelectedValue.ToString());
                if (cbxTipo.SelectedIndex == 0 && valNombreEmpresa && valRubroEmpresa && valCantTr)
                {
                    cliente.nombre_empresa = txbNombreEmpresa.Text;
                    cliente.rubro_empresa = txbRubroEmpresa.Text;
                    cliente.cant_trabajadores = Int32.Parse(txbCantidadTrabajadores.Text);
                    Ctrl.modificarUsuario(usuario, cliente);
                    secuenciaCerrar();
                }
                else if (cbxTipo.SelectedIndex == 1 && valNombreProfesional)
                {
                    profesional.nombre = txbNombreProfesional.Text;
                    Ctrl.modificarUsuario(usuario, profesional);
                    secuenciaCerrar();
                }
                else if (cbxTipo.SelectedIndex == 2 && valNombreAdministrador)
                {
                    administrador.nombre = txbNombreAdministrador.Text;
                    Ctrl.modificarUsuario(usuario, administrador);
                    secuenciaCerrar();
                }
                else
                {
                    errorFormulario.Text = "Error de formulario";
                }
            }
            else
            {
                errorFormulario.Text = "Error de formulario";
            }
        }

        private void llenarCombobox()
        {
            String region_tmp = "";
            String ciudad_tmp = "";
            foreach (Ubicacion ubicacion in Ubicacion.todos())
            {
                if (!ubicacion.nombre_region.Equals(region_tmp))
                {
                    region_tmp = ubicacion.nombre_region;
                    ComboBoxItem titulo_region = new ComboBoxItem();
                    titulo_region.Content = region_tmp;
                    titulo_region.FontWeight = FontWeights.Bold;
                    titulo_region.IsEnabled = false;
                    cbxComuna.Items.Add(titulo_region);
                }
                if (!ubicacion.nombre_ciudad.Equals(ciudad_tmp))
                {
                    ubicacion.nombre_ciudad = ubicacion.nombre_ciudad;
                    ciudad_tmp = ubicacion.nombre_ciudad;
                    ComboBoxItem titulo_ciudad = new ComboBoxItem();
                    titulo_ciudad.Content = " " + ciudad_tmp;
                    titulo_ciudad.FontWeight = FontWeights.Bold;
                    titulo_ciudad.IsEnabled = false;
                    cbxComuna.Items.Add(titulo_ciudad);
                }
                ubicacion.nombre_comuna = "  " + ubicacion.nombre_comuna;
                cbxComuna.Items.Add(ubicacion);
                if(usuario.id_comuna == ubicacion.id_comuna)
                {
                    cbxComuna.SelectedItem = ubicacion;
                }
            }
        }

        //--Validaciones--
        //Usuario General
        /*private void txbRut_TextChanged(object sender, TextChangedEventArgs e)
        {
            String rut = txbRut.Text;
            if (Validar.noVacio(rut) && Validar.minLength(rut, 12) && Validar.maxLength(rut, 12) && Validar.rutValido(rut))
            {
                errorRut.Text = Validar.mensaje;
                valRut = true;
            }
            else
            {
                errorRut.Text = Validar.mensaje;
                valRut = false;
            }
        }*/

        private void txbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            String password = txbPassword.Password;
            if (Validar.noVacio(password) && Validar.minLength(password, 4) && Validar.maxLength(password, 30))
            {
                errorPassword.Text = Validar.mensaje;
                valPass = true;
            }
            else
            {
                errorPassword.Text = Validar.mensaje;
                valPass = false;
            }
        }

        private void txbRepPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            String password = txbPassword.Password;
            String repPassword = txbRepPassword.Password;
            if (Validar.noVacio(repPassword) && Validar.contraseñasIguales(password, repPassword))
            {
                errorRepPassword.Text = Validar.mensaje;
                valRepPass = true;
            }
            else
            {
                errorRepPassword.Text = Validar.mensaje;
                valRepPass = false;
            }
        }

        private void txbDireccion_TextChanged(object sender, TextChangedEventArgs e)
        {
            String direccion = txbDireccion.Text;
            if (Validar.noVacio(direccion) && Validar.maxLength(direccion, 30))
            {
                errorDireccion.Text = Validar.mensaje;
                valDireccion = true;
            }
            else
            {
                errorDireccion.Text = Validar.mensaje;
                valDireccion = false;
            }
        }

        //Cliente
        private void txbNombreEmpresa_TextChanged(object sender, TextChangedEventArgs e)
        {
            String nombre = txbNombreEmpresa.Text;
            if (Validar.noVacio(nombre) && Validar.maxLength(nombre, 30))
            {
                errorNombreCli.Text = Validar.mensaje;
                valNombreEmpresa = true;
            }
            else
            {
                errorNombreCli.Text = Validar.mensaje;
                valNombreEmpresa = false;
            }
        }

        private void txbRubroEmpresa_TextChanged(object sender, TextChangedEventArgs e)
        {
            String rubro = txbRubroEmpresa.Text;
            if (Validar.noVacio(rubro) && Validar.maxLength(rubro, 30))
            {
                errorRubro.Text = Validar.mensaje;
                valRubroEmpresa = true;
            }
            else
            {
                errorRubro.Text = Validar.mensaje;
                valRubroEmpresa = false;
            }
        }

        private void txbCantidadTrabajadores_TextChanged(object sender, TextChangedEventArgs e)
        {
            String cantidad = txbCantidadTrabajadores.Text;
            if (Validar.noVacio(cantidad) && Validar.numero(cantidad) && Validar.maxLength(cantidad, 9))
            {
                errorCantidad.Text = Validar.mensaje;
                valCantTr = true;
            }
            else
            {
                errorCantidad.Text = Validar.mensaje;
                valCantTr = false;
            }
        }

        //Profesional
        private void txbNombreProfesional_TextChanged(object sender, TextChangedEventArgs e)
        {
            String nombre = txbNombreProfesional.Text;
            if (Validar.noVacio(nombre) && Validar.maxLength(nombre, 30))
            {
                errorNombrePro.Text = Validar.mensaje;
                valNombreProfesional = true;
            }
            else
            {
                errorNombrePro.Text = Validar.mensaje;
                valNombreProfesional = false;
            }
        }

        //Administrador
        private void txbNombreAdministrador_TextChanged(object sender, TextChangedEventArgs e)
        {
            String nombre = txbNombreAdministrador.Text;
            if (Validar.noVacio(nombre) && Validar.maxLength(nombre, 30))
            {
                errorNombreAdm.Text = Validar.mensaje;
                valNombreAdministrador = true;
            }
            else
            {
                errorNombreAdm.Text = Validar.mensaje;
                valNombreAdministrador = true;
            }
        }
    }
}
