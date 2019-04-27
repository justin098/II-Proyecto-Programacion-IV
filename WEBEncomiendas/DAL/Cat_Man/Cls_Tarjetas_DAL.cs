using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.Cat_Man
{
    public class Cls_Tarjetas_DAL
    {
        private DataTable _dtTablaTarjetas;
        private DataTable _dtParametros;
        private string _sError, _sPersona, _sNumerotarjeta, _sFechaVencimiento, _scodigoSeguridad;

        public DataTable DtTablaTarjetas
        {
            get
            {
                return _dtTablaTarjetas;
            }

            set
            {
                _dtTablaTarjetas = value;
            }
        }

        public DataTable DtParametros
        {
            get
            {
                return _dtParametros;
            }

            set
            {
                _dtParametros = value;
            }
        }

        public string SError
        {
            get
            {
                return _sError;
            }

            set
            {
                _sError = value;
            }
        }

        public string SPersona
        {
            get
            {
                return _sPersona;
            }

            set
            {
                _sPersona = value;
            }
        }

        public string SNumerotarjeta
        {
            get
            {
                return _sNumerotarjeta;
            }

            set
            {
                _sNumerotarjeta = value;
            }
        }

        public string SFechaVencimiento
        {
            get
            {
                return _sFechaVencimiento;
            }

            set
            {
                _sFechaVencimiento = value;
            }
        }

        public string ScodigoSeguridad
        {
            get
            {
                return _scodigoSeguridad;
            }

            set
            {
                _scodigoSeguridad = value;
            }
        }
    }
}
