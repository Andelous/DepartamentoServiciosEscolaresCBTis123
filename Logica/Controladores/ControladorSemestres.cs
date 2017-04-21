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
    public class ControladorSemestres
    {
        private DAOSemestres daoSemestres { get; set; }
        private DAOGrupos daoGrupos { get; set; }

        public ControladorSemestres()
        {
            daoSemestres = new DAOSemestres();
            daoGrupos = new DAOGrupos();
        }

        public List<Semestre> seleccionarSemestres()
        {
            List<Semestre> listaSemestres = new List<Semestre>();

            try
            { listaSemestres = daoSemestres.seleccionarSemestres(); }
            catch (MySqlException e)
            { throw; }

            return listaSemestres;
        }

        public ResultadoOperacion registrarSemestre(
            string nombre, 
            string nombreCorto, 
            string nombreCorto2, 
            string nombreCorto3
        ) {
            Semestre s = 
                daoSemestres.
                crearSemestre(
                    -1,
                    nombre,
                    nombreCorto,
                    nombreCorto2,
                    nombreCorto3
                );

            int registrado = daoSemestres.registrarSemestre(s);

            return registrado == 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.Correcto,
                    "Semestre registrado")
                :
                new ResultadoOperacion(
                    EstadoOperacion.NingunResultado,
                    "Semestre no registrado");
        }

        public ResultadoOperacion modificarSemestre(
            int idSemestre, 
            string nombre, 
            string nombreCorto, 
            string nombreCorto2, 
            string nombreCorto3
        ) {
            Semestre s =
                daoSemestres.
                crearSemestre(
                    idSemestre,
                    nombre,
                    nombreCorto,
                    nombreCorto2,
                    nombreCorto3
                );

            int modificado = 0;

            try
            { daoSemestres.modificarSemestre(s); }
            catch (MySqlException)
            { throw; }
            catch (Exception)
            { throw; }

            return modificado == 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.Correcto,
                    "Semestre modificado")
                :
                new ResultadoOperacion(
                    EstadoOperacion.NingunResultado,
                    "Semestre no modificado");
        }

        public ResultadoOperacion eliminarSemestre(Semestre s)
        {
            int eliminado = 0;

            try
            { eliminado = daoSemestres.eliminarSemestre(s); }
            catch (MySqlException)
            { throw; }
            catch (Exception)
            { throw; }

            return eliminado == 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.Correcto,
                    "Semestre eliminado")
                :
                new ResultadoOperacion(
                    EstadoOperacion.NingunResultado,
                    "Semestre no eliminado");
        }
    }
}
