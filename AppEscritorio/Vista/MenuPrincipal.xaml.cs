using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Controlador;
using Modelo;
using ControlzEx.Theming;
using MahApps.Metro.Controls;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class MenuPrincipal : MetroWindow
    {
        //-----Inicializar-------------
        public Ctrl ctr = new Ctrl();
        public MenuPrincipal(Ctrl ctrl)
        {
            InitializeComponent();
            ThemeManager.Current.ChangeTheme(this, "Light.Purple");
            //Estilos barra menu principal
            menuBienvenida.MouseEnter += MenuBienvenida_MouseEnter;
            menuBienvenida.MouseLeave += MenuBienvenida_MouseLeave;

            menuUsuarios.MouseEnter += MenuUsuarios_MouseEnter;
            menuUsuarios.MouseLeave += MenuUsuarios_MouseLeave;

            menuReporte.MouseEnter += MenuReporte_MouseEnter;
            menuReporte.MouseLeave += MenuReporte_MouseLeave;

            menuActividad.MouseEnter += MenuActividad_MouseEnter;
            menuActividad.MouseLeave += MenuActividad_MouseLeave;

            //Inicializar Página
            ctr = ctrl;
            txtBienvenido.Text = "\n"+ctr.admin.nombre + "\nBienvenido a SSAP";
            recargarTablaUsuarios();
        }

        //----------------------Logout----------------------
        private void logout(object sender, RoutedEventArgs e)
        {
            ctr = null;
            Login login = new Login();
            login.Show();
            this.Close();
        }

        //----------------------Gestion de Usuarios----------------------

        private void nuevoUsuario(object sender, RoutedEventArgs e)
        {
            CrearUsuario crearUsuario = new CrearUsuario(this);
            crearUsuario.Show();
        }

        private void actualizarTabla(object sender, RoutedEventArgs e)
        {
            recargarTablaUsuarios();
        }

        public void recargarTablaUsuarios()
        {
            gu_tblUsuarios.Children.Clear();
            foreach (Usuario usuario in Usuario.todos())
            {
                //Crear un objeto donde se stackearán los datos
                StackPanel vistaUsuario = new StackPanel();
                vistaUsuario.Orientation = Orientation.Horizontal;
                vistaUsuario.HorizontalAlignment = HorizontalAlignment.Center;
                Thickness margen = vistaUsuario.Margin;
                margen.Top = 5;
                vistaUsuario.Margin = margen;
                Separator separador = new Separator();

                //Creamos Contenedores
                Label rut = new Label();
                Label nombre = new Label();
                Label tipo = new Label();
                StackPanel acciones = new StackPanel();

                //Botones de acciones
                Button deshabilitar = new Button();
                Button modificar = new Button();
                Button habilitar = new Button();

                deshabilitar.Tag = usuario.id_usuario;
                deshabilitar.Content = "Deshabilitar";
                deshabilitar.Background = new SolidColorBrush(Color.FromRgb(223, 32, 32));
                deshabilitar.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                deshabilitar.Click += estadoUsuario;

                modificar.Tag = usuario.id_usuario;
                modificar.Content = "Modificar";
                modificar.Background = new SolidColorBrush(Color.FromRgb(128, 121, 229));
                modificar.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                modificar.Click += modificarUsuario;

                habilitar.Tag = usuario.id_usuario;
                habilitar.Content = "Habilitar";
                habilitar.Background = new SolidColorBrush(Color.FromRgb(51, 204, 51));
                habilitar.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                habilitar.Click += estadoUsuario;

                //Estilos de Label
                rut.Width = 150;
                nombre.Width = 150;
                tipo.Width = 150;
                acciones.Width = 150;

                rut.FontSize = 16;
                nombre.FontSize = 16;
                tipo.FontSize = 16;

                rut.HorizontalContentAlignment = HorizontalAlignment.Center;
                nombre.HorizontalContentAlignment = HorizontalAlignment.Center;
                tipo.HorizontalContentAlignment = HorizontalAlignment.Center;

                rut.VerticalContentAlignment = VerticalAlignment.Center;
                nombre.VerticalContentAlignment = VerticalAlignment.Center;
                tipo.VerticalContentAlignment = VerticalAlignment.Center;

                //Insercion de variables
                tipo.Content = usuario.tipo;
                if (usuario.tipo == "ADMINISTRADOR")
                {
                    Administrador adm = Administrador.filtro_id(usuario.id_usuario);
                    rut.Content = adm.rut;
                    nombre.Content = adm.nombre;
                    if(adm.id_usuario == ctr.admin.id_usuario)
                    {
                        deshabilitar.IsEnabled = false;
                    }
                }
                if (usuario.tipo == "PROFESIONAL")
                {
                    Profesional pro = Profesional.filtro_id(usuario.id_usuario);
                    rut.Content = pro.rut;
                    nombre.Content = pro.nombre;
                }
                if (usuario.tipo == "CLIENTE")
                {
                    Cliente cli = Cliente.filtro_id(usuario.id_usuario);
                    rut.Content = cli.rut;
                    nombre.Content = cli.nombre_empresa;
                }

                //Juntamos los stack
                //Botones
                if (usuario.estado)
                {
                    acciones.Children.Add(deshabilitar);
                    acciones.Children.Add(modificar);
                }
                else
                {
                    acciones.Children.Add(habilitar);
                }

                //Filas
                vistaUsuario.Children.Add(rut);
                vistaUsuario.Children.Add(nombre);
                vistaUsuario.Children.Add(tipo);
                vistaUsuario.Children.Add(acciones);
                gu_tblUsuarios.Children.Add(vistaUsuario);
                gu_tblUsuarios.Children.Add(separador);
            }
        }

        private void modificarUsuario(object sender, RoutedEventArgs e)
        {
            Button boton = (Button)sender;
            int id = Int32.Parse(boton.Tag.ToString());
            ModificarUsuario modificar = new ModificarUsuario(this, id);
            modificar.Show();
        }

        private void estadoUsuario(object sender, RoutedEventArgs e)
        {
            Button boton = (Button)sender;
            Ctrl.estadoUsuario(Int32.Parse(boton.Tag.ToString()));
            recargarTablaUsuarios();
            txtMensaje.Text = Ctrl.mensaje;
        }


        //----Estilos Barra Lateral (mouseover)--------
        private void MenuBienvenida_MouseLeave(object sender, MouseEventArgs e)
        {
            menuBienvenida.Background = new SolidColorBrush(Color.FromRgb(128, 121, 229));
        }
        private void MenuBienvenida_MouseEnter(object sender, MouseEventArgs e)
        {
            menuBienvenida.Background = new SolidColorBrush(Color.FromRgb(156, 149, 255));
        }

        private void MenuActividad_MouseLeave(object sender, MouseEventArgs e)
        {
            menuActividad.Background = new SolidColorBrush(Color.FromRgb(128, 121, 229));
        }
        private void MenuActividad_MouseEnter(object sender, MouseEventArgs e)
        {
            menuActividad.Background = new SolidColorBrush(Color.FromRgb(156, 149, 255));
        }

        private void MenuUsuarios_MouseLeave(object sender, MouseEventArgs e)
        {
            menuUsuarios.Background = new SolidColorBrush(Color.FromRgb(128, 121, 229));
        }
        private void MenuUsuarios_MouseEnter(object sender, MouseEventArgs e)
        {
            menuUsuarios.Background = new SolidColorBrush(Color.FromRgb(156, 149, 255));
        }

        private void MenuReporte_MouseLeave(object sender, MouseEventArgs e)
        {
            menuReporte.Background = new SolidColorBrush(Color.FromRgb(128, 121, 229));
        }
        private void MenuReporte_MouseEnter(object sender, MouseEventArgs e)
        {
            menuReporte.Background = new SolidColorBrush(Color.FromRgb(156, 149, 255));
        }
    }
}
