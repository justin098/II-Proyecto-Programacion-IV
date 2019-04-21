using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Cat_Man;
using System.Data;
using BLL.WSEncomiendaBD;

namespace BLL.Cat_Man
{
    public class Cls_Servicios_BLL
    {

        public void Crear_Parametros(ref Cls_Servicios_DAL Obj_Servicios_DAL)
        {
            try
            {
                Obj_Servicios_DAL.DtParametros = new DataTable("Parametros");
                Obj_Servicios_DAL.DtParametros.Columns.Add("Nombre");
                Obj_Servicios_DAL.DtParametros.Columns.Add("Tipo");
                Obj_Servicios_DAL.DtParametros.Columns.Add("Valor");

                Obj_Servicios_DAL.SError = string.Empty;
            }
            catch (Exception Error)
            {
                Obj_Servicios_DAL.SError = Error.Message.ToString();
                Obj_Servicios_DAL.DtParametros = null;
            }


        }
        public void Listar(ref Cls_Servicios_DAL Obj_Servicios_DAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();
            try
            {
                string SSP_Nombre = "sp_Listar_Servicios";
                string SNombreTabla = "Servicios";
                string error = "";
                string vError = string.Empty;
                Obj_Servicios_DAL.DtTablaServicios = Obj_BDService.ListarDatos(SSP_Nombre, SNombreTabla, ref error);
                if (error == string.Empty && Obj_Servicios_DAL.DtTablaServicios != null)
                {
                    Obj_Servicios_DAL.SError = string.Empty;
                }
                else
                {
                    Obj_Servicios_DAL.SError = error;
                }
            }
            catch (Exception ex)
            {
                Obj_Servicios_DAL.SError = ex.Message.ToString();
            }
            finally
            {
                Obj_BDService.Close();
            }
        }

    }
}
