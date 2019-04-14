using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.Cat_Man
{
    public class Cls_Sucursales_DAL
    {

        private DataTable _dtTabla;
        private string _sError, _sFiltro, _sNombre, _sProvincia, _sCanton, _sDistrito, _sDireccionExacta;
        private DataTable _dtParametros;
        private int _sId_Sucursal, _sId_Direccion;
        private bool _sActivo;
        private char _cAccion;
        public DataTable DtTabla
        {
            get
            {
                return _dtTabla;
            }

            set
            {
                _dtTabla = value;
            }
        }

        public string sError
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

        public string sFiltro
        {
            get
            {
                return _sFiltro;
            }

            set
            {
                _sFiltro = value;
            }
        }

        public DataTable dtParametros
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






        public string SNombre
        {
            get
            {
                return _sNombre;
            }

            set
            {
                _sNombre = value;
            }
        }

        public string SCanton
        {
            get
            {
                return _sCanton;
            }

            set
            {
                _sCanton = value;
            }
        }

        public string SDistrito
        {
            get
            {
                return _sDistrito;
            }

            set
            {
                _sDistrito = value;
            }
        }

        public string SDireccionExacta
        {
            get
            {
                return _sDireccionExacta;
            }

            set
            {
                _sDireccionExacta = value;
            }
        }

        public int SId_Sucursal
        {
            get
            {
                return _sId_Sucursal;
            }

            set
            {
                _sId_Sucursal = value;
            }
        }

        public int SId_Direccion
        {
            get
            {
                return _sId_Direccion;
            }

            set
            {
                _sId_Direccion = value;
            }
        }

        public bool SActivo
        {
            get
            {
                return _sActivo;
            }

            set
            {
                _sActivo = value;
            }
        }

        public string SProvincia
        {
            get
            {
                return _sProvincia;
            }

            set
            {
                _sProvincia = value;
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
    }
}
