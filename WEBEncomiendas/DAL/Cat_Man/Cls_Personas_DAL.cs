using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.Cat_Man
{
    public class Cls_Personas_DAL
    {
        private DataTable _dtTablaPersonas;
        private string _sError, _sFiltro;
        private DataTable _dtParametros;

        public DataTable dtTablaPersonas
        {
            get
            {
                return _dtTablaPersonas;
            }

            set
            {
                _dtTablaPersonas = value;
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
