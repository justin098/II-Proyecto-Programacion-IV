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

        public void Insertar(ref Cls_Sucursales_DAL objSucDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            char vAccion = objSucDAL.CAccion;
            Crear_Parametros(ref objSucDAL);

            objSucDAL.dtParametros.Rows.Add("@Nombre", "2", objSucDAL.SNombre);
            objSucDAL.dtParametros.Rows.Add("@Activo", "8", objSucDAL.SActivo);
            objSucDAL.dtParametros.Rows.Add("@Provincia", "2", objSucDAL.SProvincia);
            objSucDAL.dtParametros.Rows.Add("@Canton", "2", objSucDAL.SCanton);
            objSucDAL.dtParametros.Rows.Add("@Distrito", "2", objSucDAL.SDistrito);
            objSucDAL.dtParametros.Rows.Add("@Direccion_Exacta", "2", objSucDAL.SDireccionExacta);

            Obj_BDService.InsertarDatoSinIdentity("sp_Insertar_Sucursal", "Sucursales", objSucDAL.dtParametros, ref vAccion, ref vError);
            objSucDAL.CAccion = vAccion;
            objSucDAL.sError = vError;
        }
        public void Editar(ref Cls_Sucursales_DAL objSucDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            char vAccion = objSucDAL.CAccion;
            Crear_Parametros(ref objSucDAL);
            objSucDAL.dtParametros.Rows.Add("@Id_Sucursal", "1", objSucDAL.SId_Sucursal);
            objSucDAL.dtParametros.Rows.Add("@Nombre", "2", objSucDAL.SNombre);
            objSucDAL.dtParametros.Rows.Add("@Activo", "8", objSucDAL.SActivo);
            objSucDAL.dtParametros.Rows.Add("@Provincia", "2", objSucDAL.SProvincia);
            objSucDAL.dtParametros.Rows.Add("@Canton", "2", objSucDAL.SCanton);
            objSucDAL.dtParametros.Rows.Add("@Distrito", "2", objSucDAL.SDistrito);
            objSucDAL.dtParametros.Rows.Add("@Direccion_Exacta", "2", objSucDAL.SDireccionExacta);
            Obj_BDService.ModificarDato("sp_Modificar_Sucursal", "Sucursal", objSucDAL.dtParametros, ref vAccion, ref vError);
            objSucDAL.CAccion = vAccion;
            objSucDAL.sError = vError;
        }


        public void Eliminar(ref Cls_Sucursales_DAL objSucDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            Crear_Parametros(ref objSucDAL);
            objSucDAL.dtParametros.Rows.Add("@Id_Sucursal", "1", objSucDAL.SId_Sucursal);

            Obj_BDService.EliminarDato("sp_Eliminar_Sucursal", "Sucursales", objSucDAL.dtParametros, ref vError);
            objSucDAL.sError = vError;
        }

    }
}
