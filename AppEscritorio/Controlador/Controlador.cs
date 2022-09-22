using Modelo;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Controlador
{
    public class Ctrl
    {
        //Test
        public static void PruebaCRT()
        {
            Usuario usuario = Usuario.filtro_id(7);
            Debug.WriteLine(usuario.direccion);
            Administrador administrador = Administrador.filtro_id(1);
            Debug.WriteLine(administrador.nombre);
            Administrador administrador1 = Administrador.filtro_rut("11.222.333-4");
            Debug.WriteLine(administrador1.nombre);
        }
        //Página Login
        public static Usuario login(String rut, String password)
        {
            Administrador administrador = Administrador.filtro_rut(rut);
            if (administrador == null)
            {
                return null;
            }
            Usuario usuario = Usuario.filtro_id(administrador.id_usuario);
            if (usuario.contraseña == password)
            {
                return usuario;
            }
            return null;
        }
    }
}
