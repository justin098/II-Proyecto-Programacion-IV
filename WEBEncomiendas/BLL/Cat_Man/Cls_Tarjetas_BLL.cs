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

                Obj_Tarjetas_DAL.DtTablaTarjetas = Obj_BDService.FiltrarDatos("sp_Listar_Tarjetas_Persona", "Tarjetas", Obj_Tarjetas_DAL.DtParametros, ref error);

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

        public void Insertar(ref Cls_Tarjetas_DAL Obj_Tarjetas_DAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            char vAccion = 'I';
            Crear_Parametros(ref Obj_Tarjetas_DAL);

            Obj_Tarjetas_DAL.DtParametros.Rows.Add("@NumeroTarjeta", "2", Obj_Tarjetas_DAL.SNumerotarjeta);
            Obj_Tarjetas_DAL.DtParametros.Rows.Add("@FechaVencimiento", "7", Convert.ToDateTime(Obj_Tarjetas_DAL.SFechaVencimiento));
            Obj_Tarjetas_DAL.DtParametros.Rows.Add("@CodigoSeguridad", "2", Obj_Tarjetas_DAL.ScodigoSeguridad);
            Obj_Tarjetas_DAL.DtParametros.Rows.Add("@Usuario", "2", Obj_Tarjetas_DAL.SPersona);

            Obj_BDService.InsertarDatoSinIdentity("sp_Insertar_Tarjeta_Persona", "Tarjetas", Obj_Tarjetas_DAL.DtParametros, ref vAccion, ref vError);
            Obj_Tarjetas_DAL.SError = vError;
        }

        public void Editar(ref Cls_Tarjetas_DAL Obj_Tarjetas_DAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            char vAccion = 'U';
            Crear_Parametros(ref Obj_Tarjetas_DAL);
            Obj_Tarjetas_DAL.DtParametros.Rows.Add("@NumeroTarjeta", "2", Obj_Tarjetas_DAL.SNumerotarjeta);
            Obj_Tarjetas_DAL.DtParametros.Rows.Add("@FechaVencimiento", "7", Convert.ToDateTime(Obj_Tarjetas_DAL.SFechaVencimiento));
            Obj_Tarjetas_DAL.DtParametros.Rows.Add("@CodigoSeguridad", "2", Obj_Tarjetas_DAL.ScodigoSeguridad);
            Obj_Tarjetas_DAL.DtParametros.Rows.Add("@Usuario", "2", Obj_Tarjetas_DAL.SPersona);
            Obj_BDService.ModificarDato("sp_Modificar_Tarjeta_Persona", "tarjetas", Obj_Tarjetas_DAL.DtParametros, ref vAccion, ref vError);
            Obj_Tarjetas_DAL.SError = vError;
        }

        public void Eliminar(ref Cls_Tarjetas_DAL Obj_Tarjetas_DAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            Crear_Parametros(ref Obj_Tarjetas_DAL);
            Obj_Tarjetas_DAL.DtParametros.Rows.Add("@NumeroTarjeta", "2", Obj_Tarjetas_DAL.SNumerotarjeta);
            Obj_Tarjetas_DAL.DtParametros.Rows.Add("@Usuario", "2", Obj_Tarjetas_DAL.SPersona);

            Obj_BDService.EliminarDato("sp_Eliminar_Tarjeta_Persona", "Tarjetas", Obj_Tarjetas_DAL.DtParametros, ref vError);
            Obj_Tarjetas_DAL.SError = vError;
        }

    }
}
