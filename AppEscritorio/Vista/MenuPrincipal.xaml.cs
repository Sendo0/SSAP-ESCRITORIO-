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
using LiveCharts;
using LiveCharts.Wpf;

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
                System.Windows.Controls.Separator separador = new System.Windows.Controls.Separator();

                //Creamos Contenedores
                Label rut = new Label();
                Label nombre = new Label();
                Label tipo = new Label();
                StackPanel acciones = new StackPanel();

                //Botones de acciones
                Button deshabilitar = new Button();
                Button modificar = new Button();
                Button habilitar = new Button();
                Button pagos = new Button();

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

                pagos.Tag = usuario.id_usuario;
                pagos.Content = "Control Pagos";
                pagos.Background = new SolidColorBrush(Color.FromRgb(251, 195, 4));
                pagos.Click += controlPagos;

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
                    if(usuario.tipo == "CLIENTE")
                    {
                        acciones.Children.Add(pagos);
                    }
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

        private void controlPagos(object sender, RoutedEventArgs e)
        {
            Button boton = (Button)sender;
            int id = Int32.Parse(boton.Tag.ToString());
            ControladorPago controlPagos = new ControladorPago(this, id);
            controlPagos.Show();
        }


        //---------------------- Crear Reportes ----------------------

        private void cargarReportes(object sender, RoutedEventArgs e)
        {
            int cantidad_cli = 0;
            int cantidad_pro = 0;
            int cantidad_admin = 0;
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0}", chartPoint.Y, chartPoint.Participation);
            SeriesCollection series = new SeriesCollection();
            foreach (var obj in Usuario.todos())
            {
                if (obj.tipo == "CLIENTE")
                {
                    cantidad_cli++;
                }
                if (obj.tipo == "PROFESIONAL")
                {
                    cantidad_pro++;
                }
                if (obj.tipo == "ADMINISTRADOR")
                {
                    cantidad_admin++;
                }
            }
            series.Add(new PieSeries() { Title = "Cliente", Values = new ChartValues<int> { cantidad_cli }, DataLabels = true, LabelPoint = labelPoint });
            series.Add(new PieSeries() { Title = "Profesionales", Values = new ChartValues<int> { cantidad_pro }, DataLabels = true, LabelPoint = labelPoint });
            series.Add(new PieSeries() { Title = "Administradores", Values = new ChartValues<int> { cantidad_admin }, DataLabels = true, LabelPoint = labelPoint });
            pichart1.Series = series;
            TablaReportes();
        }
        public void TablaReportes()
        {
            ReporteTotal.Children.Clear();
            foreach (Pagos_Mensual pago_mensual in Pagos_Mensual.Todos())
            {
                //Crear un objeto donde se stackearán los datos
                StackPanel fila = new StackPanel();
                fila.Orientation = Orientation.Horizontal;
                fila.HorizontalAlignment = HorizontalAlignment.Center;
                Thickness margen = fila.Margin;
                margen.Top = 5;
                fila.Margin = margen;
                System.Windows.Controls.Separator separador = new System.Windows.Controls.Separator();

                //Creamos Contenedores
                Label Año = new Label();
                Label Mes = new Label();
                Label Total= new Label();


                //Estilos de Label
                Año.Width = 220;
                Mes.Width = 220;
                Total.Width = 220;


                Año.FontSize = 16;
                Mes.FontSize = 16;
                Total.FontSize = 16;

                Año.HorizontalContentAlignment = HorizontalAlignment.Center;
                Mes.HorizontalContentAlignment = HorizontalAlignment.Center;
                Total.HorizontalContentAlignment = HorizontalAlignment.Center;

                Año.VerticalContentAlignment = VerticalAlignment.Center;
                Mes.VerticalContentAlignment = VerticalAlignment.Center;
                Total.VerticalContentAlignment = VerticalAlignment.Center;

                //Insercion de Variables
                Año.Content = pago_mensual.año;
                Mes.Content = pago_mensual.mes;
                Total.Content = "$"+pago_mensual.costo;
           

                fila.Children.Add(Año);
                fila.Children.Add(Mes);
                fila.Children.Add(Total);
                ReporteTotal.Children.Add(fila);
                ReporteTotal.Children.Add(separador);
            }
        }

        //----------------------Ver Actividades----------------------
        private void buscarActividad(object sender, RoutedEventArgs e)
        {
            act_tblActividades.Children.Clear();
            foreach (Actividad actividad in Actividad.obtener(rutProfesional.Text))
            {
                //Crear un objeto donde se stackearán los datos
                StackPanel fila = new StackPanel();
                fila.Orientation = Orientation.Horizontal;
                fila.HorizontalAlignment = HorizontalAlignment.Center;
                Thickness margen = fila.Margin;
                margen.Top = 5;
                fila.Margin = margen;
                System.Windows.Controls.Separator separador = new System.Windows.Controls.Separator();

                //Creamos Contenedores
                Label profesional = new Label();
                Label tipo = new Label();
                Label fecha = new Label();
                Label ubicacion= new Label();

                //Estilos de Label
                profesional.Width = 150;
                tipo.Width = 150;
                fecha.Width = 150;
                ubicacion.Width = 150;

                profesional.FontSize = 16;
                tipo.FontSize = 16;
                fecha.FontSize = 16;
                ubicacion.FontSize = 16;

                profesional.HorizontalContentAlignment = HorizontalAlignment.Center;
                tipo.HorizontalContentAlignment = HorizontalAlignment.Center;
                fecha.HorizontalContentAlignment = HorizontalAlignment.Center;
                ubicacion.HorizontalContentAlignment = HorizontalAlignment.Center;

                profesional.VerticalContentAlignment = VerticalAlignment.Center;
                tipo.VerticalContentAlignment = VerticalAlignment.Center;
                fecha.VerticalContentAlignment = VerticalAlignment.Center;
                ubicacion.VerticalContentAlignment = VerticalAlignment.Center;

                //Insercion de Variables
                profesional.Content = actividad.nombre_profesional;
                tipo.Content = actividad.tipo;
                fecha.Content = actividad.fecha.ToString("dd/MM/yyyy");
                ubicacion.Content = actividad.ubicacion;

                fila.Children.Add(profesional);
                fila.Children.Add(tipo);
                fila.Children.Add(fecha);
                fila.Children.Add(ubicacion);
                act_tblActividades.Children.Add(fila);
                act_tblActividades.Children.Add(separador);
            }
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

        //----Validar--------

        private void rutProfesional_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Validar.noVacio(rutProfesional.Text) && Validar.rutValido(rutProfesional.Text))
            {
                errorRutPro.Text = Validar.mensaje;
                btnBuscarProf.IsEnabled = true;
            }
            else
            {
                errorRutPro.Text = Validar.mensaje;
                btnBuscarProf.IsEnabled = false;
            }
        }
    }
}
