using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.Cat_Man
{
    public class Cls_Categoria_DAL
    {

        private DataTable _dtTablaCategoria;
        private DataTable _dtParametros;
        private string _sError, _sFiltro, _sNombre;
        private int _sIdcategoria;
        private decimal _sArancel;
        private char _cAccion;

        public DataTable DtTablaCategoria
        {
            get
            {
                return _dtTablaCategoria;
            }

            set
            {
                _dtTablaCategoria = value;
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

        public string SFiltro
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

        public int SIdcategoria
        {
            get
            {
                return _sIdcategoria;
            }

            set
            {
                _sIdcategoria = value;
            }
        }

        public decimal SArancel
        {
            get
            {
                return _sArancel;
            }

            set
            {
                _sArancel = value;
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
