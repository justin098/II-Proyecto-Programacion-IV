using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.CatMan;
using BLL.WSEncomiendaBD;

namespace BLL.CatMan
{
    public class clsSucursalesBLL
    {

        public void Listar(ref clsSucursalesDAL objSucDAL)
        {
            BDServiceClient objWSBD = new BDServiceClient();
            try
            {

                string SSP_Nombre = "sp_Listar_Sucursales_Direccion";
                string SNombreTabla = "Sucursales";
                string error = "";

                objSucDAL.DtTabla = objWSBD.ListarDatos(SSP_Nombre, SNombreTabla, ref error);

                if (error == string.Empty && objSucDAL.DtTabla != null)
                {
                    objSucDAL.Error = string.Empty;
                }
                else
                {
                    objSucDAL.Error = error;
                }
            }
            catch (Exception ex)
            {
                objSucDAL.Error = ex.Message.ToString();
            }
            finally
            {
                objWSBD.Close();
            }
        }

        public void Filtrar(ref clsSucursalesDAL objSucDAL)
        {
            BDServiceClient objWSBD = new BDServiceClient();
            try
            {
                string error = "";


                objSucDAL.DtTabla = objWSBD.FiltarDatos("sp_Listar_Sucursales_Direccion_Filtro", "Sucursales", "@pNombre", "2", objSucDAL.Filtro, ref error);

                if (error == string.Empty && objSucDAL.DtTabla != null)
                {
                    objSucDAL.Error = string.Empty;
                }
                else
                {
                    objSucDAL.Error = error;
                }
            }
            catch (Exception ex)
            {
                objSucDAL.Error = ex.Message.ToString();
            }
            finally
            {
                objWSBD.Close();
            }
        }

    }
}
