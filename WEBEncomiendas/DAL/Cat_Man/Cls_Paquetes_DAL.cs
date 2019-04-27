using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.Cat_Man
{
    public class Cls_Paquetes_DAL
    {

        private DataTable _dtTablaPaquetes;
        private DataTable _dtParametros;
        private string _sError, _sPersona, _sDescripcion, _sDireccionEntrega, _sNumeroTarjeta, _sIdPaquete;
        private bool _sRetiroDomicilio, _sEntregaDomicilio, _sPagado;
        private int _sIdCategoria, _sIdEstado, _sIdSucursal, _sIdServicio;
        private double _sPeso, _sSubtotal, _sImpuesto, _sEnvio, _sTotal;
        private char _cAccion;

        public DataTable DtTablaPaquetes
        {
            get
            {
                return _dtTablaPaquetes;
            }

            set
            {
                _dtTablaPaquetes = value;
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

        public string SIdPaquete
        {
            get
            {
                return _sIdPaquete;
            }

            set
            {
                _sIdPaquete = value;
            }
        }

        public char CAccion
        {
            get
            {
                return _cAccion;
            }

            set
            {
                _cAccion = value;
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

        public string SNumeroTarjeta
        {
            get
            {
                return _sNumeroTarjeta;
            }

            set
            {
                _sNumeroTarjeta = value;
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

        public string SDescripcion
        {
            get
            {
                return _sDescripcion;
            }

            set
            {
                _sDescripcion = value;
            }
        }
        public string SDireccionEntrega
        {
            get
            {
                return _sDireccionEntrega;
            }

            set
            {
                _sDireccionEntrega = value;
            }
        }

        public bool SRetiroDomicilio
        {
            get
            {
                return _sRetiroDomicilio;
            }

            set
            {
                _sRetiroDomicilio = value;
            }
        }

        public bool SEntregaDomicilio
        {
            get
            {
                return _sEntregaDomicilio;
            }

            set
            {
                _sEntregaDomicilio = value;
            }
        }

        public bool SPagado
        {
            get
            {
                return _sPagado;
            }

            set
            {
                _sPagado = value;
            }
        }

        public int SIdCategoria
        {
            get
            {
                return _sIdCategoria;
            }

            set
            {
                _sIdCategoria = value;
            }
        }


        public int SIdEstado
        {
            get
            {
                return _sIdEstado;
            }

            set
            {
                _sIdEstado = value;
            }
        }


        public int SIdSucursal
        {
            get
            {
                return _sIdSucursal;
            }

            set
            {
                _sIdSucursal = value;
            }
        }


        public int SIdServicio
        {
            get
            {
                return _sIdServicio;
            }

            set
            {
                _sIdServicio = value;
            }
        }

        public double SPeso
        {
            get
            {
                return _sPeso;
            }

            set
            {
                _sPeso = value;
            }
        }


        public double SSubtotal
        {
            get
            {
                return _sSubtotal;
            }

            set
            {
                _sSubtotal = value;
            }
        }


        public double SImpuesto
        {
            get
            {
                return _sImpuesto;
            }

            set
            {
                _sImpuesto = value;
            }
        }


        public double SEnvio
        {
            get
            {
                return _sEnvio;
            }

            set
            {
                _sEnvio = value;
            }
        }

        public double STotal
        {
            get
            {
                return _sTotal;
            }

            set
            {
                _sTotal = value;
            }
        }

    }
}
