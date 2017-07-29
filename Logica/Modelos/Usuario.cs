using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Modelos
{
    public class Usuario
    {
        public int idUsuario { get; set; }

        public string usuario { get; set; }
        public string contrasena { get; set; }

        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }

        public TipoUsuario tipoUsuario { get; set; }

        public override string ToString()
        {
            return nombre + " " + apellidoPaterno + " " + apellidoMaterno;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() == typeof(Usuario))
                {
                    Usuario u = (Usuario)obj;

                    if (u.idUsuario == idUsuario)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
