using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Utilerias
{
    public class ValidadorDeTexto
    {
        private static Regex _reg = new Regex("[a-zA-Z0-9áéíóúüÁÉÍÓÚÜÑñ., _@-]+");
        private static Regex reg {
            get
            {
                return _reg;
            }
        }

        public static bool esValido(string str)
        {
            MatchCollection matchCollection = reg.Matches(str);

            if (matchCollection.Count == 1)
            {
                return matchCollection[0].Value.Equals(str);
            }

            return false;
        }
    }
}
