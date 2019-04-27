using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL
{
    public partial class Cambiar_Estado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] != null)
            {
                DAL.Cat_Man.Cls_Membership_DAL objDAL = new DAL.Cat_Man.Cls_Membership_DAL();
                BLL.Cat_Man.Cls_Membership_BLL objBLL = new BLL.Cat_Man.Cls_Membership_BLL();
                objDAL.sUserLogin = Session["UserLogin"].ToString();
                objDAL.sPrivilegio = "Cambiar_Estado";
                if (objBLL.HasPrivilege(ref objDAL))
                {
                    if (!IsPostBack)
                    {

                    }
                }
                else
                {
                    Response.Redirect("Inicio.aspx");
                }
            }
            else
            {
                Response.Redirect("Inicio.aspx");
            }
        }
    }
}