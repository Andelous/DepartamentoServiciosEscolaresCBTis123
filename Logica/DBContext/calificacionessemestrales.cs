//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DBContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class calificacionessemestrales
    {
        // Propiedades mías
        public string nControl
        {
            get
            {
                return estudiantes.ncontrol;
            }
        }


        // Propiedades del modelo
        public int idCalificacionesSemestrales { get; set; }


        private Nullable<double> _calificacionParcial1;
        public Nullable<double> calificacionParcial1
        {
            get
            {
                return _calificacionParcial1;
            }

            set
            {
                if (value.HasValue)
                {
                    if (value > 10)
                    {
                        _calificacionParcial1 = 10;
                    }
                    else if (value < 0)
                    {
                        _calificacionParcial1 = 0;
                    }
                    else
                    {
                        _calificacionParcial1 = value;
                    }
                }
                else
                {
                    _calificacionParcial1 = null;
                }
            }
        }

        private Nullable<double> _calificacionParcial2;
        public Nullable<double> calificacionParcial2
        {
            get
            {
                return _calificacionParcial2;
            }

            set
            {
                if (value.HasValue)
                {
                    if (value > 10)
                    {
                        _calificacionParcial2 = 10;
                    }
                    else if (value < 0)
                    {
                        _calificacionParcial2 = 0;
                    }
                    else
                    {
                        _calificacionParcial2 = value;
                    }
                }
                else
                {
                    _calificacionParcial2 = null;
                }
            }
        }

        private Nullable<double> _calificacionParcial3;
        public Nullable<double> calificacionParcial3
        {
            get
            {
                return _calificacionParcial3;
            }

            set
            {
                if (value.HasValue)
                {
                    if (value > 10)
                    {
                        _calificacionParcial3 = 10;
                    }
                    else if (value < 0)
                    {
                        _calificacionParcial3 = 0;
                    }
                    else
                    {
                        _calificacionParcial3 = value;
                    }
                }
                else
                {
                    _calificacionParcial3 = null;
                }
            }
        }


        private Nullable<int> _asistenciasParcial1;
        public Nullable<int> asistenciasParcial1
        {
            get
            {
                return _asistenciasParcial1;
            }

            set
            {
                if (value.HasValue)
                {
                    if (value < 0)
                    {
                        _asistenciasParcial1 = 0;
                    }
                    else
                    {
                        _asistenciasParcial1 = value;
                    }
                }
                else
                {
                    _asistenciasParcial1 = null;
                }
            }
        }

        private Nullable<int> _asistenciasParcial2;
        public Nullable<int> asistenciasParcial2
        {
            get
            {
                return _asistenciasParcial2;
            }

            set
            {
                if (value.HasValue)
                {
                    if (value < 0)
                    {
                        _asistenciasParcial2 = 0;
                    }
                    else
                    {
                        _asistenciasParcial2 = value;
                    }
                }
                else
                {
                    _asistenciasParcial2 = null;
                }
            }
        }

        private Nullable<int> _asistenciasParcial3;
        public Nullable<int> asistenciasParcial3
        {
            get
            {
                return _asistenciasParcial3;
            }

            set
            {
                if (value.HasValue)
                {
                    if (value < 0)
                    {
                        _asistenciasParcial3 = 0;
                    }
                    else
                    {
                        _asistenciasParcial3 = value;
                    }
                }
                else
                {
                    _asistenciasParcial3 = null;
                }
            }
        }


        public string tipoDeAcreditacion { get; set; }
        public bool recursamiento { get; set; }
        public bool firmado { get; set; }
        public int idEstudiante { get; set; }
        public int idCatedra { get; set; }
    
        public virtual estudiantes estudiantes { get; set; }
        public virtual catedras catedras { get; set; }

        // Propiedades mías
        public double? promedio
        {
            get
            {
                int nulos = 0;

                if (!calificacionParcial1.HasValue)
                    nulos++;

                if (!calificacionParcial2.HasValue)
                    nulos++;

                if (!calificacionParcial3.HasValue)
                    nulos++;

                double total = (calificacionParcial1.HasValue ? calificacionParcial1.Value : 0.0) + (calificacionParcial2.HasValue ? calificacionParcial2.Value : 0.0) + (calificacionParcial3.HasValue ? calificacionParcial3.Value : 0.0);

                if (nulos < 3)
                {
                    return total / (3 - nulos);
                }
                else
                {
                    return null;
                }
            }
        }
        public int? asistenciasTotales
        {
            get
            {
                int nulos = 0;

                if (!asistenciasParcial1.HasValue)
                    nulos++;

                if (!asistenciasParcial2.HasValue)
                    nulos++;

                if (!asistenciasParcial3.HasValue)
                    nulos++;

                if (nulos < 3)
                {
                    return (asistenciasParcial1.HasValue ? asistenciasParcial1.Value : 0) + (asistenciasParcial2.HasValue ? asistenciasParcial2.Value : 0) + (asistenciasParcial3.HasValue ? asistenciasParcial3.Value : 0);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
