using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Controlador
{
    public static class Validar
    {
        public static string mensaje;

        public static bool noVacio(string entrada)
        {
            if (entrada.Trim() == "")
            {
                mensaje = "Campo Requerido";
                return false;
            }
            mensaje = "";
            return true;
        }

        public static bool minLength(string entrada, int largo)
        {
            if (entrada.Length < largo)
            {
                mensaje = $"Mínimo {largo} carácteres";
                return false;
            }
            mensaje = "";
            return true;
        }

        public static bool maxLength(string entrada, int largo)
        {
            if(entrada.Length > largo)
            {
                mensaje = $"Máximo {largo} carácteres";
                return false;
            }
            mensaje = "";
            return true;
        }

        public static bool rutValido(string entrada)
        {
            String patron = @"^(\d{1,3}(?:\.\d{1,3}){2}-[\dkK])$";
            Regex regex = new Regex(patron);
            if (!regex.IsMatch(entrada))
            {
                mensaje = "Rut Inválido";
                return false;
            }
            mensaje = "";
            return true;
        }

        public static bool numero(string entrada)
        {
            if(!Int32.TryParse(entrada,out int resultado))
            {
                mensaje = "Solo se aceptan números";
                return false;
            }
            mensaje = "";
            return true;
        }

        public static bool contraseñasIguales(string entrada, string repetirEntrada)
        {
            if (!entrada.Equals(repetirEntrada))
            {
                mensaje = "Ambas contraseñas deben ser iguales";
                return false;
            }
            return true;
        }

        public static bool mail(string entrada)
        {
            String patron = @"^[\w-\.]+@([\w-\.]+)$";
            Regex regex = new Regex(patron);
            if (!regex.IsMatch(entrada))
            {
                mensaje = "Ingrese un mail válido";
                return false;
            }
            return true;
        }
    }
}
