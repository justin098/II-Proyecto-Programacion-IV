using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL
{
    public partial class Ingreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtusuario.Value = string.Empty;
                txtcontrasenia.Value = string.Empty;
            }
            lblMensaje.Visible = false;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            DAL.Cat_Man.Cls_Membership_DAL objDAL = new DAL.Cat_Man.Cls_Membership_DAL();
            BLL.Cat_Man.Cls_Membership_BLL objBLL = new BLL.Cat_Man.Cls_Membership_BLL();
            objDAL.sUserLogin = txtusuario.Value;
            objDAL.sContrasena = txtcontrasenia.Value;
            if (objBLL.Login(ref objDAL))
            {
                Session["UserLogin"] = objDAL.sUserLogin;
                txtusuario.Value = string.Empty;
                txtcontrasenia.Value = string.Empty;
                Response.Redirect("/Perfil.aspx");
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrecta";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
            }



        }
    }
}