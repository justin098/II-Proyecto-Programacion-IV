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
        private DataTable _dtParametros;
        private string _sError, _sFiltro, _sCedula, _sNombre, _sPrimerApellido, _sSegundoApellido, 
                       _sEmail, _sTelefono1, _sTelefono2 , _sUsuario, _sContrasenia, _sSuperUsuario, 
                       _sActivo, _sProvincia, _sCanton, _sDistrito, _sDireccionExacta;
        private char _cAccion;

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

        public string sNombre
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

        public string sPrimerApellido
        {
            get
            {
                return _sPrimerApellido;
            }

            set
            {
                _sPrimerApellido = value;
            }
        }

        public string sSegundoApellido
        {
            get
            {
                return _sSegundoApellido;
            }

            set
            {
                _sSegundoApellido = value;
            }
        }

        public string sEmail
        {
            get
            {
                return _sEmail;
            }

            set
            {
                _sEmail = value;
            }
        }

        public string sTelefono1
        {
            get
            {
                return _sTelefono1;
            }

            set
            {
                _sTelefono1 = value;
            }
        }

        public string sTelefono2
        {
            get
            {
                return _sTelefono2;
            }

            set
            {
                _sTelefono2 = value;
            }
        }

        public string sUsuario
        {
            get
            {
                return _sUsuario;
            }

            set
            {
                _sUsuario = value;
            }
        }

        public string sContrasenia
        {
            get
            {
                return _sContrasenia;
            }

            set
            {
                _sContrasenia = value;
            }
        }

        public string sSuperUsuario
        {
            get
            {
                return _sSuperUsuario;
            }

            set
            {
                _sSuperUsuario = value;
            }
        }

        public string sActivo
        {
            get
            {
                return _sActivo;
            }

            set
            {
                _sActivo = value;
            }
        }

        public string sProvincia
        {
            get
            {
                return _sProvincia;
            }

            set
            {
                _sProvincia = value;
            }
        }

        public string sCanton
        {
            get
            {
                return _sCanton;
            }

            set
            {
                _sCanton = value;
            }
        }

        public string sDistrito
        {
            get
            {
                return _sDistrito;
            }

            set
            {
                _sDistrito = value;
            }
        }

        public string sDireccionExacta
        {
            get
            {
                return _sDireccionExacta;
            }

            set
            {
                _sDireccionExacta = value;
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
