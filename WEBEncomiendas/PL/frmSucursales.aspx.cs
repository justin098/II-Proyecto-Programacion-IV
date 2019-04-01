using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.CatMan;
using BLL.CatMan;

namespace PL
{
    public partial class frmSucursales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Form.Attributes.Add("autocomplete", "off");
                CargarSucursales();
            }
        }

        private void CargarSucursales()
        {
            clsSucursalesBLL objBLL = new clsSucursalesBLL();
            clsSucursalesDAL objDAL = new clsSucursalesDAL();
            if (txtBuscar.Value == string.Empty)
            {
                objBLL.Listar(ref objDAL);
            }
            else
            {
                objDAL.Filtro = txtBuscar.Value.Trim();
                objBLL.Filtrar(ref objDAL);
            }


            if (objDAL.Error == string.Empty && objDAL.DtTabla.Rows.Count>0)
            {
                this.gdvSucursales.DataSource = null;
                this.gdvSucursales.DataBind();
                this.gdvSucursales.DataSource = objDAL.DtTabla;
                this.gdvSucursales.DataBind();
                gdvSucursales.Visible = true;
            }else if (objDAL.Error == string.Empty)
            {
                gdvSucursales.Visible = false;
                lblMensaje.Text = "No hay datos que mostrar";
            }
            else
            {
                lblMensaje.Text = objDAL.Error;
            }
        }

        protected void gdvSucursales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvSucursales.PageIndex = e.NewPageIndex;
            CargarSucursales();
        }

        protected void bntBuscar_Click(object sender, EventArgs e)
        {
            CargarSucursales();
        }
    }
}