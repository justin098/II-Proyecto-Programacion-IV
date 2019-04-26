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
    public class Cls_Paquetes_BLL
    {

        public void Crear_Parametros(ref Cls_Paquetes_DAL objPaqDAL)
        {
            try
            {
                objPaqDAL.DtParametros = new DataTable("Parametros");
                objPaqDAL.DtParametros.Columns.Add("Nombre");
                objPaqDAL.DtParametros.Columns.Add("Tipo");
                objPaqDAL.DtParametros.Columns.Add("Valor");

                objPaqDAL.SError = string.Empty;
            }
            catch (Exception Error)
            {
                objPaqDAL.SError = Error.Message.ToString();
                objPaqDAL.DtParametros = null;
            }

        }

        public void Insertar(ref Cls_Paquetes_DAL objPaqDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            char vAccion = objPaqDAL.CAccion;
            Crear_Parametros(ref objPaqDAL);

            objPaqDAL.DtParametros.Rows.Add("@Descripcion", "2", objPaqDAL.SDescripcion);
            objPaqDAL.DtParametros.Rows.Add("@Peso", "6", objPaqDAL.SPeso);
            objPaqDAL.DtParametros.Rows.Add("@Id_Categoria", "1", objPaqDAL.SIdCategoria);
            objPaqDAL.DtParametros.Rows.Add("@Id_Estado", "1", objPaqDAL.SIdEstado);
            objPaqDAL.DtParametros.Rows.Add("@Id_Sucursal", "1", objPaqDAL.SIdSucursal);
            objPaqDAL.DtParametros.Rows.Add("@Id_Servicio", "1", objPaqDAL.SIdServicio);
            objPaqDAL.DtParametros.Rows.Add("@Usuario", "2", objPaqDAL.SPersona);
            objPaqDAL.DtParametros.Rows.Add("@Retiro_Domicilio", "8", objPaqDAL.SRetiroDomicilio);
            objPaqDAL.DtParametros.Rows.Add("@Entrega_Domicilio", "8", objPaqDAL.SEntregaDomicilio);
            objPaqDAL.DtParametros.Rows.Add("@Direccion_Entrega", "2", objPaqDAL.SDireccionEntrega);
            objPaqDAL.DtParametros.Rows.Add("@Sub_Total", "6", objPaqDAL.SSubtotal);
            objPaqDAL.DtParametros.Rows.Add("@Impuesto", "6", objPaqDAL.SImpuesto);
            objPaqDAL.DtParametros.Rows.Add("@Envio", "6", objPaqDAL.SEnvio);
            objPaqDAL.DtParametros.Rows.Add("@Total", "6", objPaqDAL.STotal);
            objPaqDAL.DtParametros.Rows.Add("@Pagado", "8", objPaqDAL.SPagado);
            objPaqDAL.DtParametros.Rows.Add("@Numero_tarjeta", "2", objPaqDAL.SNumeroTarjeta);

            Obj_BDService.InsertarDatoSinIdentity("sp_Insertar_Paquete", "Sucursales", objPaqDAL.DtParametros, ref vAccion, ref vError);
            objPaqDAL.CAccion = vAccion;
            objPaqDAL.SError = vError;
        }

        public void Listar(ref Cls_Paquetes_DAL objPaqDAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();
            try
            {

                string SSP_Nombre = "sp_Listar_Paquetes_Factura";
                string SNombreTabla = "Paquetes";
                string error = "";

                objPaqDAL.DtTablaPaquetes = Obj_BDService.ListarDatos(SSP_Nombre, SNombreTabla, ref error);

                if (error == string.Empty && objPaqDAL.DtTablaPaquetes != null)
                {
                    objPaqDAL.SError = string.Empty;
                }
                else
                {
                    objPaqDAL.SError = error;
                }
            }
            catch (Exception ex)
            {
                objPaqDAL.SError = ex.Message.ToString();
            }
            finally
            {
                Obj_BDService.Close();
            }
        }


    }
}
