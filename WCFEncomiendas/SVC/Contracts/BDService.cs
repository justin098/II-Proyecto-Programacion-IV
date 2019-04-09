using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SVC.Interfaces;
using System.Data;
using BLL.BD;
using DAL.BD;

namespace SVC.Contracts
{
    public class BDService : IBDService
    {
        public DataTable ListarDatos(string sNombreSP, string sNombreTabla, ref string sMsjError)
        {
            try
            {
                Cls_DataBase_BLL OBJ_DataBase_BLL = new Cls_DataBase_BLL();
                Cls_DataBase_DAL OBJ_DataBase_DAL = new Cls_DataBase_DAL();

                OBJ_DataBase_DAL.SSP_Nombre = sNombreSP;
                OBJ_DataBase_DAL.SNombreTabla = sNombreTabla;

                OBJ_DataBase_BLL.Execute_DataAdapter(ref OBJ_DataBase_DAL);

                if (OBJ_DataBase_DAL.SError == string.Empty)
                {
                    sMsjError = string.Empty;
                    return OBJ_DataBase_DAL.OBJ_DataSet.Tables[0];
                }
                else
                {
                    sMsjError = OBJ_DataBase_DAL.SError;
                    return null;
                }

            }
            catch (Exception Error)
            {
                sMsjError = Error.Message.ToString();
                return null;
            }
        }

        public DataTable FiltrarDatos(string sNombreSP, string sNombreTabla, DataTable dtParametros,
                                     ref string sMsjError)
        {
            try
            {
                Cls_DataBase_BLL OBJ_DataBase_BLL = new Cls_DataBase_BLL();
                Cls_DataBase_DAL OBJ_DataBase_DAL = new Cls_DataBase_DAL();

                OBJ_DataBase_DAL.SSP_Nombre = sNombreSP;
                OBJ_DataBase_DAL.SNombreTabla = sNombreTabla;

                OBJ_DataBase_BLL.Crear_Parametros(ref OBJ_DataBase_DAL);
                OBJ_DataBase_DAL.dt_Parametros = dtParametros;

                OBJ_DataBase_BLL.Execute_DataAdapter(ref OBJ_DataBase_DAL);

                if (OBJ_DataBase_DAL.SError == string.Empty)
                {
                    sMsjError = string.Empty;
                    return OBJ_DataBase_DAL.OBJ_DataSet.Tables[0];
                }
                else
                {
                    sMsjError = OBJ_DataBase_DAL.SError;
                    return null;
                }

            }
            catch (Exception Error)
            {
                sMsjError = Error.Message.ToString();
                return null;
            }
        }

        public string InsertarDato(string sNombreSP, string sNombreTabla, DataTable dtParametros,
                                   ref char cAccion, ref string sMsjError)
        {
            try
            {
                Cls_DataBase_BLL OBJ_DataBase_BLL = new Cls_DataBase_BLL();
                Cls_DataBase_DAL OBJ_DataBase_DAL = new Cls_DataBase_DAL();

                OBJ_DataBase_DAL.SSP_Nombre = sNombreSP;
                OBJ_DataBase_DAL.SNombreTabla = sNombreTabla;

                OBJ_DataBase_BLL.Crear_Parametros(ref OBJ_DataBase_DAL);

                OBJ_DataBase_DAL.dt_Parametros = dtParametros;

                OBJ_DataBase_BLL.Execute_Scalar(ref OBJ_DataBase_DAL);

                if (OBJ_DataBase_DAL.SError == string.Empty)
                {
                    sMsjError = string.Empty;
                    cAccion = 'U';
                    return OBJ_DataBase_DAL.SScalarValue;
                }
                else
                {
                    sMsjError = OBJ_DataBase_DAL.SError;
                    cAccion = 'I';
                    return string.Empty;
                }

            }
            catch (Exception Error)
            {
                sMsjError = Error.Message.ToString();
                cAccion = 'I';
                return string.Empty;
            }
        }

        public void ModificarDato(string sNombreSP, string sNombreTabla, DataTable dtParametros,
                                  ref char cAccion, ref string sMsjError)
        {
            try
            {
                Cls_DataBase_BLL OBJ_DataBase_BLL = new Cls_DataBase_BLL();
                Cls_DataBase_DAL OBJ_DataBase_DAL = new Cls_DataBase_DAL();

                OBJ_DataBase_DAL.SSP_Nombre = sNombreSP;
                OBJ_DataBase_DAL.SNombreTabla = sNombreTabla;

                OBJ_DataBase_BLL.Crear_Parametros(ref OBJ_DataBase_DAL);

                OBJ_DataBase_DAL.dt_Parametros = dtParametros;

                OBJ_DataBase_BLL.Execute_NonQuery(ref OBJ_DataBase_DAL);

                if (OBJ_DataBase_DAL.SError == string.Empty)
                {
                    sMsjError = string.Empty;
                }
                else
                {
                    sMsjError = OBJ_DataBase_DAL.SError;
                }
                cAccion = 'U';
            }
            catch (Exception Error)
            {
                cAccion = 'U';
                sMsjError = Error.Message.ToString();
            }
        }

        public void EliminarDato(string sNombreSP, string sNombreTabla, DataTable dtParametros,
                                 ref string sMsjError)
        {
            try
            {
                Cls_DataBase_BLL OBJ_DataBase_BLL = new Cls_DataBase_BLL();
                Cls_DataBase_DAL OBJ_DataBase_DAL = new Cls_DataBase_DAL();

                OBJ_DataBase_DAL.SSP_Nombre = sNombreSP;
                OBJ_DataBase_DAL.SNombreTabla = sNombreTabla;

                OBJ_DataBase_BLL.Crear_Parametros(ref OBJ_DataBase_DAL);
                OBJ_DataBase_DAL.dt_Parametros = dtParametros;

                OBJ_DataBase_BLL.Execute_NonQuery(ref OBJ_DataBase_DAL);

                if (OBJ_DataBase_DAL.SError == string.Empty)
                {
                    sMsjError = string.Empty;
                }
                else
                {
                    sMsjError = OBJ_DataBase_DAL.SError;
                }

            }
            catch (Exception Error)
            {
                sMsjError = Error.Message.ToString();
            }
        }

        public string InsertarDatoSinIdentity(string sNombreSP, string sNombreTabla, DataTable dtParametros,
                                              ref char cAccion, ref string sMsjError)
        {
            try
            {
                Cls_DataBase_BLL OBJ_DataBase_BLL = new Cls_DataBase_BLL();
                Cls_DataBase_DAL OBJ_DataBase_DAL = new Cls_DataBase_DAL();

                OBJ_DataBase_DAL.SSP_Nombre = sNombreSP;
                OBJ_DataBase_DAL.SNombreTabla = sNombreTabla;

                OBJ_DataBase_BLL.Crear_Parametros(ref OBJ_DataBase_DAL);

                OBJ_DataBase_DAL.dt_Parametros = dtParametros;

                OBJ_DataBase_BLL.Execute_NonQuery(ref OBJ_DataBase_DAL);

                if (OBJ_DataBase_DAL.SError == string.Empty)
                {
                    sMsjError = string.Empty;
                    cAccion = 'U';
                    return OBJ_DataBase_DAL.SScalarValue;
                }
                else
                {
                    sMsjError = OBJ_DataBase_DAL.SError;
                    cAccion = 'I';
                    return string.Empty;
                }

            }
            catch (Exception Error)
            {
                sMsjError = Error.Message.ToString();
                cAccion = 'I';
                return string.Empty;
            }
        }
    }
}
