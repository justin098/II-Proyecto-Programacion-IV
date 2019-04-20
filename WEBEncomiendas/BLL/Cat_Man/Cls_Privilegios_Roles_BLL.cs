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
    public class Cls_Privilegios_Roles_BLL
    {
        public void Crear_Parametros(ref Cls_Privilegios_Roles_DAL objDAL)
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

        public void Filtrar(ref Cls_Privilegios_Roles_DAL objDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();
            try
            {
                string error = "";
                Crear_Parametros(ref objDAL);

                objDAL.dtParametros.Rows.Add("@Filtro", "1", objDAL.iFiltro);

                objDAL.dtTabla = Obj_BDService.FiltrarDatos("sp_Filtrar_Privilegios_Roles", "Privilegios_Roles", objDAL.dtParametros, ref error);

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

        public void Insertar(ref Cls_Privilegios_Roles_DAL objDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            char vAccion = 'I';
            Crear_Parametros(ref objDAL);

            objDAL.dtParametros.Rows.Add("@idRol", "1", objDAL.iRol);
            objDAL.dtParametros.Rows.Add("@IdPrivilegio", "1", objDAL.iPrivilegio);

            Obj_BDService.InsertarDatoSinIdentity("sp_Insertar_Privilegio_Rol", "Privilegios_Roles", objDAL.dtParametros, ref vAccion, ref vError);
            objDAL.sError = vError;
        }

        public void Eliminar(ref Cls_Privilegios_Roles_DAL objDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            Crear_Parametros(ref objDAL);
            objDAL.dtParametros.Rows.Add("@idPrivilegioRol", "1", objDAL.iPrivilegioRol);

            Obj_BDService.EliminarDato("sp_Eliminar_Privilegio_Rol", "Privilegios_Roles", objDAL.dtParametros, ref vError);
            objDAL.sError = vError;
        }

    }
}
