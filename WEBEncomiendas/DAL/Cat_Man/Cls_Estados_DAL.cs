using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.Cat_Man
{
    public class Cls_Estados_DAL
    {

        private DataTable _dtTablaEstado;
        private DataTable _dtParametros;
        private string _sError;



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

        public DataTable DtTablaEstado
        {
            get
            {
                return _dtTablaEstado;
            }

            set
            {
                _dtTablaEstado = value;
            }
        }
    }
}
