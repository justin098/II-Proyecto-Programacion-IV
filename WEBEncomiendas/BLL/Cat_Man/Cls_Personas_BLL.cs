using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client_DAL.Cat_Man;
using System.Data;
using BLL.WSEncomiendaBD;

namespace Client_BLL.Cat_Man
{
    public class Cls_Personas_BLL
    {
        public void Crear_Parametros(ref Cls_Personas_DAL Obj_Personas_DAL)
        {
            try
            {
                Obj_Personas_DAL.dtParametros = new DataTable("Parametros");
                Obj_Personas_DAL.dtParametros.Columns.Add("Nombre");
                Obj_Personas_DAL.dtParametros.Columns.Add("Tipo");
                Obj_Personas_DAL.dtParametros.Columns.Add("Valor");

                Obj_Personas_DAL.sError = string.Empty;
            }
            catch (Exception Error)
            {
                Obj_Personas_DAL.sError = Error.Message.ToString();
                Obj_Personas_DAL.dtParametros = null;
            }

        }

        public void Listar(ref Cls_Personas_DAL Obj_Personas_DAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;

            Obj_Personas_DAL.dtTablaUsuarios = Obj_BDService.ListarDatos("sp_Listar_Personas", "Personas", ref vError);
            Obj_Personas_DAL.sError = vError;
        }

        public void Filtrar(ref Cls_Personas_DAL Obj_Personas_DAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            Crear_Parametros(ref Obj_Personas_DAL);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Filtro", "2", Obj_Personas_DAL.sFiltro);

            Obj_Personas_DAL.dtTablaUsuarios = Obj_BDService.FiltrarDatos("sp_Filtrar_Personas", "Personas", Obj_Personas_DAL.dtParametros, ref vError);
            Obj_Personas_DAL.sError = vError;
        }
    }
}
