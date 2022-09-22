﻿using System;
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
            cmd.Parameters.Add("id_comu", OracleDbType.Int16).Value = 1;
            cmd.Parameters.Add("direc", OracleDbType.Varchar2).Value = direccion;

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
                            id_usuario = Convert.ToInt16(fila["ID_USUARIO"]),
                            contraseña = Convert.ToString(fila["CONTRASEÑA"]),
                            tipo = Convert.ToString(fila["TIPO"]),
                            id_comuna = Convert.ToInt16(fila["ID_COMUNA"]),
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
            cmd.Parameters.Add("idUsr", OracleDbType.Int16).Value = id;

            //Ejecución
            conn.Open();
            using (OracleDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    Usuario usuario = new Usuario { id_usuario = r.GetInt16(0), contraseña = r.GetString(1), tipo = r.GetString(2), id_comuna = r.GetInt16(3), direccion = r.GetString(4), estado = r.GetBoolean(5) };
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
            cmd.Parameters.Add("id_usu", OracleDbType.Int16).Value = id_usuario;
            cmd.Parameters.Add("rutAdm", OracleDbType.Varchar2).Value = rut;
            cmd.Parameters.Add("nombre", OracleDbType.Varchar2).Value = nombre;

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
                            id_usuario = Convert.ToInt16(fila["ID_USUARIO"]),
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
                    Administrador administrador = new Administrador { id_usuario = r.GetInt16(0), rut = r.GetString(1), nombre = r.GetString(2)};
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
            cmd.Parameters.Add("idAdm", OracleDbType.Int16).Value = id;

            //Ejecución
            conn.Open();
            using (OracleDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    Administrador administrador = new Administrador { id_usuario = r.GetInt16(0), rut = r.GetString(1), nombre = r.GetString(2) };
                    conn.Close();
                    return administrador;
                }
            }
            return null;
        }
    }
}
