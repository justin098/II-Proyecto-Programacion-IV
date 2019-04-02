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
    public class Cls_Membership_BLL
    {
        public void Crear_Parametros(ref Cls_Membership_DAL Obj_Membership_DAL)
        {
            try
            {
                Obj_Membership_DAL.dtParametros = new DataTable("Parametros");
                Obj_Membership_DAL.dtParametros.Columns.Add("Nombre");
                Obj_Membership_DAL.dtParametros.Columns.Add("Tipo");
                Obj_Membership_DAL.dtParametros.Columns.Add("Valor");

                Obj_Membership_DAL.sError = string.Empty;
            }
            catch (Exception Error)
            {
                Obj_Membership_DAL.sError = Error.Message.ToString();
                Obj_Membership_DAL.dtParametros = null;
            }

        }

        public bool Login(ref Cls_Membership_DAL Obj_Membership_DAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;

            Crear_Parametros(ref Obj_Membership_DAL);
            Obj_Membership_DAL.dtParametros.Rows.Add("@UserLogin", "2", Obj_Membership_DAL.sUserLogin);
            Obj_Membership_DAL.dtParametros.Rows.Add("@Contrasena", "2", Obj_Membership_DAL.sContrasena);

            Obj_Membership_DAL.dtTablMembership = Obj_BDService.FiltrarDatos("sp_Login", "Membership", Obj_Membership_DAL.dtParametros, ref vError);
            Obj_Membership_DAL.sError = vError;
            if (Obj_Membership_DAL.sError == string.Empty)
            {
                if (Obj_Membership_DAL.dtTablMembership.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public bool HasPrivilege(ref Cls_Membership_DAL Obj_Membership_DAL)
        {
            BDServiceClient Obj_BDService = new BDServiceClient();

            string vError = string.Empty;

            Crear_Parametros(ref Obj_Membership_DAL);
            Obj_Membership_DAL.dtParametros.Rows.Add("@Usuario ", "2", Obj_Membership_DAL.sUsuario);
            Obj_Membership_DAL.dtParametros.Rows.Add("@Privilegio ", "2", Obj_Membership_DAL.sPrivilegio);

            Obj_Membership_DAL.dtTablMembership = Obj_BDService.FiltrarDatos("sp_Has_Privilege", "Membership", Obj_Membership_DAL.dtParametros, ref vError);
            Obj_Membership_DAL.sError = vError;
            if (Obj_Membership_DAL.sError == string.Empty)
            {
                if (Obj_Membership_DAL.dtTablMembership.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
    }
}
