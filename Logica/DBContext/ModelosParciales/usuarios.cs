using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DBContext
{
    public partial class usuarios
    {
        public override string ToString()
        {
            return nombre + " " + apellidoPaterno + " " + apellidoMaterno;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() == GetType())
                {
                    usuarios u = (usuarios)obj;

                    return u.idUsuario == idUsuario;
                }
            }

            return false;
        }
    }
}
