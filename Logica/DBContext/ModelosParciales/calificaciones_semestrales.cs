﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DBContext
{
    public partial class calificaciones_semestrales
    {
        // Propiedades mías
        public string nControl
        {
            get
            {
                return estudiantes.ncontrol;
            }
        }

        private static List<string> _tiposDeAcreditacion = new List<string>() { "A", "NA", "NP", "RV", "R" };
        public static List<string> tiposDeAcreditacion
        {
            get
            {
                return _tiposDeAcreditacion;
            }
        }

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

        private string _tipoDeAcreditacion;
        public string tipoDeAcreditacion
        {
            get
            {
                return _tipoDeAcreditacion;
            }
            set
            {
                if (!tiposDeAcreditacion.Contains(value))
                {
                    _tipoDeAcreditacion = null;
                }
                else
                {
                    _tipoDeAcreditacion = value;
                }
            }
        }

        // Propiedades mías
        public double? promedio
        {
            get
            {
                int nulos = 0;
                double total = 0;

                if (!calificacionParcial1.HasValue)
                    nulos++;
                else
                    total += calificacionParcial1.Value;

                if (!calificacionParcial2.HasValue)
                    nulos++;
                else
                    total += calificacionParcial2.Value;

                if (!calificacionParcial3.HasValue)
                    nulos++;
                else
                    total += calificacionParcial3.Value;


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
                int total = 0;

                if (!asistenciasParcial1.HasValue)
                    nulos++;
                else
                    total += asistenciasParcial1.Value;

                if (!asistenciasParcial2.HasValue)
                    nulos++;
                else
                    total += asistenciasParcial2.Value;

                if (!asistenciasParcial3.HasValue)
                    nulos++;
                else
                    total += asistenciasParcial3.Value;

                if (nulos < 3)
                {
                    return total;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
