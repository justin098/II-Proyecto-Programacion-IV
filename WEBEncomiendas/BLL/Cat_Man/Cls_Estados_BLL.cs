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
    public class Cls_Estados_BLL
    {

        public void Crear_Parametros(ref Cls_Estados_DAL Obj_Estados_DAL)
        {
            try
            {
                Obj_Estados_DAL.DtParametros = new DataTable("Parametros");
                Obj_Estados_DAL.DtParametros.Columns.Add("Nombre");
                Obj_Estados_DAL.DtParametros.Columns.Add("Tipo");
                Obj_Estados_DAL.DtParametros.Columns.Add("Valor");

                Obj_Estados_DAL.SError = string.Empty;
            }
            catch (Exception Error)
            {
                Obj_Estados_DAL.SError = Error.Message.ToString();
                Obj_Estados_DAL.DtParametros = null;
            }


        }
        public void Listar(ref Cls_Estados_DAL Obj_Estados_DAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();
            try
            {
                string SSP_Nombre = "sp_Listar_Estados";
                string SNombreTabla = "Estados";
                string error = "";
                string vError = string.Empty;
                Obj_Estados_DAL.DtTablaEstado = Obj_BDService.ListarDatos(SSP_Nombre, SNombreTabla, ref error);
                if (error == string.Empty && Obj_Estados_DAL.DtTablaEstado != null)
                {
                    Obj_Estados_DAL.SError = string.Empty;
                }
                else
                {
                    Obj_Estados_DAL.SError = error;
                }
            }
            catch (Exception ex)
            {
                Obj_Estados_DAL.SError = ex.Message.ToString();
            }
            finally
            {
                Obj_BDService.Close();
            }
        }

    }
}
