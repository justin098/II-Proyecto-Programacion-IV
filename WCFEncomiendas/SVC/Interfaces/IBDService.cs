using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Data;

namespace SVC.Interfaces
{
    [ServiceContract]
    public interface IBDService
    {
        [OperationContract]
        DataTable ListarDatos(string sNombreSP, string sNombreTabla, ref string sMsjError);

        [OperationContract]
        DataTable FiltarDatos(string sNombreSP, string sNombreTabla, string sNombreParametro, 
                              string sTipoParametro, string sValorParametro, ref string sMsjError);
    }
}
