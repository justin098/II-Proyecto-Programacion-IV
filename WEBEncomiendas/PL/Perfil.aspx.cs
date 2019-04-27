using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] != null)
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
    }
}