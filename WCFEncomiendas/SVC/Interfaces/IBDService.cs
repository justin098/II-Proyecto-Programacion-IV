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
        DataTable FiltrarDatos(string sNombreSP, string sNombreTabla, DataTable dtParametros, 
                              ref string sMsjError);

        [OperationContract]
        string InsertarDato(string sNombreSP, string sNombreTabla, DataTable dtParametros,
                            ref char cAccion, ref string sMsjError);

        [OperationContract]
        void ModificarDato(string sNombreSP, string sNombreTabla, DataTable dtParametros,
                           ref char cAccion, ref string sMsjError);

        [OperationContract]
        void EliminarDato(string sNombreSP, string sNombreTabla, DataTable dtParametros,
                          ref string sMsjError);

        [OperationContract]
        string InsertarDatoSinIdentity(string sNombreSP, string sNombreTabla, DataTable dtParametros,
                            ref char cAccion, ref string sMsjError);
    }
}
