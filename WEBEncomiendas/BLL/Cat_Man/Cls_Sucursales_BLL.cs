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
    public class Cls_Sucursales_BLL
    {
        public void Crear_Parametros(ref Cls_Sucursales_DAL objSucDAL)
        {
            try
            {
                objSucDAL.dtParametros = new DataTable("Parametros");
                objSucDAL.dtParametros.Columns.Add("Nombre");
                objSucDAL.dtParametros.Columns.Add("Tipo");
                objSucDAL.dtParametros.Columns.Add("Valor");

                objSucDAL.sError = string.Empty;
            }
            catch (Exception Error)
            {
                objSucDAL.sError = Error.Message.ToString();
                objSucDAL.dtParametros = null;
            }

        }

        public void Listar(ref Cls_Sucursales_DAL objSucDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();
            try
            {

                string SSP_Nombre = "sp_Listar_Sucursales_Direccion";
                string SNombreTabla = "Sucursales";
                string error = "";

                objSucDAL.DtTabla = Obj_BDService.ListarDatos(SSP_Nombre, SNombreTabla, ref error);

                if (error == string.Empty && objSucDAL.DtTabla != null)
                {
                    objSucDAL.sError = string.Empty;
                }
                else
                {
                    objSucDAL.sError = error;
                }
            }
            catch (Exception ex)
            {
                objSucDAL.sError = ex.Message.ToString();
            }
            finally
            {
                Obj_BDService.Close();
            }
        }

        public void Filtrar(ref Cls_Sucursales_DAL objSucDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();
            try
            {
                string error = "";
                Crear_Parametros(ref objSucDAL);
                objSucDAL.dtParametros.Rows.Add("@pNombre", "2", objSucDAL.sFiltro);

                objSucDAL.DtTabla = Obj_BDService.FiltrarDatos("sp_Listar_Sucursales_Direccion_Filtro", "Sucursales", objSucDAL.dtParametros, ref error);

                if (error == string.Empty && objSucDAL.DtTabla != null)
                {
                    objSucDAL.sError = string.Empty;
                }
                else
                {
                    objSucDAL.sError = error;
                }
            }
            catch (Exception ex)
            {
                objSucDAL.sError = ex.Message.ToString();
            }
            finally
            {
                Obj_BDService.Close();
            }
        }

    }
}
