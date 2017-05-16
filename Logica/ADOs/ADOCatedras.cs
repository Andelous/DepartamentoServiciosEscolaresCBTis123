using DepartamentoServiciosEscolaresCBTis123.Logica.DBContext;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.ADOs
{
    public class ADOCatedras : ADO
    {
        // SELECTS
        public List<catedras> seleccionarCatedrasPorGrupo(grupos g)
        {
            return dataContext.catedras.Where(c => c.grupos.idGrupo == g.idGrupo).ToList();
        }

        public List<catedras> seleccionarCatedrasPorDocente(docentes d)
        {
            return dataContext.catedras.Where(c => c.docentes.idDocente == d.idDocente).ToList();
        }

        // INSERTS
        public int insertarCatedra(catedras c)
        {
            dataContext.catedras.Add(c);

            return dataContext.SaveChanges();
        }


        // UPDATES
        public int modificarCatedra(catedras c)
        {
            dataContext.catedras.Attach(c);

            DbEntityEntry<catedras> cambios = dataContext.Entry(c);

            cambios.Property(ca => ca.idDocente).IsModified = true;
            cambios.Property(ca => ca.idMateria).IsModified = true;
            cambios.Property(ca => ca.idGrupo).IsModified = true;

            return dataContext.SaveChanges();
        }

        // MISC
        public static catedras crearCatedra(
            int idCatedra,
            int idDocente,
            int idMateria,
            int idGrupo
        ) {
            catedras c = new catedras();
            
            c.idCatedra = idCatedra;
            c.idDocente = idDocente;
            c.idGrupo = idGrupo;
            c.idMateria = idMateria;

            return c;
        }
    }
}
