using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Controladores
{
    public class ResultadoOperacion
    {
        public EstadoOperacion estadoOperacion { get; }
        public string str { get; }
        public string errCode { get; }

        public ResultadoOperacion(EstadoOperacion estadoOperacion, string str = null, string errCode = null)
        {
            this.estadoOperacion = estadoOperacion;
            this.str = str;
            this.errCode = errCode;
        }

        public override string ToString()
        {
            string parentesis = str != null ? "\n(" + str + ")" : "";
            string corchetes = errCode != null ? "\n[ErrCode: " + errCode + "]" : "";

            return "_" + estadoOperacion.ToString() + "_" + parentesis + corchetes;
        }
    }

    public enum EstadoOperacion
    {
        // Estados de la aplicacion

        Correcto,
        NingunResultado,
        ErrorCredencialesIncorrectas,
        ErrorDatosIncorrectos,
        ErrorDependenciaDeDatos,

        
        
        // Estados vinculados con excepciones

        ErrorDesconocido,
        ErrorAplicacion,
        ErrorConexionServidor,
        ErrorAcceso_SintaxisSQL,
        ErrorEnServidor
    }
}
