using Modelo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Controlador
{
    public class Ctrl
    {
        public Usuario logueado { get; set; }
        public Administrador admin { get; set; }
        public static string mensaje { get; set; }
        //Test
        public static void PruebaCRT()
        {
            Usuario usuario = Usuario.filtro_id(7);
            Debug.WriteLine("----------------------------------------------------");
            Debug.WriteLine(usuario.direccion);
            Administrador administrador = Administrador.filtro_id(1);
            Debug.WriteLine(administrador.nombre);
            Administrador administrador1 = Administrador.filtro_rut("11.222.333-4");
            Debug.WriteLine(administrador1.nombre);
            Debug.WriteLine("----------------------------------------------------");
            Profesional profesional = Profesional.filtro_id(7);
            Profesional profesional1 = Profesional.filtro_rut("22.333.444-5");
            Debug.WriteLine(profesional.nombre);
            Debug.WriteLine(profesional1.nombre);
            Debug.WriteLine("----------------------------------------------------");
            Cliente cliente = Cliente.filtro_id(8);
            Cliente cliente1 = Cliente.filtro_rut("33.444.555-6");
            Debug.WriteLine(cliente.nombre_empresa);
            Debug.WriteLine(cliente1.nombre_empresa);
        }
        //Funciones

        public static bool usuarioNoExiste(String rut)
        {
            if (Cliente.filtro_rut(rut) is null & Administrador.filtro_rut(rut) is null & Profesional.filtro_rut(rut) is null)
            {
                return true;
            }
            return false;
        }

        //Página Login
        public static Ctrl login(String rut, String password)
        {
            Administrador administrador = Administrador.filtro_rut(rut);
            if (administrador == null)
            {
                return null;
            }
            Usuario usuario = Usuario.filtro_id(administrador.id_usuario);
            if (usuario.contraseña == password & usuario.estado)
            {
                return new Ctrl{logueado=usuario, admin=administrador};
            }
            return null;
        }

        //----GESTION DE USUARIOS----
        //  Crear Usuario
        public static void crearUsuario(Usuario usuario, Cliente cliente, Contrato contrato)
        {
            if(usuarioNoExiste(cliente.rut))
            {
                usuario.guardar();
                List<Usuario> usuarios = Usuario.todos(true);
                cliente.id_usuario = usuarios.Last<Usuario>().id_usuario;
                cliente.guardar();
                contrato.guardar();
                mensaje = "Usuario "+cliente.nombre_empresa+" creado correctamente";
            }
            else
            {
                mensaje = "ERROR: Rut duplicado";
            }
        }

        public static void crearUsuario(Usuario usuario, Profesional profesional)
        {
            if (usuarioNoExiste(profesional.rut))
            {
                usuario.guardar();
                List<Usuario> usuarios = Usuario.todos(true);
                profesional.id_usuario = usuarios.Last<Usuario>().id_usuario;
                profesional.guardar();
                mensaje = "Usuario "+profesional.nombre+" creado correctamente";
            }
            else
            {
                mensaje = "ERROR: Rut duplicado";
            }
        }

        public static void crearUsuario(Usuario usuario, Administrador administrador)
        {
            if(usuarioNoExiste(administrador.rut))
            {
                usuario.guardar();
                List<Usuario> usuarios = Usuario.todos(true);
                administrador.id_usuario = usuarios.Last<Usuario>().id_usuario;
                administrador.guardar();
                mensaje = "Usuario " + administrador.nombre + " creado correctamente";
            }
            else
            {
                mensaje = "ERROR: Rut Duplicado";
            }
        }

        //  Modificar Usuario

        public static void modificarUsuario(Usuario usuario, Cliente cliente)
        {
            usuario.actualizar();
            cliente.actualizar();
            mensaje = "Usuario " + cliente.nombre_empresa + " actualizado.";
        }

        public static void modificarUsuario(Usuario usuario, Profesional profesional)
        {
            usuario.actualizar();
            profesional.actualizar();
            mensaje = "Usuario " + profesional.nombre + " actualizado";
        }

        public static void modificarUsuario(Usuario usuario, Administrador administrador)
        {
            usuario.actualizar();
            administrador.actualizar();
            mensaje = "Usuario " + administrador.nombre + " actualizado";
        }

        // Habilitar/Deshabilitar Usuario
        public static void estadoUsuario(int id)
        {
            Usuario usuario = Usuario.filtro_id(id);
            if (usuario.estado)
            {
                usuario.desactivar();
                mensaje = "Usuario Deshabilitado";
            }
            else
            {
                usuario.activar();
                mensaje = "Usuario Habilitado";
            }
        }
    }
}
