using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Controladores
{
    public class ControladorDocentes
    {
        // DAOs necesarios
        private DAODocentes daoDocentes { get; set; }

        // Controladores necesarios

        // Métodos de iniciación
        public ControladorDocentes()
        {
            this.daoDocentes = new DAODocentes();
        }

        // Métodos de manipulación del modelo
        // Selección
        public List<Docente> seleccionarDocentes()
        {
            List<Docente> listaDocentes = new List<Docente>();

            // Intentamos realizar la operación. Si hubo algún error,
            // el controlador visual mostrará el mensaje correspondiente.
            try
            {
                listaDocentes = daoDocentes.seleccionarDocentes();
            }
            catch (MySqlException e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionMySqlException(e));
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }

            // Devolvemos resultado
            return listaDocentes;
        }

    }
}
