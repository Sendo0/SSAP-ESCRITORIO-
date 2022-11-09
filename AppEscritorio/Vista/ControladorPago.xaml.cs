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
using System.Windows.Navigation;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para ControladorPago.xaml
    /// </summary>
    public partial class ControladorPago : MetroWindow
    {
        MenuPrincipal menu;
        Cliente cliente;
        Contrato contrato;
        public ControladorPago(MenuPrincipal menu_princ, int id_usuario)
        {
            //Inicializar Variables
            InitializeComponent();
            menu = menu_princ;
            menu.IsEnabled = false;
            cliente = Cliente.filtro_id(id_usuario);
            contrato = Contrato.filtro_rutcliente(cliente.rut);

            //Rellenar datos de cliente
            lblRut.Content = "RUT: " + cliente.rut;
            lblCliente.Content = "CLIENTE: " + cliente.nombre_empresa;
            lblEstado.Content = "ESTADO: AL DÍA";
            foreach(Mensualidad mensualidad in Mensualidad.todos_idcontrato(contrato.id_contrato))
            {
                if (!mensualidad.estado)
                {
                    lblEstado.Content = "ESTADO: PENDIENTE";
                    if (DateTime.Today > mensualidad.fecha_limite)
                    {
                        lblEstado.Content = "ESTADO: ATRASADO";
                        break;
                    }
                }
            }
            
            //Datos de tabla
            foreach(Mensualidad mensualidad in Mensualidad.todos_idcontrato(contrato.id_contrato)){
                //Crear un objeto donde se stackearán los datos
                StackPanel stcPago = new StackPanel();
                stcPago.Orientation = Orientation.Horizontal;
                stcPago.HorizontalAlignment = HorizontalAlignment.Center;
                Thickness margen = stcPago.Margin;
                margen.Top = 5;
                stcPago.Margin = margen;
                Separator separador = new Separator();

                //Creamos Contenedores
                Label fecha_limite = new Label();
                Label fecha_pago = new Label();
                Label monto = new Label();
                Label estado = new Label();
                Label boleta = new Label();
                
                //URL para Boleta
                Run url = new Run("Link");
                Hyperlink link = new Hyperlink(url);
                link.NavigateUri = new Uri("http://localhost:8000/boleta_adm/"+mensualidad.boleta);
                link.RequestNavigate += new RequestNavigateEventHandler(delegate (object sender, RequestNavigateEventArgs e) {
                    Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
                    e.Handled = true;
                });

                //Botones de acciones
                Button reportar = new Button();
                reportar.Tag = mensualidad.fecha_limite;
                reportar.Content = "Reportar Atraso";
                reportar.Background = new SolidColorBrush(Color.FromRgb(223, 32, 32));
                reportar.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                reportar.IsEnabled = false;
                reportar.Click += reportarAtraso;

                //Estilos de label
                fecha_limite.Width = 150;
                fecha_pago.Width = 150;
                monto.Width = 150;
                estado.Width = 150;
                boleta.Width = 150;

                fecha_limite.FontSize = 16;
                fecha_pago.FontSize = 16;
                monto.FontSize = 16;
                estado.FontSize = 16;
                boleta.FontSize = 16;

                fecha_limite.HorizontalContentAlignment = HorizontalAlignment.Center;
                fecha_pago.HorizontalContentAlignment = HorizontalAlignment.Center;
                monto.HorizontalContentAlignment = HorizontalAlignment.Center;
                estado.HorizontalContentAlignment = HorizontalAlignment.Center;
                boleta.HorizontalContentAlignment = HorizontalAlignment.Center;

                fecha_limite.VerticalContentAlignment = VerticalAlignment.Center;
                fecha_pago.VerticalContentAlignment = VerticalAlignment.Center;
                monto.VerticalContentAlignment = VerticalAlignment.Center;
                estado.VerticalContentAlignment = VerticalAlignment.Center;
                boleta.VerticalContentAlignment = VerticalAlignment.Center;

                //Insercion de variables
                fecha_limite.Content = mensualidad.fecha_limite.ToString("dd/MM/yyyy");
                if(mensualidad.fecha_pago == "")
                {
                    fecha_pago.Content = "N/A";
                }
                else
                {
                    fecha_pago.Content = Convert.ToDateTime(mensualidad.fecha_pago).ToString("dd/MM/yyyy");
                }
                monto.Content = "$"+mensualidad.costo;
                estado.Content = "Pagado";
                if (!mensualidad.estado)
                {
                    estado.Content = "Pendiente";
                    if (DateTime.Today > mensualidad.fecha_limite)
                    {
                        estado.Content = "Atrasado";
                        reportar.IsEnabled = true;
                    }
                }
                if(mensualidad.boleta == "")
                {
                    boleta.Content = "N/A";
                }
                else
                {
                    link.Foreground = new SolidColorBrush(Color.FromRgb(44, 69, 191));
                    boleta.Content = link;
                }
                //Stackear
                stcPago.Children.Add(fecha_limite);
                stcPago.Children.Add(fecha_pago);
                stcPago.Children.Add(monto);
                stcPago.Children.Add(estado);
                stcPago.Children.Add(boleta);
                stcPago.Children.Add(reportar);
                tblPagos.Children.Add(stcPago);
                tblPagos.Children.Add(separador);
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

        private void accionCerrar(object sender, MouseButtonEventArgs e)
        {
            menu.IsEnabled = true;
            this.Close();
        }

        //Back End

        private void reportarAtraso(object sender, RoutedEventArgs e)
        {
            Button boton = (Button)sender;
            boton.IsEnabled = false;
            Mouse.OverrideCursor = Cursors.Wait;
            String fecha = Convert.ToDateTime(boton.Tag.ToString()).ToString("dd/MM/yyyy");
            Notificacion notificacion = new Notificacion
            {
                titulo = "Atraso en Pagos",
                descripcion = "Se le notifica que existe un pago atrasado del día " + fecha + " y que puede que pronto se deshabilite su cuenta si no se realiza el pago correspondiente.",
                fecha = DateTime.Now,
                CLIENTE_rut = cliente.rut
            };
            Ctrl.reportarAtraso(notificacion);
            Mouse.OverrideCursor = Cursors.Arrow;
            boton.IsEnabled = true;
            MessageBox.Show(Ctrl.mensaje);
        }
    }
}
