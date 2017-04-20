using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Controladores
{
    public enum EstadoSesion
    {
        ErrorDesconocido = -2,
        ErrorDelServidor = -1,
        CredencialesIncorrectas = 0,
        SesionIniciadaConExito = 1
    }
}
