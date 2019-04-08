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

            Obj_Personas_DAL.dtTablaPersonas = Obj_BDService.ListarDatos("sp_Listar_Personas", "Personas", ref vError);
            Obj_Personas_DAL.sError = vError;
        }

        public void Filtrar(ref Cls_Personas_DAL Obj_Personas_DAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            Crear_Parametros(ref Obj_Personas_DAL);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Filtro", "2", Obj_Personas_DAL.sFiltro);

            Obj_Personas_DAL.dtTablaPersonas = Obj_BDService.FiltrarDatos("sp_Filtrar_Personas", "Personas", Obj_Personas_DAL.dtParametros, ref vError);
            Obj_Personas_DAL.sError = vError;
        }

        public void Eliminar(ref Cls_Personas_DAL Obj_Personas_DAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            Crear_Parametros(ref Obj_Personas_DAL);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Cedula", "2", Obj_Personas_DAL.sFiltro);

            Obj_BDService.EliminarDato("sp_Eliminar_Persona", "Personas", Obj_Personas_DAL.dtParametros, ref vError);
            Obj_Personas_DAL.sError = vError;
        }

        public void Insertar(ref Cls_Personas_DAL Obj_Personas_DAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            char vAccion = Obj_Personas_DAL.cAccion;
            Crear_Parametros(ref Obj_Personas_DAL);

            Obj_Personas_DAL.dtParametros.Rows.Add("@Cedula", "2", Obj_Personas_DAL.sCedula);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Nombre", "2", Obj_Personas_DAL.sNombre);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Primer_Apellido", "2", Obj_Personas_DAL.sPrimerApellido);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Segundo_Apellido", "2", Obj_Personas_DAL.sSegundoApellido);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Email", "2", Obj_Personas_DAL.sEmail);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Telefono1", "2", Obj_Personas_DAL.sTelefono1);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Telefono2", "2", Obj_Personas_DAL.sTelefono2);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Usuario", "2", Obj_Personas_DAL.sUsuario);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Contrasena", "2", Obj_Personas_DAL.sContrasenia);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Super_Usuario", "8", Obj_Personas_DAL.sSuperUsuario);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Activo", "8", Obj_Personas_DAL.sActivo);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Provincia", "2", Obj_Personas_DAL.sProvincia);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Canton", "2", Obj_Personas_DAL.sCanton);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Distrito", "2", Obj_Personas_DAL.sDistrito);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Direccion_Exacta", "2", Obj_Personas_DAL.sDireccionExacta);
            Obj_BDService.InsertarDato("sp_Insertar_Persona", "Personas", Obj_Personas_DAL.dtParametros,ref vAccion, ref vError);
            Obj_Personas_DAL.cAccion = vAccion;
            Obj_Personas_DAL.sError = vError;
        }

        public void Editar(ref Cls_Personas_DAL Obj_Personas_DAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;
            char vAccion = Obj_Personas_DAL.cAccion;
            Crear_Parametros(ref Obj_Personas_DAL);

            Obj_Personas_DAL.dtParametros.Rows.Add("@Cedula", "2", Obj_Personas_DAL.sCedula);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Nombre", "2", Obj_Personas_DAL.sNombre);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Primer_Apellido", "2", Obj_Personas_DAL.sPrimerApellido);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Segundo_Apellido", "2", Obj_Personas_DAL.sSegundoApellido);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Email", "2", Obj_Personas_DAL.sEmail);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Telefono1", "2", Obj_Personas_DAL.sTelefono1);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Telefono2", "2", Obj_Personas_DAL.sTelefono2);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Usuario", "2", Obj_Personas_DAL.sUsuario);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Contrasena", "2", Obj_Personas_DAL.sContrasenia);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Super_Usuario", "8", Obj_Personas_DAL.sSuperUsuario);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Activo", "8", Obj_Personas_DAL.sActivo);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Provincia", "2", Obj_Personas_DAL.sProvincia);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Canton", "2", Obj_Personas_DAL.sCanton);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Distrito", "2", Obj_Personas_DAL.sDistrito);
            Obj_Personas_DAL.dtParametros.Rows.Add("@Direccion_Exacta", "2", Obj_Personas_DAL.sDireccionExacta);
            Obj_BDService.InsertarDato("sp_Modificar_Persona", "Personas", Obj_Personas_DAL.dtParametros, ref vAccion, ref vError);
            Obj_Personas_DAL.cAccion = vAccion;
            Obj_Personas_DAL.sError = vError;
        }

    }
}
