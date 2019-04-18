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
    public class Cls_Categoria_BLL
    {
        public void Crear_Parametros(ref Cls_Categoria_DAL Obj_Categoria_DAL)
        {
            try
            {
                Obj_Categoria_DAL.DtParametros = new DataTable("Parametros");
                Obj_Categoria_DAL.DtParametros.Columns.Add("Nombre");
                Obj_Categoria_DAL.DtParametros.Columns.Add("Tipo");
                Obj_Categoria_DAL.DtParametros.Columns.Add("Valor");

                Obj_Categoria_DAL.SError = string.Empty;
            }
            catch (Exception Error)
            {
                Obj_Categoria_DAL.SError = Error.Message.ToString();
                Obj_Categoria_DAL.DtParametros = null;
            }


        }
        public void Listar(ref Cls_Categoria_DAL Obj_Categoria_DAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();
            try
            {
                string SSP_Nombre = "sp_Listar_Categorias";
                string SNombreTabla = "Categorias";
                string error = "";
                string vError = string.Empty;
                Obj_Categoria_DAL.DtTablaCategoria = Obj_BDService.ListarDatos(SSP_Nombre, SNombreTabla, ref error);
                if (error == string.Empty && Obj_Categoria_DAL.DtTablaCategoria != null)
                {
                    Obj_Categoria_DAL.SError = string.Empty;
                }
                else
                {
                    Obj_Categoria_DAL.SError = error;
                }
            }
            catch (Exception ex)
            {
                Obj_Categoria_DAL.SError = ex.Message.ToString();
            }
            finally
            {
                Obj_BDService.Close();
            }
        }

        public void Filtrar(ref Cls_Categoria_DAL Obj_Categoria_DAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();
            try
            {
                string vError = "";
                Crear_Parametros(ref Obj_Categoria_DAL);
                Obj_Categoria_DAL.DtParametros.Rows.Add("@Nombre", "2", Obj_Categoria_DAL.SFiltro);

                Obj_Categoria_DAL.DtTablaCategoria = Obj_BDService.FiltrarDatos("sp_Filtrar_Categorias", "Categorias", Obj_Categoria_DAL.DtParametros, ref vError);
                Obj_Categoria_DAL.SError = vError;
                if (vError == string.Empty && Obj_Categoria_DAL.DtTablaCategoria != null)
                {
                    Obj_Categoria_DAL.SError = string.Empty;
                }
                else
                {
                    Obj_Categoria_DAL.SError = vError;
                }
            }
            catch (Exception ex)
            {

                Obj_Categoria_DAL.SError = ex.Message.ToString();
            }
            finally
            {
                Obj_BDService.Close();
            }


        }
        public void Eliminar(ref Cls_Categoria_DAL Obj_Categoria_DAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            Crear_Parametros(ref Obj_Categoria_DAL);
            Obj_Categoria_DAL.DtParametros.Rows.Add("@Id_Categoria", "1", Obj_Categoria_DAL.SIdcategoria);
            Obj_BDService.EliminarDato("sp_Eliminar_Categoria", "Categorias", Obj_Categoria_DAL.DtParametros, ref vError);
            Obj_Categoria_DAL.SError = vError;
        }

        public void Insertar(ref Cls_Categoria_DAL Obj_Categoria_DAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            char vAccion = Obj_Categoria_DAL.CAccion;
            Crear_Parametros(ref Obj_Categoria_DAL);


            Obj_Categoria_DAL.DtParametros.Rows.Add("@Nombre", "2", Obj_Categoria_DAL.SNombre);
            Obj_Categoria_DAL.DtParametros.Rows.Add("@Arancel", "6", Obj_Categoria_DAL.SArancel);
            Obj_BDService.InsertarDatoSinIdentity("sp_Insertar_Categoria", "Categorias", Obj_Categoria_DAL.DtParametros, ref vAccion, ref vError);
            Obj_Categoria_DAL.CAccion = vAccion;
            Obj_Categoria_DAL.SError = vError;
        }
        public void Editar(ref Cls_Categoria_DAL Obj_Categoria_DAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            char vAccion = Obj_Categoria_DAL.CAccion;
            Crear_Parametros(ref Obj_Categoria_DAL);

            Obj_Categoria_DAL.DtParametros.Rows.Add("@Id_Categoria", "1", Obj_Categoria_DAL.SIdcategoria);
            Obj_Categoria_DAL.DtParametros.Rows.Add("@Nombre", "2", Obj_Categoria_DAL.SNombre);
            Obj_Categoria_DAL.DtParametros.Rows.Add("@Arancel", "6", Obj_Categoria_DAL.SArancel);
            Obj_BDService.ModificarDato("sp_Modificar_Categoria", "Categorias", Obj_Categoria_DAL.DtParametros, ref vAccion, ref vError);
            Obj_Categoria_DAL.CAccion = vAccion;
            Obj_Categoria_DAL.SError = vError;
        }
    }
}
