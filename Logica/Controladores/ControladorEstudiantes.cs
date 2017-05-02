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
    public class ControladorEstudiantes
    {
        // Propiedades
        // DAOs
        private DAOEstudiantes daoEstudiantes { get; set; }

        // Controladores adicionales.
        public ControladorSemestres controladorSemestres { get; set; }
        public ControladorGrupos controladorGrupos { get; set; }

        // Métodos de inicialización
        public ControladorEstudiantes(ControladorSemestres controladorSemestres = null)
        {
            this.daoEstudiantes = new DAOEstudiantes();

            this.controladorSemestres =
                controladorSemestres == null ?
                new ControladorSemestres()
                :
                controladorSemestres;

            this.controladorGrupos = this.controladorSemestres.controladorGrupos;
        }

        // Métodos de manipulación de los modelos
        // Selección
        public List<Semestre> seleccionarSemestres()
        {
            return controladorSemestres.seleccionarSemestresLista();
        }

        public List<Grupo> seleccionarGrupos(Semestre s)
        {
            return controladorGrupos.seleccionarGrupos(s);
        }

        public List<Estudiante> seleccionarEstudiantes()
        {
            List<Estudiante> listaEstudiantes = new List<Estudiante>();

            // Si algo sale mal, se lo notificaremos al usuario.
            try
            {
                listaEstudiantes = daoEstudiantes.seleccionarEstudiantes();
            }
            catch (MySqlException e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionMySqlException(e));
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }

            return listaEstudiantes;
        }

        public List<Estudiante> seleccionarEstudiantesPorGrupo(Grupo g)
        {
            List<Estudiante> listaEstudiantes = new List<Estudiante>();

            // Si algo sale mal, se lo notificaremos al usuario.
            try
            {
                listaEstudiantes = daoEstudiantes.seleccionarEstudiantesPorGrupo(g);
            }
            catch (MySqlException e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionMySqlException(e));
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }

            return listaEstudiantes;
        }

        // Inserción

        // Modificación

        // Eliminación
    }
}
 