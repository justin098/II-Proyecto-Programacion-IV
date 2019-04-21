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
    public class Cls_Tarjetas_BLL
    {

        public void Crear_Parametros(ref Cls_Tarjetas_DAL Obj_Tarjetas_DAL)
        {
            try
            {
                Obj_Tarjetas_DAL.DtParametros = new DataTable("Parametros");
                Obj_Tarjetas_DAL.DtParametros.Columns.Add("Nombre");
                Obj_Tarjetas_DAL.DtParametros.Columns.Add("Tipo");
                Obj_Tarjetas_DAL.DtParametros.Columns.Add("Valor");

                Obj_Tarjetas_DAL.SError = string.Empty;
            }
            catch (Exception Error)
            {
                Obj_Tarjetas_DAL.SError = Error.Message.ToString();
                Obj_Tarjetas_DAL.DtParametros = null;
            }


        }

        public void Filtrar(ref Cls_Tarjetas_DAL Obj_Tarjetas_DAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();
            try
            {
                string error = "";
                Crear_Parametros(ref Obj_Tarjetas_DAL);
                Obj_Tarjetas_DAL.DtParametros.Rows.Add("@Usuario", "2", Obj_Tarjetas_DAL.SPersona);

                Obj_Tarjetas_DAL.DtTablaTarjetas = Obj_BDService.FiltrarDatos("sp_Listar_Tarjetas_Persona", "Sucursales", Obj_Tarjetas_DAL.DtParametros, ref error);

                if (error == string.Empty && Obj_Tarjetas_DAL.DtTablaTarjetas != null)
                {
                    Obj_Tarjetas_DAL.SError = string.Empty;
                }
                else
                {
                    Obj_Tarjetas_DAL.SError = error;
                }
            }
            catch (Exception ex)
            {
                Obj_Tarjetas_DAL.SError = ex.Message.ToString();
            }
            finally
            {
                Obj_BDService.Close();
            }
        }

        public void Listar(ref Cls_Tarjetas_DAL Obj_Tarjetas_DAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();
            try
            {
                string SSP_Nombre = "sp_Listar_Tarjetas_Persona";
                string SNombreTabla = "Tarjetas";
                string error = "";
                string vError = string.Empty;
                Obj_Tarjetas_DAL.DtTablaTarjetas = Obj_BDService.ListarDatos(SSP_Nombre, SNombreTabla, ref error);
                if (error == string.Empty && Obj_Tarjetas_DAL.DtTablaTarjetas != null)
                {
                    Obj_Tarjetas_DAL.SError = string.Empty;
                }
                else
                {
                    Obj_Tarjetas_DAL.SError = error;
                }
            }
            catch (Exception ex)
            {
                Obj_Tarjetas_DAL.SError = ex.Message.ToString();
            }
            finally
            {
                Obj_BDService.Close();
            }
        }

    }
}
