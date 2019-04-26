using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.Cat_Man;
using BLL.WSEncomiendaBD;

namespace BLL.Cat_Man
{
    public class Cls_Roles_Personas_BLL
    {
        public void Crear_Parametros(ref Cls_Roles_Personas_DAL objDAL)
        {
            try
            {
                objDAL.dtParametros = new DataTable("Parametros");
                objDAL.dtParametros.Columns.Add("Nombre");
                objDAL.dtParametros.Columns.Add("Tipo");
                objDAL.dtParametros.Columns.Add("Valor");

                objDAL.sError = string.Empty;
            }
            catch (Exception Error)
            {
                objDAL.sError = Error.Message.ToString();
                objDAL.dtParametros = null;
            }
        }

        public void Filtrar(ref Cls_Roles_Personas_DAL objDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();
            try
            {
                string error = "";
                Crear_Parametros(ref objDAL);

                objDAL.dtParametros.Rows.Add("@Filtro", "2", objDAL.sFiltro);

                objDAL.dtTabla = Obj_BDService.FiltrarDatos("sp_Filtrar_Roles_Personas", "Roles_Personas", objDAL.dtParametros, ref error);

                if (error == string.Empty && objDAL.dtTabla != null)
                {
                    objDAL.sError = string.Empty;
                }
                else
                {
                    objDAL.sError = error;
                }
            }
            catch (Exception ex)
            {
                objDAL.sError = ex.Message.ToString();
            }
            finally
            {
                Obj_BDService.Close();
            }
        }

        public void Insertar(ref Cls_Roles_Personas_DAL objDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            char vAccion = 'I';
            Crear_Parametros(ref objDAL);

            objDAL.dtParametros.Rows.Add("@idRol", "1", objDAL.iRol);
            objDAL.dtParametros.Rows.Add("@cedula", "2", objDAL.sCedula);

            Obj_BDService.InsertarDatoSinIdentity("sp_Insertar_Rol_Persona", "Roles_Personas", objDAL.dtParametros, ref vAccion, ref vError);
            objDAL.sError = vError;
        }

        public void Eliminar(ref Cls_Roles_Personas_DAL objDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            Crear_Parametros(ref objDAL);
            objDAL.dtParametros.Rows.Add("@idRolPersona", "1", objDAL.iRolPersona);

            Obj_BDService.EliminarDato("sp_Eliminar_Rol_Persona", "Roles_Personas", objDAL.dtParametros, ref vError);
            objDAL.sError = vError;
        }
    }
}
