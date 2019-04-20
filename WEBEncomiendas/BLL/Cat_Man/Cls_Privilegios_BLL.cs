using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Cat_Man;
using BLL.WSEncomiendaBD;

namespace BLL.Cat_Man
{
    public class Cls_Privilegios_BLL
    {
        public void Listar(ref Cls_Privilegios_DAL objDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();
            try
            {

                string SSP_Nombre = "sp_Listar_Privilegios";
                string SNombreTabla = "Privilegios";
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
    }
}
