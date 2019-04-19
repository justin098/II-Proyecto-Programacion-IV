using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.Cat_Man
{
    public class Cls_Membership_DAL
    {
        private DataTable _dtTablaMembership;
        private string _sUserLogin, _sContrasena, _sPrivilegio, _sError;
        private DataTable _dtParametros;

        public DataTable dtTablMembership
        {
            get
            {
                return _dtTablaMembership;
            }

            set
            {
                _dtTablaMembership = value;
            }
        }

        public string sUserLogin
        {
            get
            {
                return _sUserLogin;
            }

            set
            {
                _sUserLogin = value;
            }
        }

        public string sContrasena
        {
            get
            {
                return _sContrasena;
            }

            set
            {
                _sContrasena = value;
            }
        }

        public string sPrivilegio
        {
            get
            {
                return _sPrivilegio;
            }

            set
            {
                _sPrivilegio = value;
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
    }
}
