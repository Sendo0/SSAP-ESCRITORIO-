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
        private bool valRut = false, valPass = false,valRepPass = false, valDireccion = false, 
            valNombreEmpresa = false, valRubroEmpresa = false, valCantTr = false, valCosto = false,
            valNombreProfesional = false, valNombreAdministrador = false;
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

        //--Front End--
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
            String region_tmp = "";
            String ciudad_tmp = "";
            cbxProfesional.ItemsSource = Profesional.todos();
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
                    titulo_ciudad.Content = " "+ciudad_tmp;
                    titulo_ciudad.FontWeight = FontWeights.Bold;
                    titulo_ciudad.IsEnabled = false;
                    cbxComuna.Items.Add(titulo_ciudad);
                }
                ubicacion.nombre_comuna = "  "+ubicacion.nombre_comuna;
                cbxComuna.Items.Add(ubicacion);
            }
        }

        //--Back End--
        private void secuenciaCerrar()
        {
            menu.txtMensaje.Text = Ctrl.mensaje;
            menu.recargarTablaUsuarios();
            menu.IsEnabled = true;
            this.Close();
        }

        private void crearUsuario(object sender, RoutedEventArgs e)
        {
            if (valRut && valPass && valRepPass && cbxComuna.SelectedItem != null && valDireccion)
            {
                Usuario nuevoUsr = new Usuario { contraseña = txbPassword.Password, tipo = cbxTipo.Text, id_comuna = Int32.Parse(cbxComuna.SelectedValue.ToString()), direccion = txbDireccion.Text };
                if (cbxTipo.SelectedIndex == 0 && valNombreEmpresa && valRubroEmpresa && valCantTr && valCosto)
                {
                    Cliente nuevoCli = new Cliente { rut = txbRut.Text, nombre_empresa = txbNombreEmpresa.Text, rubro_empresa = txbRubroEmpresa.Text, cant_trabajadores = Int32.Parse(txbCantidadTrabajadores.Text) };
                    Contrato nuevoCon = new Contrato { costo_base = Int32.Parse(txbCosto.Text), fecha_firma = dteFirma.DisplayDate, ultimo_pago = dteFirma.DisplayDate, CLIENTE_rut = nuevoCli.rut, PROFESIONAL_rut = cbxProfesional.SelectedValue.ToString() };
                    Ctrl.crearUsuario(nuevoUsr, nuevoCli, nuevoCon);
                    secuenciaCerrar();
                }
                else if (cbxTipo.SelectedIndex == 1 && valNombreProfesional)
                {
                    Profesional nuevoPro = new Profesional { rut = txbRut.Text, nombre = txbNombreProfesional.Text };
                    Ctrl.crearUsuario(nuevoUsr, nuevoPro);
                    secuenciaCerrar();
                }
                else if (cbxTipo.SelectedIndex == 2 && valNombreAdministrador)
                {
                    Administrador nuevoAdm = new Administrador { rut = txbRut.Text, nombre = txbNombreAdministrador.Text };
                    Ctrl.crearUsuario(nuevoUsr, nuevoAdm);
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


        //--Validaciones--
        //Usuario General
        private void txbRut_TextChanged(object sender, TextChangedEventArgs e)
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
        }

        private void txbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            String password = txbPassword.Password;
            if(Validar.noVacio(password) && Validar.minLength(password,4) && Validar.maxLength(password,30))
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
            if (Validar.noVacio(direccion) && Validar.maxLength(direccion,30))
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
            if(Validar.noVacio(nombre) && Validar.maxLength(nombre, 30))
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
            if(Validar.noVacio(rubro) && Validar.maxLength(rubro, 30))
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
            if(Validar.noVacio(cantidad) && Validar.numero(cantidad) && Validar.maxLength(cantidad,9))
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

        private void txbCosto_TextChanged(object sender, TextChangedEventArgs e)
        {
            String costo = txbCosto.Text;
            if(Validar.noVacio(costo) && Validar.numero(costo) && Validar.maxLength(costo, 9))
            {
                errorPrecio.Text = Validar.mensaje;
                valCosto = true;
            }
            else
            {
                errorPrecio.Text = Validar.mensaje;
                valCosto = false;
            }
        }

        //Profesional
        private void txbNombreProfesional_TextChanged(object sender, TextChangedEventArgs e)
        {
            String nombre = txbNombreProfesional.Text;
            if(Validar.noVacio(nombre) && Validar.maxLength(nombre, 30))
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
            if(Validar.noVacio(nombre) && Validar.maxLength(nombre, 30))
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
