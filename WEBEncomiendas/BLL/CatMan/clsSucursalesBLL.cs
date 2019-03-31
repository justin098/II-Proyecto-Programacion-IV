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
            try
            {
                BDServiceClient objWSBD = new BDServiceClient();


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
        }

    }
}
