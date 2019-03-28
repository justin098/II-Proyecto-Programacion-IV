using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL.BD
{
    public class Cls_DataBase_DAL
    {
        public DataTable dt_Parametros = new DataTable("Paramentros");
        public SqlConnection OBJ_Connection_DataBase = new SqlConnection();
        public SqlDataAdapter OBJ_DataAdapter = new SqlDataAdapter();
        public DataSet OBJ_DataSet = new DataSet();
        public SqlCommand OBJ_Command;

        private string _sCxCadena, _sNombreTabla, _sSP_Nombre, _sScalarValue, _sError;

        public string SCxCadena
        {
            get
            {
                return _sCxCadena;
            }

            set
            {
                _sCxCadena = value;
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

        public string SNombreTabla
        {
            get
            {
                return _sNombreTabla;
            }

            set
            {
                _sNombreTabla = value;
            }
        }

        public string SScalarValue
        {
            get
            {
                return _sScalarValue;
            }

            set
            {
                _sScalarValue = value;
            }
        }

        public string SSP_Nombre
        {
            get
            {
                return _sSP_Nombre;
            }

            set
            {
                _sSP_Nombre = value;
            }
        }
    }
}
