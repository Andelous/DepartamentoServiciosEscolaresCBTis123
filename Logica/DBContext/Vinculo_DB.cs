using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DBContext
{
    public static class Vinculo_DB
    {
        private static string[] datosConexion
        {
            get
            {
                return File.ReadAllLines("host.sys");
            }
        }
        public static string userID
        {
            get
            {
                return datosConexion[0].Trim();
            }
        }
        public static string password
        {
            get
            {
                return datosConexion[1].Trim();
            }
        }
        public static string server
        {
            get
            {
                return datosConexion[2].Trim();
            }
        }
        public static string database
        {
            get
            {
                return datosConexion[3].Trim();
            }
        }

        public static uint puerto
        {
            get
            {
                return Convert.ToUInt32(datosConexion[4].Trim());
            }
        }

        public static MySqlConnectionStringBuilder scb { get; set; }

        static Vinculo_DB()
        {
            scb = null;
        }

        public static void inicializarConexion()
        {
            scb = new MySqlConnectionStringBuilder();

            scb.UserID = userID;
            scb.Password = password;
            scb.Server = server;
            scb.Database = database;
            //scb.Port = puerto;
        }

        public static CBTis123_Entities generarContexto()
        {
            CBTis123_Entities bd = null;
            inicializarConexion();
            
            try
            {
                bd = new CBTis123_Entities(
                    "metadata=res://*/Logica.DBContext.CBTis123_Model.csdl|res://*/Logica.DBContext.CBTis123_Model.ssdl|res://*/Logica.DBContext.CBTis123_Model.msl;provider=MySql.Data.MySqlClient;provider connection string=\"" +
                    scb.ToString() +
                    "\";"
                );
                
                bd.usuarios.Where(u => true);
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }

            return bd;
        }

        public static bool probarConexion()
        {
            inicializarConexion();

            try
            {
                CBTis123_Entities bd = new CBTis123_Entities(
                    scb.ToString()
                );

                //object[] asdf = { "asdf", "" };
                bd.usuarios.Where(u => true);
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
                return false;
            }

            return true;
        }
    }
}
