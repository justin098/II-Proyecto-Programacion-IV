using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.Cat_Man
{
    public class Cls_Roles_DAL
    {
        private DataTable _dtTabla;
        private string _sError, _sFiltro, _sRol, _sDescripcion;
        private DataTable _dtParametros;
        private int _iId_Rol;
        private char _cAccion;

        public DataTable dtTabla
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

        public string sRol
        {
            get
            {
                return _sRol;
            }

            set
            {
                _sRol = value;
            }
        }

        public string sDescripcion
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

        public int iId_Rol
        {
            get
            {
                return _iId_Rol;
            }

            set
            {
                _iId_Rol = value;
            }
        }

        public char cAccion
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
