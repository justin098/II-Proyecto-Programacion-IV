using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Client_DAL.Cat_Man
{
    public class Cls_Personas_DAL
    {
        private DataTable _dtTablaUsuarios;
        private string _sError, _sFiltro;
        private DataTable _dtParametros;

        public DataTable dtTablaUsuarios
        {
            get
            {
                return _dtTablaUsuarios;
            }

            set
            {
                _dtTablaUsuarios = value;
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
    }
}
