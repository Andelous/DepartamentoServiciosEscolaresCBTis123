using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
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
            return daoSemestres.seleccionarSemestres();
        }

        public ResultadoOperacion registrarSemestre(string nombre, string nombreCorto, string nombreCorto2, string nombreCorto3)
        {
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

            return registrado == 1 ? ResultadoOperacion.RegistroCorrecto : ResultadoOperacion.ErrorAlRegistrar;
        }

        public ResultadoOperacion modificarSemestre(int idSemestre, string nombre, string nombreCorto, string nombreCorto2, string nombreCorto3)
        {
            Semestre s =
                daoSemestres.
                crearSemestre(
                    idSemestre,
                    nombre,
                    nombreCorto,
                    nombreCorto2,
                    nombreCorto3
                );

            int modificado = daoSemestres.modificarSemestre(s);

            return modificado == 1 ? ResultadoOperacion.ModificacionCorrecta : ResultadoOperacion.ErrorAlModificar;
        }

        public ResultadoOperacion eliminarSemestre(Semestre s)
        {
            int eliminado = daoSemestres.eliminarSemestre(s);
            return eliminado == 1 ? ResultadoOperacion.EliminacionCorrecta : ResultadoOperacion.ErrorAlEliminar;
        }
    }
}
