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
    public class Cls_Roles_BLL
    {
        public void Crear_Parametros(ref Cls_Roles_DAL objDAL)
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

        public void Listar(ref Cls_Roles_DAL objDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();
            try
            {

                string SSP_Nombre = "sp_Listar_Roles";
                string SNombreTabla = "Roles";
                string error = "";

                objDAL.dtTabla = Obj_BDService.ListarDatos(SSP_Nombre, SNombreTabla, ref error);

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

        public void Insertar(ref Cls_Roles_DAL objDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            char vAccion = objDAL.cAccion;
            Crear_Parametros(ref objDAL);

            objDAL.dtParametros.Rows.Add("@Rol", "2", objDAL.sRol);
            objDAL.dtParametros.Rows.Add("@Descripcion", "2", objDAL.sDescripcion);

            Obj_BDService.InsertarDatoSinIdentity("sp_Insertar_Rol", "Roles", objDAL.dtParametros, ref vAccion, ref vError);
            objDAL.sError = vError;
        }

        public void Editar(ref Cls_Roles_DAL objDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            char vAccion = objDAL.cAccion;
            Crear_Parametros(ref objDAL);

            objDAL.dtParametros.Rows.Add("@idRol", "1", objDAL.iId_Rol);
            objDAL.dtParametros.Rows.Add("@Rol", "2", objDAL.sRol);
            objDAL.dtParametros.Rows.Add("@Descripcion", "2", objDAL.sDescripcion);

            Obj_BDService.ModificarDato("sp_Modificar_Rol", "Roles", objDAL.dtParametros, ref vAccion, ref vError);
            objDAL.cAccion = vAccion;
            objDAL.sError = vError;
        }

        public void Eliminar(ref Cls_Roles_DAL objDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            Crear_Parametros(ref objDAL);
            objDAL.dtParametros.Rows.Add("@idRol", "1", objDAL.iId_Rol);

            Obj_BDService.EliminarDato("sp_Eliminar_Rol", "Roles", objDAL.dtParametros, ref vError);
            objDAL.sError = vError;
        }
    }
}
