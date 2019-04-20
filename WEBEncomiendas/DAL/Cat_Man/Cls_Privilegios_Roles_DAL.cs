using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.Cat_Man
{
    public class Cls_Privilegios_Roles_DAL
    {
        private DataTable _dtTabla;
        private string _sError;
        private DataTable _dtParametros;
        private int _iPrivilegio, _iRol, _iFiltro, _iPrivilegioRol;

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

        public int iPrivilegio
        {
            get
            {
                return _iPrivilegio;
            }

            set
            {
                _iPrivilegio = value;
            }
        }

        public int iRol
        {
            get
            {
                return _iRol;
            }

            set
            {
                _iRol = value;
            }
        }

        public int iFiltro
        {
            get
            {
                return _iFiltro;
            }

            set
            {
                _iFiltro = value;
            }
        }

        public int iPrivilegioRol
        {
            get
            {
                return _iPrivilegioRol;
            }

            set
            {
                _iPrivilegioRol = value;
            }
        }
    }
}
