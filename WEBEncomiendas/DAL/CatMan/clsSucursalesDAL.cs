﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.CatMan
{
    public class clsSucursalesDAL
    {

        private DataTable _dtTabla;
        private string _Error,_Filtro;

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

        public string Error
        {
            get
            {
                return _Error;
            }

            set
            {
                _Error = value;
            }
        }

        public string Filtro
        {
            get
            {
                return _Filtro;
            }

            set
            {
                _Filtro = value;
            }
        }
    }
}