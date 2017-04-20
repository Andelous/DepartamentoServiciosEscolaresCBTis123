using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DAOs
{
    public class DAOUsuarios : DAO
    {
        // SELECTS

        public Usuario seleccionarUsuarioPorID(int idUsuario)
        {
            Usuario u = null;
            string query = 
                "SELECT * FROM usuarios WHERE " + 
                "idUsuario = " + idUsuario + ";";

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            if (dr.Read())
            {
                u = new Usuario();

                u.idUsuario = Convert.ToInt32(dr["idUsuario"]);

                u.usuario = dr["usuario"].ToString();
                u.contrasena = dr["contrasena"].ToString();

                u.nombre = dr["nombre"].ToString();
                u.apellidoPaterno = dr["apellidoPaterno"].ToString();
                u.apellidoMaterno = dr["apellidoMaterno"].ToString();

                u.tipoUsuario = (TipoUsuario)Convert.ToInt32(dr["tipoUsuario"]);
            }

            dr.Close();
            return u;
        }

        public Usuario seleccionarUsuarioPorUsuarioContrasena(string usuario, string contrasena)
        {
            Usuario u = null;
            string query = "SELECT * FROM usuarios WHERE " + 
                "usuario = '" + usuario + "' AND " + 
                "contrasena = '" + contrasena + "';";

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            if (dr.Read())
            {
                u = new Usuario();

                u.idUsuario = Convert.ToInt32(dr["idUsuario"]);

                u.usuario = dr["usuario"].ToString();
                u.contrasena = dr["contrasena"].ToString();

                u.nombre = dr["nombre"].ToString();
                u.apellidoPaterno = dr["apellidoPaterno"].ToString();
                u.apellidoMaterno = dr["apellidoMaterno"].ToString();

                u.tipoUsuario = (TipoUsuario)Convert.ToInt32(dr["tipoUsuario"]);
            }

            dr.Close();
            return u;
        }
    }
}
