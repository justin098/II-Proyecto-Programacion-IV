using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.Cat_Man
{
    public class Cls_Roles_Personas_DAL
    {
        private DataTable _dtTabla;
        private string _sError, _sFiltro, _sCedula;
        private DataTable _dtParametros;
        private int _iRol, _iRolPersona;

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

        public string sCedula
        {
            get
            {
                return _sCedula;
            }

            set
            {
                _sCedula = value;
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

        public int iRolPersona
        {
            get
            {
                return _iRolPersona;
            }

            set
            {
                _iRolPersona = value;
            }
        }
    }
}
