using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Controladores
{
    public enum ResultadoOperacion
    {
        Error,
        Correcto,
        ErrorAplicacion,
        ErrorConexionServidor,
        ErrorDatosIncorrectos,
        ErrorDependenciaDeDatos,
        ErrorSintaxisSQL
    }
}
