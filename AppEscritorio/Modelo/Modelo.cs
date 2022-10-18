using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace Modelo
{
    public static class Variables
    {
        public static String connexion_String { get; set; }
        static Variables()
        {
            connexion_String =  "DATA SOURCE = localhost:1522/ORCL1; PASSWORD=123456;USER ID = SSAP";      
        }
    }

    //-------------- Modelos de Usuario -------------------

    public class Usuario
    {
        public int id_usuario { get; set; }
        public String contraseña { get; set; }
        public String tipo { get; set; }
        public int id_comuna { get; set; }
        public String direccion { get; set; }
        public bool estado { get; set; }
        public void guardar()
        { 
            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("INSERTARUSUARIO", conn);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("pass", OracleDbType.Varchar2).Value = contraseña;
            cmd.Parameters.Add("tipo", OracleDbType.Varchar2).Value = tipo;
            cmd.Parameters.Add("id_comu", OracleDbType.Int32).Value = id_comuna;
            cmd.Parameters.Add("direc", OracleDbType.Varchar2).Value = direccion;

            //Ejecutar comando
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void desactivar()
        {
            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("ACTUALIZARUSUARIO", conn);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id_usr", OracleDbType.Int32).Value = id_usuario;
            cmd.Parameters.Add("contraseña", OracleDbType.Varchar2).Value = contraseña;
            cmd.Parameters.Add("tipo", OracleDbType.Varchar2).Value = tipo;
            cmd.Parameters.Add("IdComuna", OracleDbType.Int32).Value = id_comuna;
            cmd.Parameters.Add("direccion", OracleDbType.Varchar2).Value = direccion;
            cmd.Parameters.Add("estado", OracleDbType.Int32).Value = 0;

            //Ejecutar comando
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void activar()
        {
            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("ACTUALIZARUSUARIO", conn);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id_usr", OracleDbType.Int32).Value = id_usuario;
            cmd.Parameters.Add("contraseña", OracleDbType.Varchar2).Value = contraseña;
            cmd.Parameters.Add("tipo", OracleDbType.Varchar2).Value = tipo;
            cmd.Parameters.Add("IdComuna", OracleDbType.Int32).Value = id_comuna;
            cmd.Parameters.Add("direccion", OracleDbType.Varchar2).Value = direccion;
            cmd.Parameters.Add("estado", OracleDbType.Int32).Value = 1;

            //Ejecutar comando
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void actualizar()
        {
            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("ACTUALIZARUSUARIO", conn);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id_usr", OracleDbType.Int32).Value = id_usuario;
            cmd.Parameters.Add("contraseña", OracleDbType.Varchar2).Value = contraseña;
            cmd.Parameters.Add("tipo", OracleDbType.Varchar2).Value = tipo;
            cmd.Parameters.Add("IdComuna", OracleDbType.Int32).Value = id_comuna;
            cmd.Parameters.Add("direccion", OracleDbType.Varchar2).Value = direccion;
            cmd.Parameters.Add("estado", OracleDbType.Int32).Value = estado;

            //Ejecutar comando
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static List<Usuario> todos(bool orden_id = false)
        {
            //Definir Variables
            List<Usuario> usuarios = new List<Usuario>();
            DataTable dt = new DataTable();
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("SELECCIONARUSUARIOS", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("registro", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("order_id", OracleDbType.Boolean).Value = orden_id;

            //Llenar Lista
            conn.Open();
            da.Fill(dt);
            usuarios = (from fila in dt.AsEnumerable() select new Usuario
                        {
                            id_usuario = Convert.ToInt32(fila["ID_USUARIO"]),
                            contraseña = Convert.ToString(fila["CONTRASEÑA"]),
                            tipo = Convert.ToString(fila["TIPO"]),
                            id_comuna = Convert.ToInt32(fila["ID_COMUNA"]),
                            direccion = Convert.ToString(fila["DIRECCION"]),
                            estado = Convert.ToBoolean(fila["ESTADO"])
                        }).ToList();
            conn.Close();
            return usuarios;
        }
        public static Usuario filtro_id(int id)
        {
            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("USUARIO_PORID", conn);

            //Parámetros comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("registro", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("idUsr", OracleDbType.Int32).Value = id;

            //Ejecución
            conn.Open();
            using (OracleDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    Usuario usuario = new Usuario { id_usuario = r.GetInt32(0), contraseña = r.GetString(1), tipo = r.GetString(2), id_comuna = r.GetInt32(3), direccion = r.GetString(4), estado = r.GetBoolean(5) };
                    conn.Close();
                    return usuario;
                }
            }
            return null;
        }
    }

    public class Administrador
    {
        public int id_usuario { get; set; }
        public String rut { get; set; }
        public String nombre { get; set; }
        public void guardar()
        {
            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("INSERTARADMINISTRADOR", conn);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id_usu", OracleDbType.Int32).Value = id_usuario;
            cmd.Parameters.Add("rutAdm", OracleDbType.Varchar2).Value = rut;
            cmd.Parameters.Add("nombre", OracleDbType.Varchar2).Value = nombre;

            //Ejecutar comando
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void actualizar()
        {
            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("ACTUALIZARADMINISTRADOR", conn);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id_usr", OracleDbType.Int32).Value = id_usuario;
            cmd.Parameters.Add("rut", OracleDbType.Varchar2).Value = rut;
            cmd.Parameters.Add("nombre_adm", OracleDbType.Varchar2).Value = nombre;

            //Ejecutar comando
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static List<Administrador> todos()
        {
            //Definir Variables
            List<Administrador> lista = new List<Administrador>();
            DataTable dt = new DataTable();
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("SELECCIONARADMINISTRADORES", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("registro", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            //Llenar Lista
            conn.Open();
            da.Fill(dt);
            lista = (from fila in dt.AsEnumerable()
                        select new Administrador
                        {
                            id_usuario = Convert.ToInt32(fila["ID_USUARIO"]),
                            rut = Convert.ToString(fila["RUT_ADMIN"]),
                            nombre = Convert.ToString(fila["NOMBRE"])
                        }).ToList();
            conn.Close();
            return lista;
        }
        public static Administrador filtro_rut(String rut_adm = null)
        {
            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("ADMIN_PORRUT", conn);

            //Parámetros comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("registro", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("rutAdm", OracleDbType.Varchar2).Value = rut_adm;

            //Ejecución
            conn.Open();
            using (OracleDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    Administrador administrador = new Administrador { id_usuario = r.GetInt32(0), rut = r.GetString(1), nombre = r.GetString(2)};
                    conn.Close();
                    return administrador;
                }
            }
            return null;
        }
        public static Administrador filtro_id(int id)
        {
            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("ADMIN_PORID", conn);

            //Parámetros comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("registro", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("idAdm", OracleDbType.Int32).Value = id;

            //Ejecución
            conn.Open();
            using (OracleDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    Administrador administrador = new Administrador { id_usuario = r.GetInt32(0), rut = r.GetString(1), nombre = r.GetString(2) };
                    conn.Close();
                    return administrador;
                }
            }
            return null;
        }
    }

    public class Profesional
    {
        public int id_usuario { get; set; }
        public String rut { get; set; }
        public String nombre { get; set; }
        public void guardar()
        {
            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("INSERTARPROFESIONAL", conn);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id_usu", OracleDbType.Int32).Value = id_usuario;
            cmd.Parameters.Add("rutProf", OracleDbType.Varchar2).Value = rut;
            cmd.Parameters.Add("nombre", OracleDbType.Varchar2).Value = nombre;

            //Ejecutar comando
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void actualizar()
        {

            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("ACTUALIZARPROFESIONAL", conn);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id_usr", OracleDbType.Int32).Value = id_usuario;
            cmd.Parameters.Add("rut", OracleDbType.Varchar2).Value = rut;
            cmd.Parameters.Add("nombre_pro", OracleDbType.Varchar2).Value = nombre;

            //Ejecutar comando
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static List<Profesional> todos()
        {
            //Definir Variables
            List<Profesional> lista = new List<Profesional>();
            DataTable dt = new DataTable();
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("SELECCIONARPROFESIONALES", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("registro", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            //Llenar Lista
            conn.Open();
            da.Fill(dt);
            lista = (from fila in dt.AsEnumerable()
                     select new Profesional
                     {
                         id_usuario = Convert.ToInt32(fila["ID_USUARIO"]),
                         rut = Convert.ToString(fila["RUT_PROF"]),
                         nombre = Convert.ToString(fila["NOMBRE"])
                     }).ToList();
            conn.Close();
            return lista;
        }
        public static Profesional filtro_rut(String rut_prof = null)
        {
            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("PROFESIONAL_PORRUT", conn);

            //Parámetros comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("registro", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("rutPro", OracleDbType.Varchar2).Value = rut_prof;

            //Ejecución
            conn.Open();
            using (OracleDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    Profesional profesional = new Profesional { id_usuario = r.GetInt32(0), rut = r.GetString(1), nombre = r.GetString(2) };
                    conn.Close();
                    return profesional;
                }
            }
            return null;
        }
        public static Profesional filtro_id(int id)
        {
            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("PROFESIONAL_PORID", conn);

            //Parámetros comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("registro", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("idPro", OracleDbType.Int32).Value = id;

            //Ejecución
            conn.Open();
            using (OracleDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    Profesional profesional = new Profesional{ id_usuario = r.GetInt32(0), rut = r.GetString(1), nombre = r.GetString(2) };
                    conn.Close();
                    return profesional;
                }
            }
            return null;
        }
    }

    public class Cliente
    {
        public int id_usuario { get; set; }
        public String rut { get; set; }
        public String nombre_empresa { get; set; }
        public String rubro_empresa { get; set; }
        public int cant_trabajadores { get; set; }
        public void guardar()
        {
            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("INSERTARCLIENTE", conn);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id_usu", OracleDbType.Int32).Value = id_usuario;
            cmd.Parameters.Add("rutCli", OracleDbType.Varchar2).Value = rut;
            cmd.Parameters.Add("nomEmpre", OracleDbType.Varchar2).Value = nombre_empresa;
            cmd.Parameters.Add("rubroEmpre", OracleDbType.Varchar2).Value = rubro_empresa;
            cmd.Parameters.Add("cant", OracleDbType.Int32).Value = cant_trabajadores;

            //Ejecutar comando
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void actualizar()
        {

            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("ACTUALIZARCLIENTE", conn);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id_usr", OracleDbType.Int32).Value = id_usuario;
            cmd.Parameters.Add("rut_usr", OracleDbType.Varchar2).Value = rut;
            cmd.Parameters.Add("nombre", OracleDbType.Varchar2).Value = nombre_empresa;
            cmd.Parameters.Add("rubro", OracleDbType.Varchar2).Value = rubro_empresa;
            cmd.Parameters.Add("c_trab", OracleDbType.Int32).Value = cant_trabajadores;

            //Ejecutar comando
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static List<Cliente> todos()
        {
            //Definir Variables
            List<Cliente> lista = new List<Cliente>();
            DataTable dt = new DataTable();
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("SELECCIONARCLIENTES", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("registro", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            //Llenar Lista
            conn.Open();
            da.Fill(dt);
            lista = (from fila in dt.AsEnumerable()
                     select new Cliente
                     {
                         id_usuario = Convert.ToInt32(fila["ID_USUARIO"]),
                         rut = Convert.ToString(fila["RUT_CLIENTE"]),
                         nombre_empresa = Convert.ToString(fila["NOMBRE_EMPRESA"]),
                         rubro_empresa = Convert.ToString(fila["RUBRO_EMPRESA"]),
                         cant_trabajadores = Convert.ToInt32(fila["CANT_TRABAJADORES"])
                     }).ToList();
            conn.Close();
            return lista;
        }
        public static Cliente filtro_rut(String rut_cli = null)
        {
            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("CLIENTE_PORRUT", conn);

            //Parámetros comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("registro", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("rutCli", OracleDbType.Varchar2).Value = rut_cli;

            //Ejecución
            conn.Open();
            using (OracleDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    Cliente cliente = new Cliente { id_usuario = r.GetInt32(0), rut = r.GetString(1), nombre_empresa = r.GetString(2), rubro_empresa = r.GetString(3), cant_trabajadores = r.GetInt32(4) };
                    conn.Close();
                    return cliente;
                }
            }
            return null;
        }
        public static Cliente filtro_id(int id)
        {
            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("CLIENTE_PORID", conn);

            //Parámetros comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("registro", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("idCli", OracleDbType.Int32).Value = id;

            //Ejecución
            conn.Open();
            using (OracleDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    Cliente cliente = new Cliente { id_usuario = r.GetInt32(0), rut = r.GetString(1), nombre_empresa = r.GetString(2), rubro_empresa = r.GetString(3), cant_trabajadores = r.GetInt32(4) };
                    conn.Close();
                    return cliente;
                }
            }
            return null;
        }
    }

    //--------------Modelos control Cliente--------------
    
    public class Contrato
    {
        public int id_contrato { get; set; }
        public int costo_base { get; set; }
        public DateTime fecha_firma { get; set; }
        public DateTime ultimo_pago { get; set; }
        public String CLIENTE_rut { get; set; }
        public String PROFESIONAL_rut { get; set; }
        public void guardar()
        {
            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("INSERTARCONTRATO", conn);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("costo", OracleDbType.Int32).Value = costo_base;
            cmd.Parameters.Add("fecha", OracleDbType.Date).Value = fecha_firma;
            cmd.Parameters.Add("rutCli", OracleDbType.Varchar2).Value = CLIENTE_rut;
            cmd.Parameters.Add("rutPro", OracleDbType.Varchar2).Value = PROFESIONAL_rut;

            //Ejecutar comando
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            guardar_checklist();
        }
        public static Contrato filtro_rutcliente(String rut)
        {
            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("contrato_porRutCliente", conn);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("registro", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("rutCli", OracleDbType.Varchar2).Value = rut;

            //Ejecutar comando
            conn.Open();
            using (OracleDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    Contrato contrato = new Contrato { id_contrato = r.GetInt32(0), costo_base = r.GetInt32(1), fecha_firma = r.GetDateTime(2), ultimo_pago = r.GetDateTime(3), CLIENTE_rut = r.GetString(4), PROFESIONAL_rut = r.GetString(5) };
                    conn.Close();
                    return contrato;
                }
            }
            return null;
        }
        private Contrato filtro_rutcliente()
        {
            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("contrato_porRutCliente", conn);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("registro", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("rutCli", OracleDbType.Varchar2).Value = CLIENTE_rut;

            //Ejecutar comando
            conn.Open();
            using (OracleDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    Contrato contrato = new Contrato { id_contrato = r.GetInt32(0), costo_base = r.GetInt32(1), fecha_firma = r.GetDateTime(2), ultimo_pago = r.GetDateTime(3), CLIENTE_rut = r.GetString(4), PROFESIONAL_rut = r.GetString(5) };
                    conn.Close();
                    return contrato;
                }
            }
            return null;
        }
        private void guardar_checklist()
        {
            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("INSERTARCHECKLIST", conn);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("idCtr", OracleDbType.Int32).Value = filtro_rutcliente().id_contrato;

            //Ejecutar comando
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }

    //--------------Modelos de Ubicación--------------

    public class Ubicacion
    {
        public int id_comuna { get; set; }
        public String nombre_comuna { get; set; }
        public String nombre_ciudad { get; set; }
        public String nombre_region { get; set; }
        public static List<Ubicacion> todos()
        {
            //Definir Variables
            List<Ubicacion> lista = new List<Ubicacion>();
            DataTable dt = new DataTable();
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("SELECCIONARUBICACION", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("registro", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            //Llenar Lista
            conn.Open();
            da.Fill(dt);
            lista = (from fila in dt.AsEnumerable()
                     select new Ubicacion
                     {
                         id_comuna = Convert.ToInt32(fila["ID_COMUNA"]),
                         nombre_comuna = Convert.ToString(fila["NOMBRE_COMUNA"]),
                         nombre_ciudad = Convert.ToString(fila["NOMBRE_CIUDAD"]),
                         nombre_region = Convert.ToString(fila["NOMBRE_REGION"])
                     }).ToList();
            conn.Close();
            return lista;
        }
    }

    //--------------Modelos de Actividades--------------

    public class Actividad
    {
        public String nombre_profesional { get; set; }
        public String tipo { get; set; }
        public DateTime fecha { get; set; }
        public String ubicacion { get; set; }
        public static List<Actividad> obtener(String rut_pro)
        {
            //Definir Variables
            List<Actividad> lista = new List<Actividad>();
            DataTable dt = new DataTable();
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("ACTIVIDADPROFVISITA", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("registro", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("rutProf", OracleDbType.Varchar2).Value = rut_pro;
            //Llenar Lista
            conn.Open();
            //---Tipo: Visita---
            da.Fill(dt);
            lista.AddRange((from fila in dt.AsEnumerable()
                     select new Actividad
                     {
                         nombre_profesional = Convert.ToString(fila["NOMBRE_PRO"]),
                         tipo = "Visita",
                         fecha = Convert.ToDateTime(fila["FECHA"]),
                         ubicacion = Convert.ToString(fila["UBICACION"])+", \n"+Convert.ToString(fila["COMUNA"])
                     }).ToList());

            //---Tipo: Capacitacion---
            dt.Clear();
            OracleCommand cmd1 = new OracleCommand("ACTIVIDADPROFCAPACITACION", conn);
            OracleDataAdapter da1 = new OracleDataAdapter(cmd1);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("registro", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            cmd1.Parameters.Add("rutProf", OracleDbType.Varchar2).Value = rut_pro;
            da1.Fill(dt);
            lista.AddRange((from fila in dt.AsEnumerable()
                     select new Actividad
                     {
                         nombre_profesional = Convert.ToString(fila["NOMBRE_ENCARGADO"]),
                         tipo = "Capacitacion",
                         fecha = Convert.ToDateTime(fila["FECHA_CAPACITACION"]),
                         ubicacion = Convert.ToString(fila["UBICACION"]) + ", \n" + Convert.ToString(fila["COMUNA"])
                     }).ToList());

            //---Tipo: Asesoria---
            dt.Clear();
            OracleCommand cmd2 = new OracleCommand("ACTIVIDADPROFASESORIA", conn);
            OracleDataAdapter da2 = new OracleDataAdapter(cmd2);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("registro", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            cmd2.Parameters.Add("rutProf", OracleDbType.Varchar2).Value = rut_pro;
            da2.Fill(dt);
            lista.AddRange((from fila in dt.AsEnumerable()
                     select new Actividad
                     {
                         nombre_profesional = Convert.ToString(fila["NOMBRE_ENCARGADO"]),
                         tipo = "Asesoria",
                         fecha = Convert.ToDateTime(fila["FECHA_CREACION"]),
                         ubicacion = "N/A"
                     }).ToList());
            conn.Close();
            return lista;
        }
    }

    //--------------Modelos de Pagos--------------

    public class Mensualidad
    {
        public int id_mensualidad { get; set; }
        public DateTime fecha_limite { get; set; }
        public bool estado { get; set; }
        public int costo { get; set; }
        public int id_contrato { get; set; }
        public String fecha_pago { get; set; }
        public String boleta { get; set; }
        public static List<Mensualidad> todos_idcontrato(int id_con)
        {

            //Definir Variables
            List<Mensualidad> lista = new List<Mensualidad>();
            DataTable dt = new DataTable();
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("PAGO_PORIDCONTRATO", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("registro", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("idCtr", OracleDbType.Int32).Value = id_con;

            //Llenar Lista
            conn.Open();
            da.Fill(dt);
            lista = (from fila in dt.AsEnumerable()
                     select new Mensualidad
                     {
                         id_mensualidad = Convert.ToInt32(fila["ID_MENSUALIDAD"]),
                         fecha_limite = Convert.ToDateTime(fila["FECHA_LIMITE"]),
                         estado = Convert.ToBoolean(fila["ESTADO"]),
                         costo = Convert.ToInt32(fila["COSTO"]),
                         id_contrato = Convert.ToInt32(fila["ID_CONTRATO"]),
                         fecha_pago = Convert.ToString(fila["FECHA_PAGO"]),
                         boleta = Convert.ToString(fila["BOLETA"])
                     }).ToList();
            conn.Close();
            return lista;
        }
    }
    public class Pagos_Mensual
    {
        
        public int año { get; set; }
        public String mes { get; set; }
        public int costo { get; set; }

        public static List<Pagos_Mensual> Todos ()
        {

            //Definir Variables
            List<Pagos_Mensual> lista = new List<Pagos_Mensual>();
            DataTable dt = new DataTable();
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("PA_BUSCAR_PAGOS", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("registro", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //Llenar Lista
            conn.Open();
            da.Fill(dt);
            lista = (from fila in dt.AsEnumerable()
                     select new Pagos_Mensual
                     {
                         año = Convert.ToInt32(fila["AÑO"]),
                         mes = Convert.ToString(fila["MES"]),
                         costo = Convert.ToInt32(fila["TOTAL_MENSUAL"]),
                      
                     }).ToList();
            conn.Close();
            return lista;
        }

    }


    public class Notificacion
    {
        public int id_notificacion { get; set; }
        public String titulo { get; set; }
        public String descripcion { get; set; }
        public DateTime fecha { get; set; }
        public String CLIENTE_rut { get; set; }
        public void guardar()
        {
            //Definir Variables
            OracleConnection conn = new OracleConnection(Variables.connexion_String);
            OracleCommand cmd = new OracleCommand("INSERTARNOTIFICACION", conn);

            //Dar parámetros al comando
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("titulo", OracleDbType.Varchar2).Value = titulo;
            cmd.Parameters.Add("descrip", OracleDbType.Varchar2).Value = descripcion;
            cmd.Parameters.Add("fecha", OracleDbType.Date).Value = fecha;
            cmd.Parameters.Add("rutCli", OracleDbType.Varchar2).Value = CLIENTE_rut;

            //Ejecutar comando
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
