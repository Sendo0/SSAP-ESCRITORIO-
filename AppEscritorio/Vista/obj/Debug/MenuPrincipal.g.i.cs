﻿#pragma checksum "..\..\MenuPrincipal.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F8378E4958B5D4B4BF7D9FB0E563A2A222FE6D316C9B837322D82799D9F37800"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Vista;


namespace Vista {
    
    
    /// <summary>
    /// MenuPrincipal
    /// </summary>
    public partial class MenuPrincipal : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\MenuPrincipal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem menuBienvenida;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MenuPrincipal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtBienvenido;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\MenuPrincipal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem menuUsuarios;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\MenuPrincipal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button gu_btnActualizar;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\MenuPrincipal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button gu_btnCrearUsuario;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\MenuPrincipal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel gu_tblUsuarios;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\MenuPrincipal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtMensaje;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\MenuPrincipal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem menuReporte;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\MenuPrincipal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem menuActividad;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\MenuPrincipal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogout;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Vista;component/menuprincipal.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MenuPrincipal.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.menuBienvenida = ((System.Windows.Controls.TabItem)(target));
            return;
            case 2:
            this.txtBienvenido = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.menuUsuarios = ((System.Windows.Controls.TabItem)(target));
            return;
            case 4:
            this.gu_btnActualizar = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\MenuPrincipal.xaml"
            this.gu_btnActualizar.Click += new System.Windows.RoutedEventHandler(this.actualizarTabla);
            
            #line default
            #line hidden
            return;
            case 5:
            this.gu_btnCrearUsuario = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\MenuPrincipal.xaml"
            this.gu_btnCrearUsuario.Click += new System.Windows.RoutedEventHandler(this.nuevoUsuario);
            
            #line default
            #line hidden
            return;
            case 6:
            this.gu_tblUsuarios = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.txtMensaje = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.menuReporte = ((System.Windows.Controls.TabItem)(target));
            return;
            case 9:
            this.menuActividad = ((System.Windows.Controls.TabItem)(target));
            return;
            case 10:
            this.btnLogout = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\MenuPrincipal.xaml"
            this.btnLogout.Click += new System.Windows.RoutedEventHandler(this.logout);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
